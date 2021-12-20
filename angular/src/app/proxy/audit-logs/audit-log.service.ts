import type { AuditLogDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { FilterDto } from '../filters/models';

@Injectable({
  providedIn: 'root',
})
export class AuditLogService {
  apiName = 'Default';

  get = (id: string) =>
    this.restService.request<any, AuditLogDto>({
      method: 'GET',
      url: `/api/app/audit-log/${id}`,
    },
    { apiName: this.apiName });

  getFilteredList = (input: FilterDto) =>
    this.restService.request<any, PagedResultDto<AuditLogDto>>({
      method: 'GET',
      url: '/api/app/audit-log/filtered-list',
      params: { userName: input.userName, clientIpAddress: input.clientIpAddress, url: input.url, httpMethod: input.httpMethod, httpStatusCode: input.httpStatusCode, hasExceptions: input.hasExceptions, isRegex: input.isRegex, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<AuditLogDto>>({
      method: 'GET',
      url: '/api/app/audit-log',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
