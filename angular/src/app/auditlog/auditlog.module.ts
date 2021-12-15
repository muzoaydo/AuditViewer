import { NgModule } from '@angular/core';

import { AuditlogRoutingModule } from './auditlog-routing.module';
import { AuditlogComponent } from './auditlog.component';
import { AuditLogActionsComponent } from './audit-log-actions/audit-log-actions.component';
import { DetailsComponent } from './details/details.component';
import { SharedModule } from '../shared/shared.module';
import { MatButtonModule } from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';



@NgModule({
  declarations: [
    AuditlogComponent,
    AuditLogActionsComponent,
    DetailsComponent,
  ],
  imports: [
    SharedModule,
    AuditlogRoutingModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule
  ]
})
export class AuditlogModule { }
