# AuditViewer
A project that could show the ABP's Audit Logs table and Audit Log Actions that is bound to that specific log with a nice UI.


In order to use the app you will need a database created by ABP Framework.

You can create the DB by a couple ways.
You either can create a new project with the given command on ABP website, run the migrator and bind that DB to the project.
Or you could configurate the DB settings for your own DB.

Once you have the AbpAuditLogs and AbpAuditLogActions table in your DB it should work flawless.

This code is configured to use PostgreSQL but it can be changed by a couple configurations.
Refer to the ABP website for further instructions.
https://docs.abp.io/en/abp/4.4/Entity-Framework-Core-Other-DBMS


![AuditViewer](https://user-images.githubusercontent.com/64156908/149792115-6bb5d71b-b6fa-448e-b659-289dfa57fff5.gif)
