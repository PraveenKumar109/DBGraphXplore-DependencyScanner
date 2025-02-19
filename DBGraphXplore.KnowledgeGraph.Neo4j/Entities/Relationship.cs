namespace DBGraphXplore.KnowledgeGraph.Neo4j.Entities
{
    public class Relationship
    {
        /// <summary>
        ///  A unique identifier for the relationship.
        /// </summary>
        public int Id { get; set; }

        public string SourceNodeName { get; set; }

        public int SourceNodeId { get; set; }

        /// <summary>
        /// Describes the type of relationship (e.g., depends).
        /// </summary>
        public string RelationName { get; set; }

        public string DestinationNodeName { get; set; }

        /// <summary>
        /// The ID of the referenced object (e.g., the table that a procedure depends on).
        /// </summary>
        public int DestinationNodeId { get; set; }
    }

}
