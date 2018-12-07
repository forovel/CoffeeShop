﻿using AutoMapper;
using StayGreen.Common.Query;
using StayGreen.Models.Common;
using StayGreen.Models.Context;
using StayGreen.Services.Interfaces;
using StayGreen.Services.Interfaces.Common;
using System;
using System.Linq;

namespace StayGreen.Services.Common
{
    public abstract class BaseService<T, TReadDto, TCreateDto, TUpdateDto> : IBaseService<TReadDto, TCreateDto, TUpdateDto, Guid> where T : class, IEntity<Guid>
    {
        protected ApplicationDbContext DbContext;
        protected IUserWrapper UserWrapper;

        public BaseService(
            ApplicationDbContext dbContext,
            IUserWrapper userWrapper
            )
        {
            DbContext = dbContext;
            UserWrapper = userWrapper;
        }

        public abstract PaginatedList<TReadDto> GetFiltered(IQueryOptions queryOptions);

        public IQueryable<T> GetList()
        {
            return DbContext.Set<T>();
        }

        public virtual TReadDto GetById(Guid id)
        {
            var dbItem = DbContext.Set<T>().Find(id);
            var dto = Mapper.Map<T, TReadDto>(dbItem);

            return dto;
        }

        public virtual TCreateDto Create(TCreateDto model)
        {
            var dbModel = Mapper.Map<TCreateDto, T>(model);
            dbModel.DateCreated = DateTime.Now;
            dbModel.DateUpdated = DateTime.Now;
            dbModel.CreatedById = UserWrapper.Id;
            dbModel.UpdatedById = UserWrapper.Id;

            DbContext.Set<T>().Add(dbModel);
            DbContext.SaveChanges();

            return model;
        }

        public virtual TUpdateDto Update(Guid id, TUpdateDto model)
        {
            var dbitem = DbContext.Set<T>().Find(id);
            dbitem.DateUpdated = DateTime.Now;
            dbitem.UpdatedById = UserWrapper.Id;
            var dto = Mapper.Map<T, TUpdateDto>(dbitem);

            DbContext.SaveChanges();

            return dto;
        }

        public virtual void Delete(Guid id)
        {
            var dbitem = DbContext.Set<T>().Find(id);
            dbitem.IsDeleted = true;

            DbContext.SaveChanges();
        }
    }
}