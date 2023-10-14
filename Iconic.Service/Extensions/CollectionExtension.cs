using Iconic.Domain.Configurations;
using System.Linq;

namespace Iconic.Service.Extensions
{
    public static class CollectionExtension
    {
        public static IQueryable<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams @params)
        {
            return @params.PageSize > 0 && @params.PageIndex >= 0
                ? source.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
                : source;
        }
    }
}
