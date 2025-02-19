using DBGraphXplore.KnowledgeGraph.Neo4j.Entities;

namespace DBGraphXplore.KnowledgeGraph.Neo4j.Data
{
    public class ObjectGraphData
    {
        public List<Database> Databases { get; set; } = [];
        public List<DatabaseObject> DatabaseObjects { get; set; } = [];

        public List<Table> Tables { get; set; } = [];
        public List<Column> Columns { get; set; } = [];
        public List<Key> Keys { get; set; } = [];
        public List<TableIndex> TableIndexes { get; set; } = [];

        public List<UserType> UserTypes { get; set; } = [];
        public List<View> Views { get; set; } = [];
        public List<Function> Functions { get; set; } = [];
        public List<StoredProcedure> StoredProcedures { get; set; } = [];
        public List<InlineTableValuedFunction> InlineTableValuedFunctions { get; set; } = [];
        public List<TableValuedFunction> TableValuedFunctions { get; set; } = [];

        public List<Relationship> Relationships { get; set; } = [];


        public Database GetDatabase(string name)
        {
            return Databases.FirstOrDefault(d => d.Name.ToLower() == name.ToLower());
        }

        public bool DatabaseExist(string name)
        {
            return Databases.Exists(d => d.Name.ToLower() == name.ToLower());
        }

        internal bool DatabaseObjectExist(string database, string name)
        {
            return DatabaseObjects.Exists(d => d.DatabaseName.ToLower() == database.ToLower() && d.Name.ToLower() == name.ToLower());
        }

        internal DatabaseObject GetDatabaseObject(string database, string name)
        {
            return DatabaseObjects.FirstOrDefault(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal bool TableExist(string database, string name)
        {
            return Tables.Exists(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal Table GetTable(string database, string name)
        {
            return Tables.FirstOrDefault(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal bool UserTypeExist(string database, string name)
        {
            return UserTypes.Exists(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal UserType GetUserType(string database, string name)
        {
            return UserTypes.FirstOrDefault(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal bool ViewExist(string database, string name)
        {
            return Views.Exists(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal View GetView(string database, string name)
        {
            return Views.FirstOrDefault(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal bool FunctionExist(string database, string name)
        {
            return Functions.Exists(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal Function GetFunction(string database, string name)
        {
            return Functions.FirstOrDefault(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal bool StoredProcedureExist(string database, string name)
        {
            return StoredProcedures.Exists(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal StoredProcedure GetStoredProcedure(string database, string name)
        {
            return StoredProcedures.FirstOrDefault(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal bool InlineTableValuedFunctionExist(string database, string name)
        {
            return InlineTableValuedFunctions.Exists(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal InlineTableValuedFunction GetInlineTableValuedFunction(string database, string name)
        {
            return InlineTableValuedFunctions.FirstOrDefault(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal bool TableValuedFunctionExist(string database, string name)
        {
            return TableValuedFunctions.Exists(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }

        internal TableValuedFunction GetTableValuedFunction(string database, string name)
        {
            return TableValuedFunctions.FirstOrDefault(d => d.DatabaseName.ToLower() == database.ToLower() &&  d.Name.ToLower() == name.ToLower());
        }


        internal bool ColumnExist(string database, string tableName, string columnName)
        {
            return Columns.Exists(d => d.DatabaseName.ToLower() == database.ToLower() && d.TableName.ToLower() == tableName.ToLower()  && d.Name.ToLower() == columnName.ToLower());
        }

        internal Column GetColumn(string database, string tableName, string columnName)
        {
            return Columns.FirstOrDefault(d => d.DatabaseName.ToLower() == database.ToLower() && d.TableName.ToLower() == tableName.ToLower() && d.Name.ToLower() == columnName.ToLower());
        }

        internal bool KeyExist(string database, string tableName, string keyName)
        {
            return Keys.Exists(d => d.DatabaseName.ToLower() == database.ToLower() && d.TableName.ToLower() == tableName.ToLower() && d.Name.ToLower() == keyName.ToLower());
        }

        internal Key GetKey(string database, string tableName, string keyName)
        {
            return Keys.FirstOrDefault(d => d.DatabaseName.ToLower() == database.ToLower() && d.TableName.ToLower() == tableName.ToLower() && d.Name.ToLower() == keyName.ToLower());
        }



        internal bool TableIndexExist(string database, string tableName, string tableIndexName)
        {
            return TableIndexes.Exists(d => d.DatabaseName.ToLower() == database.ToLower() && d.TableName.ToLower() == tableName.ToLower() && d.Name.ToLower() == tableIndexName.ToLower());
        }

        internal TableIndex GetTableIndex(string database, string tableName, string tableIndexName)
        {
            return TableIndexes.FirstOrDefault(d => d.DatabaseName.ToLower() == database.ToLower() && d.TableName.ToLower() == tableName.ToLower() && d.Name.ToLower() == tableIndexName.ToLower());
        }








        internal bool RelationshipExist(int sourceNodeId, string relationName, int destinationNodeId)
        {
            return Relationships.Exists(d => d.SourceNodeId == sourceNodeId && d.RelationName == relationName && d.DestinationNodeId == destinationNodeId);
        }
    }
}
