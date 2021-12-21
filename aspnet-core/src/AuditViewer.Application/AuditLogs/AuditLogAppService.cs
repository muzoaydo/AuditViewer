﻿using AuditViewer.Filters;
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
using AuditViewer.Permissions;
using System.Text.RegularExpressions;


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


        public AuditLogAppService(IRepository<AuditLog, Guid> auditLogFilterRepository)
            : base(auditLogFilterRepository)
        {
            _auditLogFilterRepository = auditLogFilterRepository;

            GetPolicyName = AuditViewerPermissions.AuditLogs.Default;
            GetListPolicyName = AuditViewerPermissions.AuditLogs.Default;
        }

        public async Task<PagedResultDto<AuditLogDto>> GetFilteredListAsync(FilterDto input)
        {

            if (input.Sorting == null)
            {
                input.Sorting = "executionTime asc";
            }

            var totalCount = await _auditLogFilterRepository.CountAsync(
                x => (!input.UserName.IsNullOrWhiteSpace() ? x.UserName.Contains(input.UserName) : true)
                && (!input.ClientIpAddress.IsNullOrWhiteSpace() ? x.ClientIpAddress.Contains(input.ClientIpAddress) : true)
                && (!input.Url.IsNullOrWhiteSpace() && !input.IsRegex ? x.Url.Contains(input.Url) : true)
                && (!input.Url.IsNullOrWhiteSpace() && input.IsRegex ? Regex.IsMatch(x.Url, input.Url) : true)
                && (!input.HttpMethod.IsNullOrWhiteSpace() && input.HttpMethod != "ANY" ? x.HttpMethod.Contains(input.HttpMethod) : true)
                && (input.HttpStatusCode.HasValue ? (x.HttpStatusCode == input.HttpStatusCode) : true)
                && (input.HasExceptions == "YES" ? x.Exceptions != null : true)
                && (input.HasExceptions == "NO" ? x.Exceptions == null : true));


            var queryable = await _auditLogFilterRepository.GetQueryableAsync();
            var list = queryable.Where(x => (!input.UserName.IsNullOrWhiteSpace() ? x.UserName.Contains(input.UserName) : true)
                && (!input.ClientIpAddress.IsNullOrWhiteSpace() ? x.ClientIpAddress.Contains(input.ClientIpAddress) : true)
                && (!input.Url.IsNullOrWhiteSpace() && !input.IsRegex ? x.Url.Contains(input.Url) : true)
                && (!input.Url.IsNullOrWhiteSpace() && input.IsRegex ? Regex.IsMatch(x.Url, input.Url) : true)
                && (!input.HttpMethod.IsNullOrWhiteSpace() && input.HttpMethod != "ANY" ? x.HttpMethod.Contains(input.HttpMethod) : true)
                && (input.HttpStatusCode.HasValue ? (x.HttpStatusCode == input.HttpStatusCode) : true)
                && (input.HasExceptions == "YES" ? x.Exceptions != null : true)
                && (input.HasExceptions == "NO" ? x.Exceptions == null : true))
                .OrderBy(input.Sorting)
                .ThenBy("executionTime asc")
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToList();

            var mappedList = ObjectMapper.Map<List<AuditLog>, List<AuditLogDto>>(list);



            return new PagedResultDto<AuditLogDto>(totalCount, mappedList);


        }


    }
}