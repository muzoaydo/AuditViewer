import type { AuditLogActionDto, GetAuditLogActionListDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuditLogActionService {
  apiName = 'Default';

  get = (id: string) =>
    this.restService.request<any, AuditLogActionDto>({
      method: 'GET',
      url: `/api/app/audit-log-action/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<AuditLogActionDto>>({
      method: 'GET',
      url: '/api/app/audit-log-action',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  getListById = (input: GetAuditLogActionListDto) =>
    this.restService.request<any, PagedResultDto<AuditLogActionDto>>({
      method: 'GET',
      url: '/api/app/audit-log-action/by-id',
      params: { auditLogId: input.auditLogId, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
