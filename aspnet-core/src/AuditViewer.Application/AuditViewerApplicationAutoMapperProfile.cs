using AutoMapper;
using Volo.Abp.AuditLogging;
using AuditViewer.AuditLogs;
using AuditViewer.AuditLogActions;

namespace AuditViewer
{
    public class AuditViewerApplicationAutoMapperProfile : Profile
    {
        public AuditViewerApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<AuditLog, AuditLogDto>();
            CreateMap<AuditLogDto, AuditLog>();
            CreateMap<AuditLogAction, AuditLogActionDto>();
            CreateMap<AuditLogActionDto, AuditLogAction>();
        }
    }
}
