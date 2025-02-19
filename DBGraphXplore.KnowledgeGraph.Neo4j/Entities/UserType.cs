namespace DBGraphXplore.KnowledgeGraph.Neo4j.Entities
{
    public class UserType
    {
        /// <summary>
        /// A unique identifier for each Type object.
        /// </summary>
        public int Id { get; set; }
        public string ObjectId { get; set; }
        public string DatabaseName { get; set; }

        /// <summary>
        /// The schema under which the object resides (useful for organizing and visualizing objects within databases).
        /// </summary>
        public string SchemaName { get; set; }

        /// <summary>
        /// The name of the Type
        /// </summary>
        public string Name { get; set; }
    } 
}
