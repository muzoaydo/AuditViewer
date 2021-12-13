import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { AuditLogDto, AuditLogService } from '@proxy/audit-logs';

@Component({
  selector: 'app-auditlog',
  templateUrl: './auditlog.component.html',
  styleUrls: ['./auditlog.component.scss'],
  providers: [ListService],
})
export class AuditlogComponent implements OnInit {

  auditLogs = { items: [], totalCount: 0 } as PagedResultDto<AuditLogDto>;

  isExceptionsOpen = false;
  isDetailsOpen = false;
  isActionsOpen = false;
  selectedException = ""



  auditArr = [
    { label: "User", value: "userName", name: "::userName", prop: "userName", width: 30 },
    { label: "Ip Address", value: "clientIpAddress", name: "::clientIpAddress", prop: "clientIpAddress", width: 50 },
    { label: "Execution Time", value: "executionTime", name: "::executionTime", prop: "executionTime", width: 50 },
    { label: "Duration", value: "executionDuration", name: "::executionDuration", prop: "executionDuration", width: 10 }
  ]


  constructor(public readonly list: ListService, private auditLogService: AuditLogService) { }

  ngOnInit(): void {
    const auditLogStreamCreator = (query) => this.auditLogService.getFilteredList(query);

    this.list.hookToQuery(auditLogStreamCreator).subscribe((response) => {
      this.auditLogs = response

      for (let i = 0; i < this.auditLogs.items.length; i++) {
        let item = this.auditLogs.items[i];
        if (item["exceptions"]) {
          item["exceptions"] = JSON.stringify(JSON.parse(item["exceptions"]), null, 2).replace(/(\\r\\n|\r|\n)/gm, '');
          debugger
        }
      }
    }
    )
  };



  exceptions(exception) {
    this.isExceptionsOpen = true;
    this.selectedException = exception;

  }

  details() {
    this.isDetailsOpen = true;
  }

  actions() {
    this.isActionsOpen = true;
  }

}
