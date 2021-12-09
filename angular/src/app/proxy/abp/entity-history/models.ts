import type { Entity } from '../domain/entities/models';
import type { EntityChangeType } from '../events/bus/entities/entity-change-type.enum';

export interface EntityChange extends Entity<number> {
  changeTime?: string;
  changeType: EntityChangeType;
  entityChangeSetId: number;
  entityId?: string;
  entityTypeFullName?: string;
  tenantId?: number;
  propertyChanges: EntityPropertyChange[];
  entityEntry: object;
}

export interface EntityPropertyChange extends Entity<number> {
  entityChangeId: number;
  newValue?: string;
  originalValue?: string;
  propertyName?: string;
  propertyTypeFullName?: string;
  tenantId?: number;
  newValueHash?: string;
  originalValueHash?: string;
}
