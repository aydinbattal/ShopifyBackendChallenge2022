using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Entities;

namespace Api.Models.Helpers
{
    public static class ResponseHelper<T>
    {
        public static PagedResponse<T> GetPagedResponse(string url, IEnumerable<T> data, int pageNumber, int pageSize, int totalItems)
        {
            var response = new PagedResponse<T>(data);
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            response.Meta.Add("totalPages", totalPages.ToString());
            response.Meta.Add("totalItems", totalItems.ToString());
            response.Links.Add("first", $"{url}pagenumber=1");
            response.Links.Add("last", $"{url}pagenumber={totalPages}");
            response.Links.Add("next", pageNumber == totalPages ? null : $"{url}pagenumber={pageNumber + 1}");
            response.Links.Add("previous", pageNumber == 1 ? null : $"{url}pagenumber={pageNumber - 1}");
            return response;
        }
    }
}