using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AuditViewer.Filters
{
    public class FilterDto : PagedAndSortedResultRequestDto
    {


        //[StringLength(AuditLogSharedConsts.UserNameMaxLength)]
        public string UserName { get; set; }

        //[StringLength(AuditLogSharedConsts.ClientIpAddressMaxLength)]
        public string ClientIpAddress { get; set; }

        //[StringLength(AuditLogSharedConsts.UrlMaxLength)]
        public string Url { get; set; }
        public string HttpMethod { get; set; }

        public int? HttpStatusCode { get; set; }

        public string HasExceptions { get; set; }
    }
}
