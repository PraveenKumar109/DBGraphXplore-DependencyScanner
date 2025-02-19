using DBGraphXplore.DatabaseScanner.Entities;
using DBGraphXplore.KnowledgeGraph.Neo4j.Data;
using DBGraphXplore.KnowledgeGraph.Neo4j.Entities;
namespace DBGraphXplore.KnowledgeGraph.Neo4j.DataHelper
{
    public class DataTransformer
    {
        private int indexCounter = 1;
        private ObjectGraphData objectGraphData = new();

        public DataTransformer() { }

        public ObjectGraphData Transform(ScannedData scannedData)
        {
            objectGraphData = new ObjectGraphData();
            AddDatabases(scannedData.ReferencingObjects);
            AddSourceDatabaseObjectAndRelations(scannedData.ReferencingObjects);
            AddDependentDatabaseObjectAndRelations(scannedData.ReferencingObjects);

            AddTableColumnAndRelations(scannedData.SqlTableColumns);
            AddKeyAndRelations(scannedData.SqlKeyConstraints);
            AddKeyAndRelations(scannedData.SqlForeignKeyConstraints);
            AddTableIndexAndRelations(scannedData.SqlTableIndexes);
            AddStoredProcedureTableColumnRelations(scannedData.SqlTableColumnDependencies);

            return objectGraphData;
        }

        private void AddStoredProcedureTableColumnRelations(List<SqlTableColumnDependency> sqlTableColumnDependencies)
        {
            var tableColumnDependencyList = new List<string>();
            foreach (var sqlTableColumnDependency in sqlTableColumnDependencies)
            {
                var columnObject = objectGraphData.GetColumn(sqlTableColumnDependency.ReferencedDatabaseName, sqlTableColumnDependency.ReferencedTableName, sqlTableColumnDependency.ReferencedColumnName);
                if (columnObject == null)
                {
                    continue;
                }


                if (sqlTableColumnDependency.ObjectType == "SQL_STORED_PROCEDURE")
                {
                    var storedProcedureObject = objectGraphData.GetStoredProcedure(sqlTableColumnDependency.DatabaseName, sqlTableColumnDependency.ObjectName);
                    if (storedProcedureObject != null)
                    {
                        if (sqlTableColumnDependency.IsUpdated.ToLower() == "true")
                        {
                            this.AddRelationship("StoredProcedure", storedProcedureObject.Id, "WRITE", "Column", columnObject.Id);

                            var key = (sqlTableColumnDependency.DatabaseName + "." + sqlTableColumnDependency.ObjectName + "." + sqlTableColumnDependency.ReferencedTableName+ ".IsUpdated").ToLower();
                            if (!tableColumnDependencyList.Exists(t => t.ToLower() == key))
                            {
                                var tableObject = objectGraphData.GetTable(sqlTableColumnDependency.ReferencedDatabaseName, sqlTableColumnDependency.ReferencedTableName);
                                if (tableObject != null)
                                {
                                    AddRelationship("StoredProcedure", storedProcedureObject.Id, "MODIFY_DATA", "Table", tableObject.Id);
                                    tableColumnDependencyList.Add(key);
                                }
                            }
                        }
                        if (sqlTableColumnDependency.IsSelected.ToLower() == "true")
                        {
                            this.AddRelationship("StoredProcedure", storedProcedureObject.Id, "READ", "Column", columnObject.Id);

                            var key = (sqlTableColumnDependency.DatabaseName + "." + sqlTableColumnDependency.ObjectName + "." + sqlTableColumnDependency.ReferencedTableName + ".IsSelected").ToLower();
                            if (!tableColumnDependencyList.Exists(t => t.ToLower() == key))
                            {
                                var tableObject = objectGraphData.GetTable(sqlTableColumnDependency.ReferencedDatabaseName, sqlTableColumnDependency.ReferencedTableName);
                                if (tableObject != null)
                                {
                                    AddRelationship("StoredProcedure", storedProcedureObject.Id, "SELECT_DATA", "Table", tableObject.Id);
                                    tableColumnDependencyList.Add(key);
                                }
                            }
                        }
                    }
                }
                else if (sqlTableColumnDependency.ObjectType == "VIEW")
                {
                    var viewObject = objectGraphData.GetView(sqlTableColumnDependency.DatabaseName, sqlTableColumnDependency.ObjectName);
                    if (viewObject != null)
                    {
                        if (sqlTableColumnDependency.IsUpdated.ToLower() == "true")
                        {
                            AddRelationship("View", viewObject.Id, "WRITE", "Column", columnObject.Id);
                        }
                        if (sqlTableColumnDependency.IsSelected.ToLower() == "true")
                        {
                            AddRelationship("View", viewObject.Id, "READ", "Column", columnObject.Id);
                        }
                    }
                }
            }

        }

