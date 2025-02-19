namespace DBGraphXplore.DatabaseScanner.Entities
{
    public class ReferencingObject
    {
        public string SourceObjectId { get; set; } = "";
        public string SourceDatabaseName { get; set; } = "";    
        public string SourceObjectSchemaName { get; set; } = "";
        public string SourceObjectType { get; set; } = "";
        public string SourceObjectName { get; set; } = "";

       
        public string DependentObjectId { get; set; } = "";

        /// <summary>
        /// Description of the object type:
        /// AGGREGATE_FUNCTION
        /// CHECK_CONSTRAINT
        /// CLR_SCALAR_FUNCTION
        /// CLR_STORED_PROCEDURE
        /// CLR_TABLE_VALUED_FUNCTION
        /// CLR_TRIGGER
        /// DEFAULT_CONSTRAINT
        /// EDGE_CONSTRAINT
        /// EXTENDED_STORED_PROCEDURE
        /// FOREIGN_KEY_CONSTRAINT
        /// INTERNAL_TABLE
        /// PLAN_GUIDE
        /// PRIMARY_KEY_CONSTRAINT
        /// REPLICATION_FILTER_PROCEDURE
        /// RULE
        /// SEQUENCE_OBJECT
        /// SERVICE_QUEUE
        /// SQL_INLINE_TABLE_VALUED_FUNCTION
        /// SQL_SCALAR_FUNCTION
        /// SQL_STORED_PROCEDURE
        /// SQL_TABLE_VALUED_FUNCTION
        /// SQL_TRIGGER
        /// SYNONYM
        /// SYSTEM_TABLE
        /// TYPE_TABLE
        /// UNIQUE_CONSTRAINT
        /// USER_TABLE
        /// VIEW
        /// </summary>
        public string DependentObjectType { get; set; } = "";

        /// <summary>
        /// Description of class of referenced entity.
        /// OBJECT_OR_COLUMN
        /// TYPE
        /// XML_SCHEMA_COLLECTION
        /// PARTITION_FUNCTION
        /// Is not nullable.
        /// </summary>
        public string DependentObjectClassDescription { get; set; } = "";

        /// <summary>
        /// Name of the database of the referenced entity.
        /// This column is populated for cross-database or cross-server references that are made by specifying a valid three-part or four-part name. 
        /// NULL for non-schema-bound references when specified using a one-part or two-part name.
        /// NULL for schema-bound entities because they must be in the same database and therefore can only be defined using a two-part(schema.object) name.
        /// </summary>
        public string DependentObjectDatabaseName { get; set; } = "";

        /// <summary>
        /// Schema in which the referenced entity belongs.
        /// NULL for non-schema-bound references in which the entity was referenced without specifying the schema name.
        /// Never NULL for schema-bound references because schema-bound entities must be defined and referenced by using a two-part name.
        /// </summary>
        public string DependentObjectSchemaName { get; set; } = "";

        /// <summary>
        /// Name of the referenced entity. Is not nullable.
        /// </summary>
        public string DependentObjectName { get; set; } = "";           
    }
}
