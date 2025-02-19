namespace DBGraphXplore.DatabaseScanner.Entities
{
    public class SqlTableColumnDependency
    {
        public string DatabaseName { get; set; }
        public string SchemaName { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public string ReferencedDatabaseName { get; set; }
        public string ReferencedSchemaName { get; set; }
        public string ReferencedTableName { get; set; }
        public string ReferencedColumnName { get; set; }
        public string ReferencedObjectType { get; set; }
        public string IsSelected { get; set; }
        public string IsUpdated { get; set; }
    }
}
