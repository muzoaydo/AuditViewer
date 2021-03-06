using AuditViewer.AuditLogs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging;
using Nancy.Json;
using Volo.Abp.Domain.Repositories;
using DevExpress.Xpo;

namespace AuditViewer.AuditLogActions
{
    public class AuditLogActionAppService :
        ReadOnlyAppService<
            AuditLogAction, 
            AuditLogActionDto,
            Guid, 
            PagedAndSortedResultRequestDto>, 
        IAuditLogActionAppService 
    {
        private readonly IAuditLogActionRepository _auditLogActionrepository;

        public AuditLogActionAppService(IAuditLogActionRepository auditLogActionrepository)
            : base(auditLogActionrepository)
        {
            _auditLogActionrepository = auditLogActionrepository;
        }

        public async Task<PagedResultDto<AuditLogActionDto>> GetListByIdAsync(GetAuditLogActionListDto input)
        {
            if (string.IsNullOrEmpty(input.Sorting))
            {
                input.Sorting = "id";
            }

            var totalCount = await _auditLogActionrepository.GetCountAsync(input);

            var auditLogActions = await _auditLogActionrepository.GetListByIdAsync(input);
            var mappedList = ObjectMapper.Map<List<AuditLogAction>, List<AuditLogActionDto>>(auditLogActions);
            foreach (var item in mappedList)
            {
                item.ExtraProperty = new JavaScriptSerializer().Serialize(item.ExtraProperties);
            }
            return new PagedResultDto<AuditLogActionDto>(totalCount, mappedList);
        }
    }
}
