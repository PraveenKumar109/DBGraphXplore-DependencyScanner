namespace DBGraphXplore.KnowledgeGraph.Neo4j.Entities
{
    /// <summary>
    /// This class represents individual objects within a database, which can be nodes in Neo4j with specific properties 
    /// like ObjectType and SchemaName.
    /// </summary>
    public class DatabaseObject
    {
        /// <summary>
        /// A unique identifier for each database object.
        /// </summary>
        public int Id { get; set; }
        public string ObjectId { get; set; }
        public string DatabaseName { get; set; }

        /// <summary>
        /// The schema under which the object resides (useful for organizing and visualizing objects within databases).
        /// </summary>
        public string SchemaName { get; set; }

        /// <summary>
        /// The type of the object (e.g., Table, Procedure), which is critical for filtering and visualization in Neo4j.
        /// </summary>
        public string ObjectType { get; set; }

        /// <summary>
        /// The name of the object, which is essential for node labeling in Neo4j.
        /// </summary>
        public string Name { get; set; }
    }
}