        private void AddTableColumnAndRelations(List<SqlTableColumn> sqlTableColumns)
        {
            foreach (var sqlTableColumn in sqlTableColumns)
            {
                var tableIndexId = objectGraphData.GetTable(sqlTableColumn.DatabaseName, sqlTableColumn.TableName).Id;
                var columnIndexId = -1;
                if (!objectGraphData.ColumnExist(sqlTableColumn.DatabaseName, sqlTableColumn.TableName, sqlTableColumn.ColumnName))
                {
                    columnIndexId = GetNextIndex();
                    objectGraphData.Columns.Add(
                        new Column
                        {
                            Id = columnIndexId,
                            DatabaseName = sqlTableColumn.DatabaseName,
                            SchemaName = sqlTableColumn.SchemaName,
                            TableObjectId = sqlTableColumn.ObjectId,
                            TableName = sqlTableColumn.TableName,
                            Name = sqlTableColumn.ColumnName,
                            Type = sqlTableColumn.ColumnTypeName,
                        });
                }
                else
                {
                    columnIndexId = objectGraphData.GetColumn(sqlTableColumn.DatabaseName, sqlTableColumn.TableName, sqlTableColumn.ColumnName).Id;
                }

                AddRelationship("Table", tableIndexId, "HAS_COLUMN", "Column", columnIndexId);

                var userType = objectGraphData.GetUserType(sqlTableColumn.DatabaseName, sqlTableColumn.ColumnTypeName);

                if (userType != null)
                {
                    AddRelationship("Column", columnIndexId, "HAS_TYPE", "Type", userType.Id);
                }
            }
        }

