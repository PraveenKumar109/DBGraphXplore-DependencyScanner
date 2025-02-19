namespace DBGraphXplore.KnowledgeGraph.Neo4j.Entities
{
    public class Key
    {
        /// <summary>
        /// A unique identifier for each object.
        /// </summary>
        public int Id { get; set; }

        public string DatabaseName { get; set; }
        public string TableObjectId { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
    }
}
