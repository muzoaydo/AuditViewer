import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/AuditViewer',
        name: '::Menu:AuditViewer',
        iconClass: 'fas fa-align-justify',
        order: 2,
        layout: eLayoutType.application
      },
      {
        path: '/auditlogs',
        name: '::Menu:AuditLogs',
        iconClass: 'fas fa-align-justify',
        parentName: '::Menu:AuditViewer',
        layout: eLayoutType.application,
        requiredPolicy: 'AuditViewer.AuditLogs'
      }
    ]);
  };
}
