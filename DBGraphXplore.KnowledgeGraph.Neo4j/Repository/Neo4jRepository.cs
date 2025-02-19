using Neo4j.Driver;
using DBGraphXplore.KnowledgeGraph.Neo4j.Entities;

namespace DBGraphXplore.KnowledgeGraph.Neo4j.Repository
{
    public class Neo4jRepository : IDisposable
    {
        private readonly IDriver _driver;

        public Neo4jRepository(string uri, string user, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
        }

        // Method to Insert a Database Node
        public async Task Insert_DatabaseAsync(Database item)
        {
            var query = "CREATE (d:Database {Id: $Id, Name: $Name})";
            var parameters = new { item.Id, item.Name };

            await ExecuteWriteQueryAsync(query, parameters);
        }

        // Method to Insert a DatabaseObject Node
        public async Task Insert_DatabaseObjectAsync(DatabaseObject item)
        {
            var query = "CREATE (o:DatabaseObject {Id: $Id, DatabaseName: $DatabaseName, SchemaName: $SchemaName, ObjectType: $ObjectType, Name: $Name})";
            var parameters = new { item.Id, item.DatabaseName, item.SchemaName, item.ObjectType, item.Name };

            await ExecuteWriteQueryAsync(query, parameters);
        }


        internal async Task Insert_TableAsync(Table item)
        {
            var query = "CREATE (d:Table {Id: $Id, DatabaseName: $DatabaseName, SchemaName: $SchemaName, Name: $Name})";
            var parameters = new { item.Id, item.DatabaseName, item.SchemaName, item.Name };

            await ExecuteWriteQueryAsync(query, parameters);
        }
        internal async Task Insert_ColumnAsync(Column item)
        {
            var query = "CREATE (d:Column {Id:$Id, DatabaseName:$DatabaseName, SchemaName:$SchemaName, TableObjectId:$TableObjectId, TableName:$TableName, Name:$Name, Type:$Type})";
            var parameters = new { item.Id, item.DatabaseName, item.SchemaName, item.TableObjectId, item.TableName, item.Name, item.Type };

            await ExecuteWriteQueryAsync(query, parameters);
        }

        internal async Task Insert_KeyAsync(Key item)
        {
            var query = "CREATE (d:Key {Id:$Id, DatabaseName:$DatabaseName, TableObjectId:$TableObjectId, TableName:$TableName, Name:$Name, Type:$Type})";
            var parameters = new { item.Id, item.DatabaseName, item.TableObjectId, item.TableName, item.Name, item.Type };

            await ExecuteWriteQueryAsync(query, parameters);
        }

        internal async Task Insert_TableIndexAsync(TableIndex item)
        {
            var query = "CREATE (d:TableIndex {Id:$Id, DatabaseName:$DatabaseName, TableObjectId:$TableObjectId, TableName:$TableName, Name:$Name, Type:$Type, IsIncludedColumn:$IsIncludedColumn, IsPrimaryKey:$IsPrimaryKey, IsUniqueConstraint:$IsUniqueConstraint})";
            var parameters = new { item.Id, item.DatabaseName, item.TableObjectId, item.TableName, item.Name, item.Type, item.IsIncludedColumn, item.IsPrimaryKey, item.IsUniqueConstraint };

            await ExecuteWriteQueryAsync(query, parameters);
        }



        internal async Task Insert_UserTypeAsync(UserType item)
        {
            var query = "CREATE (d:Type {Id: $Id, DatabaseName: $DatabaseName, SchemaName: $SchemaName, Name: $Name})";
            var parameters = new { item.Id, item.DatabaseName, item.SchemaName, item.Name };

            await ExecuteWriteQueryAsync(query, parameters);
        }

        internal async Task Insert_ViewAsync(View item)
        {
            var query = "CREATE (d:View {Id: $Id, DatabaseName: $DatabaseName, SchemaName: $SchemaName, Name: $Name})";
            var parameters = new { item.Id, item.DatabaseName, item.SchemaName, item.Name };

            await ExecuteWriteQueryAsync(query, parameters);
        }

