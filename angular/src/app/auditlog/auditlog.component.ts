import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { AuditLogDto, AuditLogService } from '@proxy/audit-logs';
import { GetAuditLogActionListDto } from '@proxy/audit-log-actions';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-auditlog',
  templateUrl: './auditlog.component.html',
  styleUrls: ['./auditlog.component.scss'],
  providers: [ListService],
  encapsulation: ViewEncapsulation.None
})
export class AuditlogComponent implements OnInit {

  auditLogs = { items: [], totalCount: 0 } as PagedResultDto<AuditLogDto>;

  isExceptionsOpen = false;
  isDetailsOpen = false;
  isActionsOpen = false;
  selectedException = "";
  selectedLogId: string;
  selectedLog: object;

  user: string = "";
  stat: number;
  ip: string;
  urlVal: string;
  method: string;
  exc: string;
  isRegexVal: boolean

  subscription: Subscription;

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
      debugger
      this.parsing("exceptions");
    }
    )
  };

  ngOnChanges(): void {
    console.log(this.user);
  }



  exceptions(exception) {
    this.isExceptionsOpen = true;
    this.selectedException = exception;

  }

  details(row) {
    this.isDetailsOpen = true;
    this.selectedLog = row;
    debugger
  }

  actions(logId: string) {
    this.isActionsOpen = true;
    this.selectedLogId = logId;
  }

  clear() {
    this.user = ""
    this.stat = null
    this.ip = ""
    this.urlVal = ""
    this.method = ""
    this.exc = ""
  }

  parsing(fieldName: string) {
    for (let i = 0; i < this.auditLogs.items.length; i++) {
      let item = this.auditLogs.items[i];
      if (item[fieldName]) {
        item[fieldName] = JSON.stringify(JSON.parse(item[fieldName]), null, 2).replace(/(\\r\\n)/gm, '\r\n');
      }
    }
  }

  filter( userName: string,
          httpStatusCode: number,
          clientIpAddress: string,
          url: string,
          httpMethod: string,
          hasExceptions: string,
          isRegex: boolean) {

    if (this.subscription) {
      this.subscription.unsubscribe();
    }
    this.list.page = 0;

    const auditLogStreamCreator2 = (query) => this.auditLogService.getFilteredList(
      {
        ...query,
        userName: userName,
        clientIpAddress: clientIpAddress,
        httpStatusCode: httpStatusCode,
        url: url,
        httpMethod: httpMethod,
        hasExceptions: hasExceptions,
        isRegex: isRegex
      });

    this.subscription = this.list.hookToQuery(auditLogStreamCreator2).subscribe((response) => {
      this.auditLogs = response

      this.parsing("exceptions");
    }
    )
  };

}
