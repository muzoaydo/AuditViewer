import { ListService } from '@abp/ng.core';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  @Input() selectedLog;

  detailsArr= [
    { label: "Id", value: "id", name: "::id", prop: "id", width: 30, type: '' },
    { label: "User Id", value: "userId", name: "::userId", prop: "userId", width: 30 , type: ""},
    { label: "User Name", value: "userName", name: "::userName", prop: "userName", width: 30, type: ""},
    { label: "Application Name", value: "applicationName", name: "::applicationName", prop: "applicationName", width: 30, type: "" },
    { label: "Http Status Code", value: "httpStatusCode", name: "::httpStatusCode", prop: "httpStatusCode", width: 30, type: ""},
    { label: "Http Method", value: "httpMethod", name: "::httpMethod", prop: "httpMethod", width: 30, type: "" },
    { label: "Url", value: "url", name: "::url", prop: "url", width: 30, type: "" },
    { label: "Execution Time", value: "executionTime", name: "::executionTime", prop: "executionTime", width: 30, type: "" },
    { label: "Client Id", value: "clientId", name: "::clientId", prop: "clientId", width: 30, type: "" },
    { label: "Client Name", value: "clientName", name: "::clientName", prop: "clientName", width: 30, type: ""},
    { label: "Client Ip Address", value: "clientIpAddress", name: "::clientIpAddress", prop: "clientIpAddress", width: 30 , type: ""},
    { label: "Browser Info", value: "browserInfo", name: "::browserInfo", prop: "browserInfo", width: 30, type: "" },
    { label: "Creator Id", value: "creatorId", name: "::creatorId", prop: "creatorId", width: 30, type: '' },
    { label: "Tenant Id", value: "tenantId", name: "::tenantId", prop: "tenantId", width: 30, type: "" },
    { label: "Tenant Name", value: "tenantName", name: "::tenantName", prop: "tenantName", width: 30, type: "" },
    { label: "Impersonator User Id", value: "impersonatorUserId", name: "::impersonatorUserId", prop: "impersonatorUserId", width: 30, type: "" },
    { label: "Impersonator Tenant Id", value: "impersonatorTenantId", name: "::impersonatorTenantId", prop: "impersonatorTenantId", width: 30, type: "" },
    { label: "Execution Duration", value: "executionDuration", name: "::executionDuration", prop: "executionDuration", width: 30, type: '' },
    { label: "Correlation Id", value: "correlationId", name: "::correlationId", prop: "correlationId", width: 30, type: "" },
    { label: "Comments", value: "comments", name: "::comments", prop: "comments", width: 30 , type: ""},
    { label: "Entity Changes", value: "entityChanges", name: "::entityChanges", prop: "entityChanges", width: 30, type: "" },
    { label: "Last Modification Time", value: "lastModificationTime", name: "::lastModificationTime", prop: "lastModificationTime", width: 30, type: "" },
    { label: "Last Modifier Id", value: "lastModifierId", name: "::lastModifierId", prop: "lastModifierId", width: 30, type: "" },
    ]
    

  constructor(public readonly list: ListService) { }

  ngOnInit(): void {

    
  }

}