        internal async Task Insert_StoredProcedureAsync(StoredProcedure item)
        {
            var query = "CREATE (d:StoredProcedure {Id: $Id, DatabaseName: $DatabaseName, SchemaName: $SchemaName, Name: $Name})";
            var parameters = new { item.Id, item.DatabaseName, item.SchemaName, item.Name };

            await ExecuteWriteQueryAsync(query, parameters);
        }

        internal async Task Insert_FunctionAsync(Function item)
        {
            var query = "CREATE (d:Function {Id: $Id, DatabaseName: $DatabaseName, SchemaName: $SchemaName, Name: $Name})";
            var parameters = new { item.Id, item.DatabaseName, item.SchemaName, item.Name };

            await ExecuteWriteQueryAsync(query, parameters);
        }

        internal async Task Insert_TableValuedFunctionAsync(TableValuedFunction item)
        {
            var query = "CREATE (d:TableValuedFunction {Id: $Id, DatabaseName: $DatabaseName, SchemaName: $SchemaName, Name: $Name})";
            var parameters = new { item.Id, item.DatabaseName, item.SchemaName, item.Name };

            await ExecuteWriteQueryAsync(query, parameters);
        }
        internal async Task Insert_InlineTableValuedFunctionAsync(InlineTableValuedFunction item)
        {
            var query = "CREATE (d:InlineTableValuedFunction {Id: $Id,DatabaseName: $DatabaseName, SchemaName: $SchemaName, Name: $Name})";
            var parameters = new { item.Id, item.DatabaseName, item.SchemaName, item.Name };

            await ExecuteWriteQueryAsync(query, parameters);
        }


        internal async Task Insert_RelationAsync(Relationship relationship)
        {
            var query = "MATCH"
                  + " (source:"+ relationship.SourceNodeName + " {Id: " + relationship.SourceNodeId + "}),"
                  + " (target:"+ relationship.DestinationNodeName + " {Id: " + relationship.DestinationNodeId + "})"
                  + " CREATE (source)-[:"+ relationship.RelationName + "]->(target)";

            await ExecuteWriteQueryAsync(query);
        }


        // Method to Create Indexes
        public async Task CreateIndexesAsync()
        {
            // Create index for Database Id
            await ExecuteWriteQueryAsync("CREATE CONSTRAINT IF NOT EXISTS ON (d:Database) ASSERT d.Id IS UNIQUE;", null);

            // Create index for DatabaseObject Id
            await ExecuteWriteQueryAsync("CREATE CONSTRAINT IF NOT EXISTS ON (o:DatabaseObject) ASSERT o.Id IS UNIQUE;", null);

            // Create index for DatabaseObject ObjectName
            await ExecuteWriteQueryAsync("CREATE INDEX IF NOT EXISTS FOR (o:DatabaseObject) ON (o.ObjectName);", null);

            // Create index for Database DatabaseName
            await ExecuteWriteQueryAsync("CREATE INDEX IF NOT EXISTS FOR (d:Database) ON (d.DatabaseName);", null);
        }


        // Method to Execute Write Queries
        private async Task ExecuteWriteQueryAsync(string query, object parameters)
        {
            var session = _driver.AsyncSession(o => o.WithDefaultAccessMode(AccessMode.Write));
            try
            {
                await session.ExecuteWriteAsync(async tx =>
                {
                    await tx.RunAsync(query, parameters);
                });
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        // Method to Execute Write Queries
        private async Task ExecuteWriteQueryAsync(string query)
        {
            var session = _driver.AsyncSession(o => o.WithDefaultAccessMode(AccessMode.Write));
            try
            {
                await session.ExecuteWriteAsync(async tx =>
                {
                    await tx.RunAsync(query);
                });
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }
    }

}
