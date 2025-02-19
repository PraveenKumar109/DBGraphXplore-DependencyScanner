namespace DBGraphXplore.DatabaseScanner.Entities
{
    public class SqlTable
    {
        public string ObjectId { get; set; }
        public string DatabaseName { get; set; }
        public string Type { get; set; }
        public string TypeDescription { get; set; }
        public string SchemaName { get; set; }
        public string TableName { get; set; }
    }

}
