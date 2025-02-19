namespace DBGraphXplore.DatabaseScanner.Entities
{
    public class SqlObject
    {
        public string ObjectId { get; set; }
        public string ParentObjectId { get; set; }
        public string DatabaseName { get; set; }
        public string Type { get; set; }
        public string TypeDescription { get; set; }
        public string SchemaName { get; set; }
        public string Name { get; set; }
    }

}
