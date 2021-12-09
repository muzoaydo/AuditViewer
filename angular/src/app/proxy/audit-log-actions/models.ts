import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface AuditLogActionDto extends EntityDto<string> {
  tenantId?: string;
  auditLogId?: string;
  serviceName?: string;
  methodName?: string;
  parameters?: string;
  executionTime?: string;
  executionDuration: number;
  extraProperties: Record<string, object>;
  extraProperty?: string;
}

export interface GetAuditLogActionListDto extends PagedAndSortedResultRequestDto {
  auditLogId?: string;
}
