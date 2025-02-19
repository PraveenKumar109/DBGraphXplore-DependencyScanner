namespace DBGraphXplore.DatabaseScanner.Entities
{
    public class SqlKeyConstraint
    {
        public string DatabaseName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TypeDescription { get; set; }

        public string ObjectId { get; set; }
        public string TableName { get; set; }
        public string ColumnId { get; set; }
        public string ColumnName { get; set; }
    }
}
