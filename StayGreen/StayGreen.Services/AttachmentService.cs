﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StayGreen.Common.Exception;
using StayGreen.Common.Query;
using StayGreen.Common.Settings;
using StayGreen.Models.Context;
using StayGreen.Models.Dtos.Schemas;
using StayGreen.Models.Schema;
using StayGreen.Services.Code;
using StayGreen.Services.Common;
using StayGreen.Services.ExtensionMethods;
using StayGreen.Services.Interfaces;
using StayGreen.Services.Interfaces.Common;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StayGreen.Services
{
    public class AttachmentService : BaseService<Attachment, AttachmentDto, AttachmentDto, AttachmentDto>, IAttachmentService
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

        public override PaginatedList<AttachmentDto> GetFiltered(IQueryOptions queryOptions)
        {
            var qo = queryOptions ?? new EmptyQueryOptions();

            var items = DbContext.Attachments.Include(d => d.AttachmentGroup).Where(x => !x.IsDeleted)
                .Select(x => new AttachmentDto
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

            var paginatedResult = items.ApplyPagination<AttachmentDto, AttachmentDto>(qo.PagingOptions);

            return paginatedResult;
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

            var path = _appEnvironment.WebRootPath + GetAttachmentGoupPath(attachmentGroup.Name);

            Directory.CreateDirectory(Path.GetDirectoryName(path));

            var fullPath = Path.Combine(path, $"{Guid.NewGuid()}" + "-" + $"{uploadedFile.FileName}");

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            var attachment = new AttachmentDto
            {
                Path = fullPath,
                Name = uploadedFile.FileName
            };

            var result = base.Create(attachment);

            await DbContext.SaveChangesAsync();

            return Mapper.Map<AttachmentDto>(result);
        }

        private string GetAttachmentGoupPath(string name)
        {
            string path;

            switch (name)
            {
                case "Avatar":
                    path =_fileStoreFolder.AvatarsPath;
                    break;
                case "Document":
                    path = _fileStoreFolder.DocumetsPath;
                    break;
                case "Audio":
                    path = _fileStoreFolder.AudioPath;
                    break;
                case "Image":
                    path = _fileStoreFolder.ImagesPath;
                    break;
                default:
                    throw new StayGreenNotFoundException("Path");
            }

            return path;
        }
    }
}