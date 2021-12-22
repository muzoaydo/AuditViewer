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
using AuditViewer.Permissions;
using System.Text.RegularExpressions;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;
using System.Linq.Expressions;

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
        private readonly IDataFilter _dataFilter;


        public AuditLogAppService(IRepository<AuditLog, Guid> auditLogFilterRepository, IDataFilter dataFilter)
            : base(auditLogFilterRepository)
        {
            _auditLogFilterRepository = auditLogFilterRepository;
            _dataFilter = dataFilter;

            GetPolicyName = AuditViewerPermissions.AuditLogs.Default;
            GetListPolicyName = AuditViewerPermissions.AuditLogs.Default;
        }


        private Expression<Func<AuditLog, bool>> MyQuery(FilterDto input)
        {
           return ( x => (input.UserName.IsNullOrWhiteSpace() || x.UserName.Contains(input.UserName))
                   && (input.ClientIpAddress.IsNullOrWhiteSpace() || x.ClientIpAddress.Contains(input.ClientIpAddress))
                   && (input.Url.IsNullOrWhiteSpace() || input.IsRegex || x.Url.Contains(input.Url))
                   && (input.Url.IsNullOrWhiteSpace() || !input.IsRegex || Regex.IsMatch(x.Url, input.Url))
                   && (input.HttpMethod.IsNullOrWhiteSpace() || input.HttpMethod == "ANY" || x.HttpMethod.Contains(input.HttpMethod))
                   && (!input.HttpStatusCode.HasValue || (x.HttpStatusCode == input.HttpStatusCode))
                   && (input.HasExceptions != "YES" || x.Exceptions != null)
                   && (input.HasExceptions != "NO" || x.Exceptions == null))
                ;
        }


        public async Task<PagedResultDto<AuditLogDto>> GetFilteredListAsync(FilterDto input)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                
            if (input.Sorting == null)
            {
                input.Sorting = "executionTime desc";
            }


            var totalCount = await _auditLogFilterRepository.CountAsync(MyQuery(input));


            var queryable = await _auditLogFilterRepository.GetQueryableAsync();
                var list = queryable.Where(MyQuery(input))
                .OrderBy(input.Sorting)
                .ThenBy("executionTime desc")
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToList();

            var mappedList = ObjectMapper.Map<List<AuditLog>, List<AuditLogDto>>(list);



            return new PagedResultDto<AuditLogDto>(totalCount, mappedList);
            }

        }


    }
}