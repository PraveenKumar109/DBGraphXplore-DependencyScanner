namespace DBGraphXplore.DatabaseScanner.Entities
{
    public class SqlForeignKeyConstraint
    {
        public string DatabaseName { get; set; }

        public string Name { get; set; }
        public string Type { get; set; } = "FK";
        public string TypeDescription { get; set; } = "FOREIGN_KEY_CONSTRAINT";

        public string ForeignKeyTableObjectId { get; set; }
        public string ForeignKeyTableName { get; set; }
        public string ForeignKeyColumnName { get; set; }

        public string PrimaryKeyTableObjectId { get; set; }
        public string PrimaryKeyTableName { get; set; }
        public string PrimaryKeyColumnName { get; set; }
    }
}