        private void AddKeyAndRelations(List<SqlKeyConstraint> sqlKeyConstraints)
        {
            foreach (var sqlKeyConstraint in sqlKeyConstraints)
            {
                var tableIndexId = objectGraphData.GetTable(sqlKeyConstraint.DatabaseName, sqlKeyConstraint.TableName).Id;
                var columnIndexId = objectGraphData.GetColumn(sqlKeyConstraint.DatabaseName, sqlKeyConstraint.TableName, sqlKeyConstraint.ColumnName).Id;
                var keyIndexId = -1;
                if (!objectGraphData.KeyExist(sqlKeyConstraint.DatabaseName, sqlKeyConstraint.TableName, sqlKeyConstraint.Name))
                {
                    keyIndexId = GetNextIndex();
                    objectGraphData.Keys.Add(
                        new Key
                        {
                            Id = keyIndexId,
                            DatabaseName = sqlKeyConstraint.DatabaseName,
                            TableObjectId = sqlKeyConstraint.ObjectId,
                            TableName = sqlKeyConstraint.TableName,
                            Name = sqlKeyConstraint.Name,
                            Type = sqlKeyConstraint.TypeDescription
                        });
                }
                else
                {
                    keyIndexId = objectGraphData.GetKey(sqlKeyConstraint.DatabaseName, sqlKeyConstraint.TableName, sqlKeyConstraint.Name).Id;
                }

                AddRelationship("Table", tableIndexId, "HAS_KEY", "Key", keyIndexId);
                AddRelationship("Key", keyIndexId, "HAS_" + sqlKeyConstraint.TypeDescription + "_ON", "Column", columnIndexId);
            }
        }
        private void AddKeyAndRelations(List<SqlForeignKeyConstraint> sqlForeignKeyConstraints)
        {
            foreach (var sqlForeignKeyConstraint in sqlForeignKeyConstraints)
            {
                var tableIndexId = objectGraphData.GetTable(sqlForeignKeyConstraint.DatabaseName, sqlForeignKeyConstraint.ForeignKeyTableName).Id;
                var foreignKeyColumnIndexId = objectGraphData.GetColumn(sqlForeignKeyConstraint.DatabaseName, sqlForeignKeyConstraint.ForeignKeyTableName, sqlForeignKeyConstraint.ForeignKeyColumnName).Id;
                var primaryKeyColumnIndexId = objectGraphData.GetColumn(sqlForeignKeyConstraint.DatabaseName, sqlForeignKeyConstraint.PrimaryKeyTableName, sqlForeignKeyConstraint.PrimaryKeyColumnName).Id;
                var keyIndexId = -1;
                if (!objectGraphData.KeyExist(sqlForeignKeyConstraint.DatabaseName, sqlForeignKeyConstraint.ForeignKeyTableName, sqlForeignKeyConstraint.Name))
                {
                    keyIndexId = GetNextIndex();
                    objectGraphData.Keys.Add(
                        new Key
                        {
                            Id = keyIndexId,
                            DatabaseName = sqlForeignKeyConstraint.DatabaseName,
                            TableObjectId = sqlForeignKeyConstraint.ForeignKeyTableObjectId,
                            TableName = sqlForeignKeyConstraint.ForeignKeyTableName,
                            Name = sqlForeignKeyConstraint.Name,
                            Type = sqlForeignKeyConstraint.TypeDescription
                        });
                }
                else
                {
                    keyIndexId = objectGraphData.GetKey(sqlForeignKeyConstraint.DatabaseName, sqlForeignKeyConstraint.ForeignKeyTableName, sqlForeignKeyConstraint.Name).Id;
                }

                AddRelationship("Table", tableIndexId, "HAS_KEY", "Key", keyIndexId);

                AddRelationship("Key", keyIndexId, "HAS_FOREIGN_KEY_CONSTRAINT_ON", "Column", foreignKeyColumnIndexId);
                AddRelationship("Key", keyIndexId, "HAS_PRIMARY_KEY_CONSTRAINT_ON", "Column", primaryKeyColumnIndexId);
            }
        }

        private void AddTableIndexAndRelations(List<SqlTableIndex> sqlTableIndexes)
        {
            foreach (var sqlTableIndex in sqlTableIndexes)
            {
                var tableIndexId = objectGraphData.GetTable(sqlTableIndex.DatabaseName, sqlTableIndex.TableName).Id;
                var columnIndexId = objectGraphData.GetColumn(sqlTableIndex.DatabaseName, sqlTableIndex.TableName, sqlTableIndex.ColumnName).Id;

                var tableIndex_IndexId = -1;
                if (!objectGraphData.TableIndexExist(sqlTableIndex.DatabaseName, sqlTableIndex.TableName, sqlTableIndex.Name))
                {
                    tableIndex_IndexId = GetNextIndex();
                    objectGraphData.TableIndexes.Add(
                        new TableIndex
                        {
                            Id = tableIndex_IndexId,
                            DatabaseName = sqlTableIndex.DatabaseName,
                            TableObjectId = sqlTableIndex.TableObjectId,
                            TableName = sqlTableIndex.TableName,
                            ColumnName = sqlTableIndex.ColumnName,

                            Name = sqlTableIndex.Name,
                            Type = sqlTableIndex.Type,
                            IsIncludedColumn = sqlTableIndex.IsIncludedColumn,
                            IsPrimaryKey = sqlTableIndex.IsPrimaryKey,
                            IsUniqueConstraint = sqlTableIndex.IsUniqueConstraint,
                        });
                }
                else
                {
                    tableIndex_IndexId = objectGraphData.GetTableIndex(sqlTableIndex.DatabaseName, sqlTableIndex.TableName, sqlTableIndex.Name).Id;
                }

                AddRelationship("Table", tableIndexId, "HAS_INDEX", "TableIndex", tableIndex_IndexId);
                AddRelationship("TableIndex", tableIndex_IndexId, "HAS_"+sqlTableIndex.Type+"_ON", "Column", columnIndexId);
            }
        }




