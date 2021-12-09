using AuditViewer.AuditLogs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging;
using Nancy.Json;

namespace AuditViewer.AuditLogActions
{
    public class AuditLogActionAppService :
        ReadOnlyAppService<
            AuditLogAction, //The Book entity
            AuditLogActionDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto>, //Used for paging/sorting
        IAuditLogActionAppService //implement the IBookAppService
    {
        private readonly IAuditLogActionRepository _auditLogActionRepository;

        public AuditLogActionAppService(IAuditLogActionRepository auditLogActionrepository)
            : base(auditLogActionrepository)
        {
            _auditLogActionRepository = auditLogActionrepository;
        }

        public async Task<PagedResultDto<AuditLogActionDto>> GetListByIdAsync(GetAuditLogActionListDto input)
        {
            if (string.IsNullOrEmpty(input.Sorting))
            {
                input.Sorting = "id";
            }

            var totalCount = await _auditLogActionRepository.GetCountAsync(input);

            var auditLogActions = await _auditLogActionRepository.GetListByIdAsync(input);
            var mappedList = ObjectMapper.Map<List<AuditLogAction>, List<AuditLogActionDto>>(auditLogActions);
            foreach (var item in mappedList)
            {
                item.ExtraProperty = new JavaScriptSerializer().Serialize(item.ExtraProperties);
            }
            return new PagedResultDto<AuditLogActionDto>(totalCount, mappedList);
        }
    }
}
