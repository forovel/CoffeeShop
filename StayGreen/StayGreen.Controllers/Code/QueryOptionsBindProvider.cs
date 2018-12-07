using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

namespace StayGreen.Controllers.Code
{
    public class QueryOptionsBindProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(QueryOptions))
            {
                return new BinderTypeModelBinder(typeof(QueryOptionsModelBinder));
            }

            return null;
        }
    }
}
