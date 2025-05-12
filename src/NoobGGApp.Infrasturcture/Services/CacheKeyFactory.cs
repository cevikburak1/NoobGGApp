using NoobGGApp.Application.Attributes;
using NoobGGApp.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Infrastructure.Services
{
    public class CacheKeyFactory : ICacheKeyFactory
    {
        public string CreateCacheKey<TRequest>(TRequest request) where TRequest : ICacheable
        {
            var typeName = typeof(TRequest).Name;
            var cacheGroup = request.CacheGroup;
            var properties = typeof(TRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetCustomAttribute<CacheKeyPartAttribute>() != null)
                .OrderBy(p => p.Name);
            var keyBuilder = new StringBuilder();
            keyBuilder.Append(typeName);

            foreach (var prop in properties)
            {
                var attr = prop.GetCustomAttribute<CacheKeyPartAttribute>()!;
                var value = prop.GetValue(request);
                string normalizedValue = NormalizeValue(value, attr);
                keyBuilder.Append($"_{attr.Prefix}{normalizedValue}");
            }
            return keyBuilder.ToString();
        }
       
        private string NormalizeValue(object? value, CacheKeyPartAttribute attr)
        {
            if (value is null)
                return "null";

            string stringValue = value.ToString() ?? "null";
            if (attr.Encode)
            {
                stringValue = Uri.EscapeDataString(stringValue);
            }
            return stringValue;
        }
    }
}
