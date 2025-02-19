namespace DBGraphXplore.KnowledgeGraph.Neo4j.Entities
{
    public class TableIndex
    {
        public int Id { get; set; }
        public string DatabaseName { get; set; }
        public string TableObjectId { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string IsIncludedColumn { get; set; }
        public string IsPrimaryKey { get; set; }
        public string IsUniqueConstraint { get; set; }
    }

}
