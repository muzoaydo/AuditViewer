import type { PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface FilterDto extends PagedAndSortedResultRequestDto {
  userName?: string;
  clientIpAddress?: string;
  url?: string;
  httpMethod?: string;
  httpStatusCode?: number;
  hasExceptions?: string;
}
