import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'AuditViewer',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44364',
    redirectUri: baseUrl,
    clientId: 'AuditViewer_App',
    responseType: 'code',
    scope: 'offline_access openid profile role email phone AuditViewer',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44364',
      rootNamespace: 'AuditViewer',
    },
  },
} as Environment;
