namespace DBGraphXplore.DatabaseScanner.Entities
{
    public class SqlTableColumn
    {
        public string ObjectId { get; set; }
        public string DatabaseName { get; set; }
        public string SchemaName { get; set; }
        public string TableName { get; set; }
        public string ColumnId { get; set; }
        public string ColumnName { get; set; }
        public string ColumnTypeId { get; set; }
        public string ColumnTypeName { get; set; }
    }

}
