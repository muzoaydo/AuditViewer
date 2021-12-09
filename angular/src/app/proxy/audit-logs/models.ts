import type { AuditedEntityDto } from '@abp/ng.core';
import type { EntityChange } from '../abp/entity-history/models';
import type { AuditLogActionDto } from '../audit-log-actions/models';

export interface AuditLogDto extends AuditedEntityDto<string> {
  applicationName?: string;
  userId?: string;
  userName?: string;
  tenantId?: string;
  tenantName?: string;
  impersonatorUserId?: string;
  impersonatorTenantId?: string;
  executionTime?: string;
  executionDuration: number;
  clientIpAddress?: string;
  clientName?: string;
  clientId?: string;
  correlationId?: string;
  browserInfo?: string;
  httpMethod?: string;
  url?: string;
  exceptions?: string;
  comments?: string;
  httpStatusCode?: number;
  entityChanges: EntityChange[];
  auditLogActions: AuditLogActionDto[];
}
