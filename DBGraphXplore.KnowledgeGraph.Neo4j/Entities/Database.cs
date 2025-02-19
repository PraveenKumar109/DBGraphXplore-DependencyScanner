namespace DBGraphXplore.KnowledgeGraph.Neo4j.Entities
{
    /// <summary>
    /// This class represents a Database node in Neo4j, which is a good starting point for grouping related objects 
    /// (like procedures, tables, etc.).
    /// </summary>
    public class Database
    {
        /// <summary>
        /// A unique identifier for each database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the database.
        /// </summary>
        public string Name { get; set; }
    }

}
