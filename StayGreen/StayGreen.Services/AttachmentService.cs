using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StayGreen.Common.Exception;
using StayGreen.Common.Query;
using StayGreen.Common.Settings;
using StayGreen.Models.Context;
using StayGreen.Models.Dtos.Schemas;
using StayGreen.Models.Dtos.Schemas.Attachments;
using StayGreen.Models.Enums;
using StayGreen.Models.Schema;
using StayGreen.Services.Code;
using StayGreen.Services.Common;
using StayGreen.Services.ExtensionMethods;
using StayGreen.Services.Interfaces;
using StayGreen.Services.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StayGreen.Services
{
    public class AttachmentService : BaseService<Attachment, AttachmentReadDto, AttachmentDto, AttachmentDto>, IAttachmentService
    {
        private readonly ISecurityService _securityService;
        private readonly IUserService _userService;
        private readonly FileStoreFolder _fileStoreFolder;
        private readonly IHostingEnvironment _appEnvironment;

        public AttachmentService(
            ApplicationDbContext dbContext, 
            IUserWrapper userWrapper,
            ISecurityService securityService,
            IUserService userService,
            IOptions<AppSettings> options,
            IHostingEnvironment appEnvironment
            ) 
            : base(dbContext, userWrapper)
        {
            _securityService = securityService;
            _userService = userService;
            _fileStoreFolder = options.Value.FileStoreFolder;
            _appEnvironment = appEnvironment;
        }

        public override PaginatedList<AttachmentReadDto> GetFiltered(IQueryOptions queryOptions)
        {
            var qo = queryOptions ?? new EmptyQueryOptions();

            var items = DbContext.Attachments.Include(d => d.AttachmentGroup).Where(x => !x.IsDeleted)
                .Select(x => new AttachmentReadDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Path = x.Path,
                    Description = x.Description
                })
                .AsQueryable();

            if (qo.SortOptions != null)
            {
                items = items.ApplySorting(qo.SortOptions);
            }

            var paginatedResult = items.ApplyPagination<AttachmentReadDto, AttachmentReadDto>(qo.PagingOptions);

            return paginatedResult;
        }

        public IEnumerable<AttachmentDto> GetOnlyImages()
        {
            var dbAttachments = DbContext.Attachments.Where(x => x.AttachmentGroup.CategoryType == FileCategoryType.Images);
            return Mapper.Map<List<AttachmentDto>>(dbAttachments);
        }

        public async Task<AttachmentDto> UploadFileLocal(IFormFile uploadedFile, Guid attachmentGroupId)
        {
            var attachmentGroup = DbContext.AttachmentGroups.FirstOrDefault(x => x.Id == attachmentGroupId);
            if (attachmentGroup == null)
            {
                throw new StayGreenNotFoundException("AttachmentGroup");
            }

            var user = _userService.GetById(UserWrapper.Id);
            if (user == null)
            {
                throw new StayGreenNotFoundException("User");
            }

            var path = _appEnvironment.WebRootPath + GetAttachmentGoupPath(attachmentGroup.CategoryType);

            Directory.CreateDirectory(Path.GetDirectoryName(path));

            var fullPath = Path.Combine(path, $"{Guid.NewGuid()}" + "-" + $"{uploadedFile.FileName}");

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            var attachment = new AttachmentDto
            {
                Path = fullPath,
                Name = uploadedFile.FileName,
                MimeType = uploadedFile.ContentType
            };

            var result = base.Create(attachment);

            await DbContext.SaveChangesAsync();

            return Mapper.Map<AttachmentDto>(result);
        }

        private string GetAttachmentGoupPath(FileCategoryType name)
        {
            string path;

            switch (name)
            {
                case FileCategoryType.Avatars:
                    path =_fileStoreFolder.AvatarsPath;
                    break;
                case FileCategoryType.Documents:
                    path = _fileStoreFolder.DocumetsPath;
                    break;
                case FileCategoryType.Audios:
                    path = _fileStoreFolder.AudioPath;
                    break;
                case FileCategoryType.Images:
                    path = _fileStoreFolder.ImagesPath;
                    break;
                case FileCategoryType.Icons:
                    path = _fileStoreFolder.ImagesPath;
                    break;
                default:
                    throw new StayGreenNotFoundException("Path");
            }

            return path;
        }
    }
}
