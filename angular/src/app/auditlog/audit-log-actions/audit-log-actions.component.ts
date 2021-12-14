import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, Input, OnInit } from '@angular/core';
import { AuditLogActionDto, AuditLogActionService } from '@proxy/audit-log-actions';

@Component({
  selector: 'app-audit-log-actions',
  templateUrl: './audit-log-actions.component.html',
  styleUrls: ['./audit-log-actions.component.scss']
})
export class AuditLogActionsComponent implements OnInit {

  @Input() selectedLogId;

  actionsArr = [
    { label: "Tenant Id", value: "tenantId", name: "::tenantId", prop: "tenantId", width: 30 },
    { label: "Audit Log Id", value: "auditLogId", name: "::auditLogId", prop: "auditLogId", width: 30 },
    { label: "Service Name", value: "serviceName", name: "::serviceName", prop: "serviceName", width: 30 },
    { label: "Method Name", value: "methodName", name: "::methodName", prop: "methodName", width: 30 },
    { label: "Parameters", value: "parameters", name: "::parameters", prop: "parameters", width: 30 },
    { label: "Execution Time", value: "executionTime", name: "::executionTime", prop: "executionTime", width: 30 },
    { label: "Execution Duration", value: "executionDuration", name: "::executionDuration", prop: "executionDuration", width: 30 },
    { label: "Extra Property", value: "extraProperty", name: "::extraProperty", prop: "extraProperty", width: 30 },
    { label: "Id", value: "id", name: "::id", prop: "id", width: 30 }
  ]

  auditLogActions = {items: [], totalCount: 0 } as PagedResultDto<AuditLogActionDto>;

  constructor(public readonly list: ListService, private auditLogActionService: AuditLogActionService) { }

  ngOnInit(): void {
    const auditLogActionStreamCreator = (query) => this.auditLogActionService.getListById({...query, selectedLogId: this.selectedLogId});
    debugger
    this.list.hookToQuery(auditLogActionStreamCreator).subscribe((response) => {
      this.auditLogActions = response;
      debugger
    });
  }
}