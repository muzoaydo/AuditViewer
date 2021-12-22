using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AuditViewer.Filters
{
    public class FilterDto : PagedAndSortedResultRequestDto
    {


        public string UserName { get; set; }

        public string ClientIpAddress { get; set; }

        public string Url { get; set; }
        public string HttpMethod { get; set; }

        public int? HttpStatusCode { get; set; }

        public string HasExceptions { get; set; }

        public bool IsRegex { get; set; }
    }
}
