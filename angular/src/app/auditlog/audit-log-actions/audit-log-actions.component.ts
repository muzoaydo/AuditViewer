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
    { label: "Id", value: "id", name: "::id", prop: "id", width: 30, type: "" },
    { label: "Audit Log Id", value: "auditLogId", name: "::auditLogId", prop: "auditLogId", width: 30 , type: ""},
    { label: "Tenant Id", value: "tenantId", name: "::tenantId", prop: "tenantId", width: 30, type: ""},
    { label: "Service Name", value: "serviceName", name: "::serviceName", prop: "serviceName", width: 30, type: "" },
    { label: "Method Name", value: "methodName", name: "::methodName", prop: "methodName", width: 30, type: "" },
    { label: "Execution Time", value: "executionTime", name: "::executionTime", prop: "executionTime", width: 30, type: "" },
    { label: "Execution Duration", value: "executionDuration", name: "::executionDuration", prop: "executionDuration", width: 30, type: "" },
    { label: "Parameters", value: "parameters", name: "::parameters", prop: "parameters", width: 30, type: "JSON" },
    { label: "Extra Property", value: "extraProperty", name: "::extraProperty", prop: "extraProperty", width: 30, type: 'JSON' },
    
  ]

  auditLogActions = {items: [], totalCount: 0 } as PagedResultDto<AuditLogActionDto>;

  constructor(public readonly list: ListService, private auditLogActionService: AuditLogActionService) { }

  ngOnInit(): void {
    const auditLogActionStreamCreator = (query) => this.auditLogActionService.getListById({...query, selectedLogId: this.selectedLogId});
    this.list.hookToQuery(auditLogActionStreamCreator).subscribe((response) => {
      this.auditLogActions = response;

      let jsonFields = this.actionsArr.filter(a => a.type === 'JSON').map(b => b.value);

      for (let i = 0; i < jsonFields.length; i++) {
        let fieldName = jsonFields[i];
        for (let j=0; j < this.auditLogActions.items.length; j++) {
          let item = this.auditLogActions.items[j];
          debugger
          if (item[fieldName]) {
            item[fieldName] = JSON.stringify(JSON.parse(item[fieldName]), null, 2)
          }
        }
        
      }
    });
  }
}