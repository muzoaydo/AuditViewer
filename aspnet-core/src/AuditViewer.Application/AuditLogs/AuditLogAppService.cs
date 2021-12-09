using AuditViewer.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging;
using System.Linq.Dynamic.Core;

using Volo.Abp.Domain.Repositories;

namespace AuditViewer.AuditLogs
{
    public class AuditLogAppService :
        ReadOnlyAppService<
            AuditLog,
            AuditLogDto,
            Guid,
            PagedAndSortedResultRequestDto
            >,
        IAuditLogAppService
    {
        private readonly IRepository<AuditLog, Guid> _auditLogFilterRepository;


        //private Func<AuditLog, bool> filtering(FilterDto input, AuditLog x)
        //{


        //    x => (!input.UserName.IsNullOrWhiteSpace() ? x.UserName.Contains(input.UserName) : true)
        //        && (!input.ClientIpAddress.IsNullOrWhiteSpace() ? x.ClientIpAddress.Contains(input.ClientIpAddress) : true)
        //        && (!input.Url.IsNullOrWhiteSpace() ? x.Url.Contains(input.Url) : true)
        //        && (!input.HttpMethod.IsNullOrWhiteSpace() ? x.HttpMethod.Contains(input.HttpMethod) : true)
        //        && (input.HttpStatusCode.HasValue ? (x.HttpStatusCode == input.HttpStatusCode) : true)
        //        && (input.HasExceptions == "YES" ? x.Exceptions != null : true)
        //        && (input.HasExceptions == "NO" ? x.Exceptions == null : true)

        //        return x
        //}


        public AuditLogAppService(IRepository<AuditLog, Guid> auditLogFilterRepository)
            : base(auditLogFilterRepository)
        {
            _auditLogFilterRepository = auditLogFilterRepository;
        }

        public async Task<PagedResultDto<AuditLogDto>> GetFilteredListAsync(FilterDto input)
        {
            //var filter = queryable.Where(x => (!input.UserName.IsNullOrWhiteSpace() ? x.UserName.Contains(input.UserName) : true)
            //    && (!input.ClientIpAddress.IsNullOrWhiteSpace() ? x.ClientIpAddress.Contains(input.ClientIpAddress) : true)
            //    && (!input.Url.IsNullOrWhiteSpace() ? x.Url.Contains(input.Url) : true)
            //    && (!input.HttpMethod.IsNullOrWhiteSpace() ? x.HttpMethod.Contains(input.HttpMethod) : true)
            //    && (input.HttpStatusCode.HasValue ? (x.HttpStatusCode == input.HttpStatusCode) : true)
            //    && (input.HasExceptions == "YES" ? x.Exceptions != null : true)
            //    && (input.HasExceptions == "NO" ? x.Exceptions == null : true));
            //var totalCount = filter
            //var filteringVar = await _auditLogFilterRepository.CountAsync(filtering());

            var totalCount = await _auditLogFilterRepository.CountAsync(
                x => (!input.UserName.IsNullOrWhiteSpace() ? x.UserName.Contains(input.UserName) : true)
                && (!input.ClientIpAddress.IsNullOrWhiteSpace() ? x.ClientIpAddress.Contains(input.ClientIpAddress) : true)
                && (!input.Url.IsNullOrWhiteSpace() ? x.Url.Contains(input.Url) : true)
                && (!input.HttpMethod.IsNullOrWhiteSpace() ? x.HttpMethod.Contains(input.HttpMethod) : true)
                && (input.HttpStatusCode.HasValue ? (x.HttpStatusCode == input.HttpStatusCode) : true)
                && (input.HasExceptions == "YES" ? x.Exceptions != null : true)
                && (input.HasExceptions == "NO" ? x.Exceptions == null : true));


            var queryable = await _auditLogFilterRepository.GetQueryableAsync();
            var list = queryable.Where(x => (!input.UserName.IsNullOrWhiteSpace() ? x.UserName.Contains(input.UserName) : true)
                && (!input.ClientIpAddress.IsNullOrWhiteSpace() ? x.ClientIpAddress.Contains(input.ClientIpAddress) : true)
                && (!input.Url.IsNullOrWhiteSpace() ? x.Url.Contains(input.Url) : true)
                && (!input.HttpMethod.IsNullOrWhiteSpace() ? x.HttpMethod.Contains(input.HttpMethod) : true)
                && (input.HttpStatusCode.HasValue ? (x.HttpStatusCode == input.HttpStatusCode) : true)
                && (input.HasExceptions == "YES" ? x.Exceptions != null : true)
                && (input.HasExceptions == "NO" ? x.Exceptions == null : true))
                .OrderByDescending(x => x.ExecutionTime)
                //.ThenBy(input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToList();

            var mappedList = ObjectMapper.Map<List<AuditLog>, List<AuditLogDto>>(list);



            return new PagedResultDto<AuditLogDto>(totalCount, mappedList);


        }


    }
}