import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuditLogActionsComponent } from './audit-log-actions.component';

describe('AuditLogActionsComponent', () => {
  let component: AuditLogActionsComponent;
  let fixture: ComponentFixture<AuditLogActionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuditLogActionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuditLogActionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
