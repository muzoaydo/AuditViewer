import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuditlogRoutingModule } from './auditlog-routing.module';
import { AuditlogComponent } from './auditlog.component';
import { AuditLogActionsComponent } from './audit-log-actions/audit-log-actions.component';
import { DetailsComponent } from './details/details.component';


@NgModule({
  declarations: [
    AuditlogComponent,
    AuditLogActionsComponent,
    DetailsComponent
  ],
  imports: [
    CommonModule,
    AuditlogRoutingModule
  ]
})
export class AuditlogModule { }
