namespace AuditViewer.Permissions
{
    public static class AuditViewerPermissions
    {
        public const string GroupName = "AuditViewer";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public static class AuditLogs
        {
            public const string Default = GroupName + ".AuditLogs";

        }
    }
}