namespace DBGraphXplore.DatabaseScanner.Entities
{
    public class SqlTableIndex
    {
        public string DatabaseName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TableObjectId { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string ColumnOrder { get; set; }
        public string IsIncludedColumn { get; set; }
        public string IsPrimaryKey { get; set; }
        public string IsUniqueConstraint { get; set; }
    }

}