        private void AddDatabases(List<ReferencingObject> referencingObjects)
        {
            // All distinct databases
            var referenceObjects = referencingObjects.DistinctBy(d => d.SourceDatabaseName).ToList();

            foreach (var referenceObject in referenceObjects)
            {
                if (referenceObject.SourceDatabaseName == "NA")
                {
                    continue;
                }

                if (!objectGraphData.DatabaseExist(referenceObject.SourceDatabaseName))
                {
                    objectGraphData.Databases.Add(
                        new Database
                        {
                            Id = GetNextIndex(),
                            Name = referenceObject.SourceDatabaseName
                        });
                }
            }

            referenceObjects = referencingObjects.DistinctBy(d => d.DependentObjectDatabaseName).ToList();
            foreach (var referenceObject in referenceObjects)
            {
                if (referenceObject.DependentObjectDatabaseName == "NA")
                {
                    continue;
                }
                if (!objectGraphData.DatabaseExist(referenceObject.DependentObjectDatabaseName))
                {
                    objectGraphData.Databases.Add(
                        new Database
                        {
                            Id = GetNextIndex(),
                            Name = referenceObject.DependentObjectDatabaseName
                        });
                }
            }
        }

        private void AddSourceDatabaseObjectAndRelations(List<ReferencingObject> referencingObjects)
        {
            // All distinct source procedure name
            var referenceObjects = referencingObjects.DistinctBy(d => (d.SourceDatabaseName, d.SourceObjectName)).ToList();

            foreach (var referenceObject in referenceObjects)
            {
                if (referenceObject.SourceDatabaseName == "NA")
                {
                    continue;
                }
                var sourceDatabaseId = objectGraphData.GetDatabase(referenceObject.SourceDatabaseName).Id;
                var sourceObjectTypeName = GetObjectTypeName(referenceObject.SourceObjectType);

                if (referenceObject.SourceObjectType == "USER_TABLE")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.TableExist(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName))
                    {
                        // Add Table Object
                        objectIndex = GetNextIndex();
                        objectGraphData.Tables.Add(
                            new Table
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.SourceObjectId,
                                DatabaseName = referenceObject.SourceDatabaseName,
                                SchemaName = referenceObject.SourceObjectSchemaName,
                                Name = referenceObject.SourceObjectName
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetTable(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName).Id;
                    }
                    AddRelationship("Database", sourceDatabaseId, "CONTAINS", sourceObjectTypeName, objectIndex);
                }
                else if (referenceObject.SourceObjectType == "TYPE")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.UserTypeExist(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName))
                    {
                        // Add Type Object
                        objectIndex = GetNextIndex();
                        objectGraphData.UserTypes.Add(
                            new UserType
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.SourceObjectId,
                                DatabaseName = referenceObject.SourceDatabaseName,
                                SchemaName = referenceObject.SourceObjectSchemaName,
                                Name = referenceObject.SourceObjectName
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetUserType(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName).Id;
                    }
                    AddRelationship("Database", sourceDatabaseId, "CONTAINS", sourceObjectTypeName, objectIndex);
                }
                else if (referenceObject.SourceObjectType == "VIEW")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.ViewExist(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName))
                    {
                        // Add View Object
                        objectIndex = GetNextIndex();
                        objectGraphData.Views.Add(
                            new View
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.SourceObjectId,
                                DatabaseName = referenceObject.SourceDatabaseName,
                                SchemaName = referenceObject.SourceObjectSchemaName,
                                Name = referenceObject.SourceObjectName
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetView(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName).Id;
                    }
                    AddRelationship("Database", sourceDatabaseId, "CONTAINS", sourceObjectTypeName, objectIndex);
                }
                else if (referenceObject.SourceObjectType == "SQL_TABLE_VALUED_FUNCTION")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.TableValuedFunctionExist(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName))
                    {
                        // Add TableValuedFunction Object
                        objectIndex = GetNextIndex();
                        objectGraphData.TableValuedFunctions.Add(
                            new TableValuedFunction
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.SourceObjectId,
                                DatabaseName = referenceObject.SourceDatabaseName,
                                SchemaName = referenceObject.SourceObjectSchemaName,
                                Name = referenceObject.SourceObjectName
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetTableValuedFunction(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName).Id;
                    }
                    AddRelationship("Database", sourceDatabaseId, "CONTAINS", sourceObjectTypeName, objectIndex);

                }
                else if (referenceObject.SourceObjectType == "SQL_INLINE_TABLE_VALUED_FUNCTION")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.InlineTableValuedFunctionExist(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName))
                    {
                        // Add InlineTableValuedFunction Object
                        objectIndex = GetNextIndex();
                        objectGraphData.InlineTableValuedFunctions.Add(
                            new InlineTableValuedFunction
                            {
                                Id = objectIndex,
                                DatabaseName = referenceObject.SourceDatabaseName,
                                SchemaName = referenceObject.SourceObjectSchemaName,
                                Name = referenceObject.SourceObjectName
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetInlineTableValuedFunction(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName).Id;
                    }
                    AddRelationship("Database", sourceDatabaseId, "CONTAINS", sourceObjectTypeName, objectIndex);
                }
                else if (referenceObject.SourceObjectType == "SQL_STORED_PROCEDURE")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.StoredProcedureExist(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName))
                    {
                        // Add StoredProcedures Object
                        objectIndex = GetNextIndex();
                        objectGraphData.StoredProcedures.Add(
                            new StoredProcedure
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.SourceObjectId,
                                DatabaseName = referenceObject.SourceDatabaseName,
                                SchemaName = referenceObject.SourceObjectSchemaName,
                                Name = referenceObject.SourceObjectName
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetStoredProcedure(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName).Id;
                    }
                    AddRelationship("Database", sourceDatabaseId, "CONTAINS", sourceObjectTypeName, objectIndex);
                }
                else if (referenceObject.SourceObjectType == "SQL_SCALAR_FUNCTION")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.FunctionExist(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName))
                    {
                        // Add Function Object
                        objectIndex = GetNextIndex();
                        objectGraphData.Functions.Add(
                            new Function
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.SourceObjectId,
                                DatabaseName = referenceObject.SourceDatabaseName,
                                SchemaName = referenceObject.SourceObjectSchemaName,
                                Name = referenceObject.SourceObjectName
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetFunction(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName).Id;
                    }
                    AddRelationship("Database", sourceDatabaseId, "CONTAINS", sourceObjectTypeName, objectIndex);
                }
                else
                {
                    var objectIndex = 0;
                    if (!objectGraphData.DatabaseObjectExist(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName))
                    {
                        // Add Database Object
                        objectIndex = GetNextIndex();
                        objectGraphData.DatabaseObjects.Add(
                            new DatabaseObject
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.SourceObjectId,
                                DatabaseName = referenceObject.SourceDatabaseName,
                                SchemaName = referenceObject.SourceObjectSchemaName,
                                ObjectType = referenceObject.SourceObjectType,
                                Name = referenceObject.SourceObjectName,
                                //Definition = ""
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetDatabaseObject(referenceObject.SourceDatabaseName, referenceObject.SourceObjectName).Id;
                    }
                    AddRelationship("Database", sourceDatabaseId, "CONTAINS", sourceObjectTypeName, objectIndex);
                }
            }
        }

        private void AddDependentDatabaseObjectAndRelations(List<ReferencingObject> referencingObjects)
        {
            // All distinct dependent procedure name
            var referenceObjects = referencingObjects;
            foreach (var referenceObject in referenceObjects)
            {
                if (referenceObject.DependentObjectDatabaseName == "NA")
                    continue;

                var sourceObjectTypeName = "";
                var sourceObjectId = -1;

                if (referenceObject.SourceDatabaseName != "NA")
                {
                    sourceObjectTypeName = GetObjectTypeName(referenceObject.SourceObjectType);
                    sourceObjectId = GetObjectId(referenceObject.SourceDatabaseName, referenceObject.SourceObjectType, referenceObject.SourceObjectName);
                }

                var dependentObjectTypeName = GetObjectTypeName(referenceObject.DependentObjectType);
                var dependentObjectDatabaseId = objectGraphData.GetDatabase(referenceObject.DependentObjectDatabaseName).Id;

                if (referenceObject.DependentObjectType == "USER_TABLE")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.TableExist(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName))
                    {
                        // Add User Table
                        objectIndex = GetNextIndex();
                        objectGraphData.Tables.Add(
                            new Table
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.DependentObjectId,
                                DatabaseName = referenceObject.DependentObjectDatabaseName,
                                SchemaName = referenceObject.DependentObjectSchemaName,
                                Name = referenceObject.DependentObjectName,
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetTable(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName).Id;
                    }
                    if (referenceObject.DependentObjectDatabaseName != "NA")
                        AddRelationship("Database", dependentObjectDatabaseId, "CONTAINS", dependentObjectTypeName, objectIndex);
                    if (referenceObject.SourceDatabaseName != "NA")
                        AddRelationship(sourceObjectTypeName, sourceObjectId, "DEPENDS_ON", dependentObjectTypeName, objectIndex);
                }
                else if (referenceObject.DependentObjectType == "TYPE")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.UserTypeExist(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName))
                    {
                        // Add User Type
                        objectIndex = GetNextIndex();
                        objectGraphData.UserTypes.Add(
                            new UserType
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.DependentObjectId,
                                DatabaseName = referenceObject.DependentObjectDatabaseName,
                                SchemaName = referenceObject.DependentObjectSchemaName,
                                Name = referenceObject.DependentObjectName,
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetUserType(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName).Id;
                    }
                    if (referenceObject.DependentObjectDatabaseName != "NA")
                        AddRelationship("Database", dependentObjectDatabaseId, "CONTAINS", dependentObjectTypeName, objectIndex);
                    if (referenceObject.SourceDatabaseName != "NA")
                        AddRelationship(sourceObjectTypeName, sourceObjectId, "DEPENDS_ON", dependentObjectTypeName, objectIndex);
                }
                else if (referenceObject.DependentObjectType == "VIEW")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.ViewExist(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName))
                    {
                        // Add User Table
                        objectIndex = GetNextIndex();
                        objectGraphData.Views.Add(
                            new View
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.DependentObjectId,
                                DatabaseName = referenceObject.DependentObjectDatabaseName,
                                SchemaName = referenceObject.DependentObjectSchemaName,
                                Name = referenceObject.DependentObjectName,
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetView(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName).Id;
                    }
                    if (referenceObject.DependentObjectDatabaseName != "NA")
                        AddRelationship("Database", dependentObjectDatabaseId, "CONTAINS", dependentObjectTypeName, objectIndex);
                    if (referenceObject.SourceDatabaseName != "NA")
                        AddRelationship(sourceObjectTypeName, sourceObjectId, "DEPENDS_ON", dependentObjectTypeName, objectIndex);
                }
                else if (referenceObject.DependentObjectType == "SQL_TABLE_VALUED_FUNCTION")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.TableValuedFunctionExist(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName))
                    {
                        // Add User Table
                        objectIndex = GetNextIndex();
                        objectGraphData.TableValuedFunctions.Add(
                            new TableValuedFunction
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.DependentObjectId,
                                DatabaseName = referenceObject.DependentObjectDatabaseName,
                                SchemaName = referenceObject.DependentObjectSchemaName,
                                Name = referenceObject.DependentObjectName,
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetTableValuedFunction(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName).Id;
                    }
                    if (referenceObject.DependentObjectDatabaseName != "NA")
                        AddRelationship("Database", dependentObjectDatabaseId, "CONTAINS", dependentObjectTypeName, objectIndex);
                    if (referenceObject.SourceDatabaseName != "NA")
                        AddRelationship(sourceObjectTypeName, sourceObjectId, "DEPENDS_ON", dependentObjectTypeName, objectIndex);
                }
                else if (referenceObject.DependentObjectType == "SQL_INLINE_TABLE_VALUED_FUNCTION")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.InlineTableValuedFunctionExist(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName))
                    {
                        // Add User Table
                        objectIndex = GetNextIndex();
                        objectGraphData.InlineTableValuedFunctions.Add(
                            new InlineTableValuedFunction
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.DependentObjectId,
                                DatabaseName = referenceObject.DependentObjectDatabaseName,
                                SchemaName = referenceObject.DependentObjectSchemaName,
                                Name = referenceObject.DependentObjectName,
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetInlineTableValuedFunction(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName).Id;
                    }
                    if (referenceObject.DependentObjectDatabaseName != "NA")
                        AddRelationship("Database", dependentObjectDatabaseId, "CONTAINS", dependentObjectTypeName, objectIndex);
                    if (referenceObject.SourceDatabaseName != "NA")
                        AddRelationship(sourceObjectTypeName, sourceObjectId, "DEPENDS_ON", dependentObjectTypeName, objectIndex);
                }
                else if (referenceObject.DependentObjectType == "SQL_STORED_PROCEDURE")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.StoredProcedureExist(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName))
                    {
                        // Add User Table
                        objectIndex = GetNextIndex();
                        objectGraphData.StoredProcedures.Add(
                            new StoredProcedure
                            {
                                Id = objectIndex,
                                DatabaseName = referenceObject.DependentObjectDatabaseName,
                                SchemaName = referenceObject.DependentObjectSchemaName,
                                Name = referenceObject.DependentObjectName,
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetStoredProcedure(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName).Id;
                    }
                    if (referenceObject.DependentObjectDatabaseName != "NA")
                        AddRelationship("Database", dependentObjectDatabaseId, "CONTAINS", dependentObjectTypeName, objectIndex);
                    if (referenceObject.SourceDatabaseName != "NA")
                        AddRelationship(sourceObjectTypeName, sourceObjectId, "DEPENDS_ON", dependentObjectTypeName, objectIndex);
                }
                else if (referenceObject.DependentObjectType == "SQL_SCALAR_FUNCTION")
                {
                    var objectIndex = 0;
                    if (!objectGraphData.FunctionExist(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName))
                    {
                        // Add User Table
                        objectIndex = GetNextIndex();
                        objectGraphData.Functions.Add(
                            new Function
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.DependentObjectId,
                                DatabaseName = referenceObject.DependentObjectDatabaseName,
                                SchemaName = referenceObject.DependentObjectSchemaName,
                                Name = referenceObject.DependentObjectName,
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetFunction(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName).Id;
                    }
                    if (referenceObject.DependentObjectDatabaseName != "NA")
                        AddRelationship("Database", dependentObjectDatabaseId, "CONTAINS", dependentObjectTypeName, objectIndex);
                    if (referenceObject.SourceDatabaseName != "NA")
                        AddRelationship(sourceObjectTypeName, sourceObjectId, "DEPENDS_ON", dependentObjectTypeName, objectIndex);
                }
                else
                {
                    var objectIndex = 0;
                    if (!objectGraphData.DatabaseObjectExist(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName))
                    {
                        // Add Database Object
                        objectIndex = GetNextIndex();
                        objectGraphData.DatabaseObjects.Add(
                            new DatabaseObject
                            {
                                Id = objectIndex,
                                ObjectId = referenceObject.DependentObjectId,
                                DatabaseName = referenceObject.DependentObjectDatabaseName,
                                SchemaName = referenceObject.DependentObjectSchemaName,
                                ObjectType = referenceObject.DependentObjectType,
                                Name = referenceObject.DependentObjectName,
                            });
                    }
                    else
                    {
                        objectIndex = objectGraphData.GetDatabaseObject(referenceObject.DependentObjectDatabaseName, referenceObject.DependentObjectName).Id;
                    }
                    if (referenceObject.DependentObjectDatabaseName != "NA")
                        AddRelationship("Database", dependentObjectDatabaseId, "CONTAINS", dependentObjectTypeName, objectIndex);
                    if (referenceObject.SourceDatabaseName != "NA")
                        AddRelationship(sourceObjectTypeName, sourceObjectId, "DEPENDS_ON", dependentObjectTypeName, objectIndex);
                }
            }
        }

        private void AddRelationship(string sourceNodeName, int sourceNodeId, string relationName, string destinationNodeName, int destinationNodeId)
        {
            if (string.IsNullOrEmpty(sourceNodeName))
            {
                throw new ArgumentException($"'{nameof(sourceNodeName)}' cannot be null or empty.", nameof(sourceNodeName));
            }

            if (string.IsNullOrEmpty(relationName))
            {
                throw new ArgumentException($"'{nameof(relationName)}' cannot be null or empty.", nameof(relationName));
            }

            if (string.IsNullOrEmpty(destinationNodeName))
            {
                throw new ArgumentException($"'{nameof(destinationNodeName)}' cannot be null or empty.", nameof(destinationNodeName));
            }

            if (!objectGraphData.RelationshipExist(sourceNodeId, relationName, destinationNodeId))
            {
                // Add Database->Object contains relation
                objectGraphData.Relationships.Add(
                    new Relationship
                    {
                        Id = GetNextIndex(),
                        SourceNodeName = sourceNodeName,
                        SourceNodeId = sourceNodeId,
                        RelationName = relationName,
                        DestinationNodeName = destinationNodeName,
                        DestinationNodeId = destinationNodeId
                    });
            }
        }

        private int GetNextIndex()
        {
            return indexCounter++;
        }

        private string GetObjectTypeName(string typeName)
        {
            switch (typeName)
            {
                case "USER_TABLE": return "Table";
                case "TYPE": return "Type";
                case "VIEW": return "View";
                case "SQL_TABLE_VALUED_FUNCTION": return "TableValuedFunction";
                case "SQL_INLINE_TABLE_VALUED_FUNCTION": return "InlineTableValuedFunction";
                case "SQL_STORED_PROCEDURE": return "StoredProcedure";
                case "SQL_SCALAR_FUNCTION": return "Function";
                default: return "DatabaseObject";
            }
        }

        private int GetObjectId(string database, string typeName, string name)
        {
            switch (typeName)
            {
                case "USER_TABLE": return objectGraphData.GetTable(database, name).Id;
                case "TYPE": return objectGraphData.GetUserType(database, name).Id;
                case "VIEW": return objectGraphData.GetView(database, name).Id;
                case "SQL_TABLE_VALUED_FUNCTION": return objectGraphData.GetTableValuedFunction(database, name).Id;
                case "SQL_INLINE_TABLE_VALUED_FUNCTION": return objectGraphData.GetInlineTableValuedFunction(database, name).Id;
                case "SQL_STORED_PROCEDURE": return objectGraphData.GetStoredProcedure(database, name).Id;
                case "SQL_SCALAR_FUNCTION": return objectGraphData.GetFunction(database, name).Id;
                default: return objectGraphData.GetDatabaseObject(database, name).Id;
            }
        }

    }
}
