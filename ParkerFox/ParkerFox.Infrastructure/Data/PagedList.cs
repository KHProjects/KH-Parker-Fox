using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Infrastructure.Data
{
    /// <summary>
    /// http://blogs.planetcloud.co.uk/mygreatdiscovery/?page=2
    /// </summary>
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize):
            this(source.GetPage(pageIndex, pageSize), pageIndex, pageSize, x=>x.Count())
        {
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, Func<IEnumerable<T>, int> totalFunc)
        {
            var totalCount = totalFunc(source);
            TotalCount = totalCount;
            TotalPages = totalCount/pageSize;

            if(totalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;

            AddRange(source.ToList());
        }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPreviousPage { get { return PageIndex > 0; } }
        public bool HasNextPage { get { return PageIndex + 1 < TotalPages; } }
    }

    public static class PageListExtensions
    {
        public static IEnumerable<T> GetPage<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
        {
            return source.Skip(pageIndex * pageSize).Take(pageSize);
        }
    }
}
