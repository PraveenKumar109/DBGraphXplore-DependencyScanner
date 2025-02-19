using DBGraphXplore.DatabaseScanner.Entities;
using DBGraphXplore.KnowledgeGraph.Neo4j.Data;
using DBGraphXplore.KnowledgeGraph.Neo4j.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGraphXplore.KnowledgeGraph.Neo4j.DataHelper
{
    public class Neo4JDataHelper
    {
        private string uri;
        private string user;
        private string password;

        public Neo4JDataHelper(string uri, string user, string password)
        {
            this.uri = uri;
            this.user = user;
            this.password = password;
        }

        public async Task UploadDataToNeo4J(ScannedData scannedData)
        {
            var dataTransformer = new DataTransformer();
            var objectGraphData = dataTransformer.Transform(scannedData);

            var neo4JDataIngestor = new Neo4JDataHelper(uri, user, password);
            await InsertObjectGraphData(objectGraphData);
        }

        private async Task InsertObjectGraphData(ObjectGraphData objectGraphData)
        {
            using (var repository = new Neo4jRepository(uri, user, password))
            {
                // Create a new database node
                foreach (var database in objectGraphData.Databases)
                {
                    await repository.Insert_DatabaseAsync(database);
                }

                // Create a new user table node
                foreach (var table in objectGraphData.Tables)
                {
                    await repository.Insert_TableAsync(table);
                }

                foreach (var column in objectGraphData.Columns)
                {
                    await repository.Insert_ColumnAsync(column);
                }
                foreach (var key in objectGraphData.Keys)
                {
                    await repository.Insert_KeyAsync(key);
                }
                foreach (var tableIndex in objectGraphData.TableIndexes)
                {
                    await repository.Insert_TableIndexAsync(tableIndex);
                }




                // Create a new UserType node
                foreach (var userType in objectGraphData.UserTypes)
                {
                    await repository.Insert_UserTypeAsync(userType);
                }

                foreach (var view in objectGraphData.Views)
                {
                    await repository.Insert_ViewAsync(view);
                }

                foreach (var storedProcedure in objectGraphData.StoredProcedures)
                {
                    await repository.Insert_StoredProcedureAsync(storedProcedure);
                }

                foreach (var function in objectGraphData.Functions)
                {
                    await repository.Insert_FunctionAsync(function);
                }

                foreach (var inlineTableValuedFunction in objectGraphData.InlineTableValuedFunctions)
                {
                    await repository.Insert_InlineTableValuedFunctionAsync(inlineTableValuedFunction);
                }

                foreach (var tableValuedFunction in objectGraphData.TableValuedFunctions)
                {
                    await repository.Insert_TableValuedFunctionAsync(tableValuedFunction);
                }

                // Create a new database object node
                foreach (var databaseObject in objectGraphData.DatabaseObjects)
                {
                    await repository.Insert_DatabaseObjectAsync(databaseObject);
                }

                // Create a new database object relation
                foreach (var relationship in objectGraphData.Relationships)
                {
                    await repository.Insert_RelationAsync(relationship);
                }


                // Create indexes to optimize performance
                //await repository.CreateIndexesAsync();
            }
        }
    }
}
