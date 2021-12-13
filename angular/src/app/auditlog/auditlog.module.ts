import { NgModule } from '@angular/core';

import { AuditlogRoutingModule } from './auditlog-routing.module';
import { AuditlogComponent } from './auditlog.component';
import { AuditLogActionsComponent } from './audit-log-actions/audit-log-actions.component';
import { DetailsComponent } from './details/details.component';
import { SharedModule } from '../shared/shared.module';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [
    AuditlogComponent,
    AuditLogActionsComponent,
    DetailsComponent
  ],
  imports: [
    SharedModule,
    AuditlogRoutingModule,
    MatButtonModule
  ]
})
export class AuditlogModule { }
