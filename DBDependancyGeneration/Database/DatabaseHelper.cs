using DBGraphXplore.DatabaseScanner.Entities;
using Microsoft.Data.SqlClient;

namespace DBGraphXplore.DatabaseScanner.Database
{
    public class DatabaseHelper
    {
        public DatabaseHelper() { }

        // Handle InfoMessages (Warnings/Errors)
        static void SqlInfoMessageHandler(object sender, SqlInfoMessageEventArgs e)
        {
            // Capture the SQL error/warning message
            Console.WriteLine($"SQL Message: {e.Message}");
        }

        public List<SqlTableColumnDependency> GetAllSqlTableColumnDependencies(string connectionString)
        {
            var sqlTableColumnDependencies = new List<SqlTableColumnDependency>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.InfoMessage += new SqlInfoMessageEventHandler(SqlInfoMessageHandler); // To capture messages

                conn.Open();

                var commandText = @"    SET XACT_ABORT OFF;
                                        BEGIN TRY
                                            SELECT 
                                                DB_NAME() AS database_name,
                                                ISNULL(SCHEMA_NAME(o.schema_id), 'dbo') AS schema_name,
                                                OBJECT_NAME(o.object_id) AS object_name,
                                                o.type_desc AS object_type,
                                                ISNULL(e.referenced_database_name, DB_NAME()) AS referenced_database_name,
                                                ISNULL(e.referenced_schema_name, SCHEMA_NAME(o.schema_id)) AS referenced_schema_name,
                                                e.referenced_entity_name AS referenced_table_name,
                                                e.referenced_minor_name AS referenced_column_name,
                                                e.referenced_class_desc AS class_desc,
                                                e.is_all_columns_found,
                                                e.is_selected, 
                                                e.is_updated, 
                                                e.is_select_all
                                            FROM
                                                sys.objects o
                                            CROSS APPLY 
                                                sys.dm_sql_referenced_entities(QUOTENAME(SCHEMA_NAME(o.schema_id)) + '.' + QUOTENAME(o.name), 'OBJECT') e
                                            WHERE
                                                o.type IN ('P', 'V')
                                                AND e.referenced_minor_name IS NOT NULL;
                                        END TRY
                                        BEGIN CATCH
                                            PRINT 'Error occurred, continuing execution...';
                                        END CATCH;
                                        ";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sqlTableColumnDependencies.Add(new SqlTableColumnDependency()
                            {
                                DatabaseName = reader["database_name"].ToString(),
                                SchemaName = reader["schema_name"].ToString(),
                                ObjectName = reader["object_name"].ToString(),
                                ObjectType = reader["object_type"].ToString(),
                                ReferencedDatabaseName = reader["referenced_database_name"].ToString(),
                                ReferencedSchemaName = reader["referenced_schema_name"].ToString(),
                                ReferencedTableName = reader["referenced_table_name"].ToString(),
                                ReferencedColumnName = reader["referenced_column_name"].ToString(),
                                ReferencedObjectType = reader["class_desc"].ToString(),
                                IsSelected = reader["is_selected"].ToString(),
                                IsUpdated = reader["is_updated"].ToString(),
                            });

                        }
                    }
                }
            }

            return sqlTableColumnDependencies;
        }

        public List<SqlObject> GetAllSqlObjects(string connectionString)
        {
            var sqlObjects = new List<SqlObject>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var commandText = @" SELECT object_id, parent_object_id, type, type_desc, sys.schemas.name as schema_name, sys.objects.name "+
                                   " from sys.objects, sys.schemas where sys.objects.schema_id = sys.schemas.schema_id";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sqlObjects.Add(new SqlObject()
                            {
                                DatabaseName = cmd.Connection.Database,
                                ObjectId = reader["object_id"].ToString(),
                                ParentObjectId = reader["parent_object_id"].ToString(),
                                Type = reader["type"].ToString(),
                                TypeDescription = reader["type_desc"].ToString(),
                                SchemaName = reader["schema_name"].ToString(),
                                Name = reader["name"].ToString(),
                            });
                        }
                    }
                }
            }

            return sqlObjects;
        }

        public List<SqlTable> GetAllSqlTables(string connectionString)
        {
            var sqlTables = new List<SqlTable>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var commandText = @" select sys.tables.object_id, sys.tables.name as table_name, sys.schemas.name as schema_name, type, type_desc from sys.tables, sys.schemas"+
                                   " where sys.tables.schema_id = sys.schemas.schema_id";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sqlTables.Add(new SqlTable()
                            {
                                DatabaseName = cmd.Connection.Database,
                                ObjectId = reader["object_id"].ToString(),
                                Type = reader["type"].ToString(),
                                TypeDescription = reader["type_desc"].ToString(),
                                SchemaName = reader["schema_name"].ToString(),
                                TableName = reader["table_name"].ToString(),
                            });
                        }
                    }
                }
            }

            return sqlTables;
        }

        public List<SqlTableColumn> GetAllSqlTableColumns(string connectionString)
        {
            var sqlTableColumns = new List<SqlTableColumn>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var commandText = @"select 
                                    sys.columns.object_id, 
                                    sys.schemas.name            as schema_name, 
                                    sys.tables.name             as table_name, 
                                    sys.columns.column_id, 
                                    sys.columns.name            as column_name, 
                                    sys.types.user_type_id, 
                                    sys.types.name              as type_name
                                    from sys.tables, sys.columns, sys.types, sys.schemas
                                    where sys.tables.object_id = sys.columns.object_id and sys.tables.schema_id = sys.schemas.schema_id and sys.columns.user_type_id = sys.types.user_type_id";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sqlTableColumns.Add(new SqlTableColumn()
                            {
                                DatabaseName = cmd.Connection.Database,
                                ObjectId = reader["object_id"].ToString(),
                                SchemaName = reader["schema_name"].ToString(),
                                TableName = reader["table_name"].ToString(),
                                ColumnId = reader["column_id"].ToString(),
                                ColumnName = reader["column_name"].ToString(),
                                ColumnTypeId = reader["user_type_id"].ToString(),
                                ColumnTypeName = reader["type_name"].ToString(),
                            });
                        }
                    }
                }
            }

            return sqlTableColumns;
        }

        public List<SqlKeyConstraint> GetAllSqlKeyConstraints(string connectionString)
        {
            var sqlKeyConstraints = new List<SqlKeyConstraint>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var commandText = @"SELECT  DB_NAME()       AS database_Name,
                                            t.object_id, 
                                            t.name          AS table_name, 
                                            kc.name         AS key_constraint_name, 
                                            kc.type, 
                                            kc.type_desc, 
                                            c.column_id, 
                                            c.name AS column_name
                                     FROM sys.tables        AS t
                                     JOIN sys.key_constraints   AS kc ON t.object_id = kc.parent_object_id
                                     JOIN sys.index_columns     AS ic ON kc.unique_index_id = ic.index_id AND t.object_id = ic.object_id
                                     JOIN sys.columns           AS c ON ic.object_id = c.object_id AND ic.column_id = c.column_id ";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sqlKeyConstraints.Add(new SqlKeyConstraint()
                            {
                                DatabaseName = reader["database_Name"].ToString(),
                                ObjectId = reader["object_id"].ToString(),
                                TableName = reader["table_name"].ToString(),
                                Name = reader["key_constraint_name"].ToString(),
                                Type = reader["type"].ToString(),
                                TypeDescription = reader["type_desc"].ToString(),
                                ColumnId = reader["column_id"].ToString(),
                                ColumnName = reader["column_name"].ToString(),
                            });
                        }
                    }
                }
            }

            return sqlKeyConstraints;
        }

        public List<SqlForeignKeyConstraint> GetAllSqlForeignKeyConstraints(string connectionString)
        {
            var sqlForeignKeyConstraints = new List<SqlForeignKeyConstraint>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var commandText = @"SELECT 
	                                DB_NAME()           AS database_name,
                                    fk.name             AS foreign_key_name,               -- Foreign key name
	                                t.object_id         AS foreign_key_table_object_id, 
                                    t.name              AS foreign_key_table_name,         -- Current table name
                                    c.name              AS foreign_key_column_name,        -- Column in the current table
	                                pk_table.object_id  AS primary_key_table_object_id, 
                                    pk_table.name       AS primary_key_table_name,    -- Referenced (primary key) table
                                    pk_column.name      AS primary_key_column_name    -- Primary key column in the referenced table
                                FROM sys.foreign_keys   AS fk
                                JOIN sys.foreign_key_columns    AS fkc ON fk.object_id = fkc.constraint_object_id
                                JOIN sys.tables                 AS t ON fk.parent_object_id = t.object_id                                                                              -- Current table
                                JOIN sys.columns                AS c ON fkc.parent_object_id = c.object_id AND fkc.parent_column_id = c.column_id                                      -- Foreign key column in current table
                                JOIN sys.tables                 AS pk_table ON fkc.referenced_object_id = pk_table.object_id   -- Referenced (primary key) table
                                JOIN sys.columns                AS pk_column ON fkc.referenced_object_id = pk_column.object_id AND fkc.referenced_column_id = pk_column.column_id      -- Primary key column in referenced table
                                WHERE fk.type_desc = 'FOREIGN_KEY_CONSTRAINT'
                                ORDER BY fk.name, t.name, c.name;";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sqlForeignKeyConstraints.Add(new SqlForeignKeyConstraint()
                            {
                                DatabaseName = reader["database_Name"].ToString(),
                                Name = reader["foreign_key_name"].ToString(),
                                //Type = reader["type"].ToString(),
                                //TypeDescription = reader["type_desc"].ToString(),

                                ForeignKeyTableObjectId = reader["foreign_key_table_object_id"].ToString(),
                                ForeignKeyTableName = reader["foreign_key_table_name"].ToString(),
                                ForeignKeyColumnName = reader["foreign_key_column_name"].ToString(),

                                PrimaryKeyTableObjectId = reader["primary_key_table_object_id"].ToString(),
                                PrimaryKeyTableName = reader["primary_key_table_name"].ToString(),
                                PrimaryKeyColumnName = reader["primary_key_column_name"].ToString(),
                            });
                        }
                    }
                }
            }

            return sqlForeignKeyConstraints;
        }


        public List<SqlRoutine> GetAllRoutines(string connectionString)
        {
            var routineObjects = new List<SqlRoutine>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var commandText = @" SELECT " +
                                    " SPECIFIC_CATALOG as DatabaseName, " +
                                    " ROUTINE_SCHEMA AS SchemaName, " +
                                    " ROUTINE_TYPE AS RoutineType, " +
                                    " ROUTINE_NAME AS RoutineName, " +
                                    " ROUTINE_DEFINITION AS RoutineDefinition, " +
                                    " sys.sql_modules.definition AS Definition" +
                                    " FROM  sys.sql_modules, INFORMATION_SCHEMA.ROUTINES"+
                                    " WHERE sys.sql_modules.object_id = OBJECT_ID(INFORMATION_SCHEMA.ROUTINES.ROUTINE_NAME) ";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            routineObjects.Add(new SqlRoutine()
                            {
                                DatabaseName = reader["DatabaseName"].ToString(),
                                SchemaName = reader["SchemaName"].ToString(),
                                RoutineType = reader["RoutineType"].ToString(),
                                RoutineName = reader["RoutineName"].ToString(),
                                RoutineDefinition = reader["Definition"].ToString(),

                            });
                        }
                    }
                }
            }

            return routineObjects;
        }
        public List<SqlTableIndex> GetAllTableIndexes(string connectionString)
        {
            var tableIndexes = new List<SqlTableIndex>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var commandText = @" SELECT "
                                    + " t.object_id, "
                                    + " t.name AS table_name, "
                                    + " c.name AS column_name, "
                                    + " i.name AS index_name, "
                                    + " i.type_desc AS index_type, "  // Clustered, Non-Clustered, etc.
                                    + " ic.key_ordinal AS column_order, "
                                    + " ic.is_included_column,"  //Included column for non-key columns in the index
                                    + " i.is_primary_key,"
                                    + " i.is_unique_constraint"
                                    + " FROM "
                                    + "     sys.tables AS t"
                                    + " JOIN "
                                    + "     sys.indexes AS i ON t.object_id = i.object_id"
                                    + " JOIN "
                                    + "     sys.index_columns AS ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id"
                                    + " JOIN "
                                    + "     sys.columns AS c ON ic.object_id = c.object_id AND ic.column_id = c.column_id "
                                    + " ORDER BY "
                                    + "     t.name, ic.key_ordinal;";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tableIndexes.Add(new SqlTableIndex()
                            {
                                DatabaseName = cmd.Connection.Database,
                                TableObjectId = reader["object_id"].ToString(),
                                TableName = reader["table_name"].ToString(),
                                ColumnName = reader["column_name"].ToString(),
                                ColumnOrder = reader["column_order"].ToString(),
                                Name = reader["index_name"].ToString(),
                                Type = reader["index_type"].ToString(),
                                IsIncludedColumn = reader["is_included_column"].ToString(),
                                IsPrimaryKey = reader["is_primary_key"].ToString(),
                                IsUniqueConstraint = reader["is_unique_constraint"].ToString(),

                            });
                        }
                    }
                }
            }

            return tableIndexes;
        }


        public List<ReferencingObject> GetObjectDependencies(string connectionString, string procedureName)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"'{nameof(connectionString)}' cannot be null or empty.", nameof(connectionString));
            }

            if (string.IsNullOrEmpty(procedureName))
            {
                throw new ArgumentException($"'{nameof(procedureName)}' cannot be null or empty.", nameof(procedureName));
            }

            var dependenciesList = new List<ReferencingObject>();


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var commandText = @"SELECT DISTINCT
                                     referencing_objects.name AS referencing_name, 
                                     schemas_referencing.name AS referencing_schema_name, 
                                     referencing_objects.type AS referencing_type,
                                     referencing_objects.type_desc AS referencing_type_desc,
                                     sys.sql_expression_dependencies.referencing_id,
                                     sys.sql_expression_dependencies.referenced_class,
                                     sys.sql_expression_dependencies.referenced_class_desc,
                                     sys.sql_expression_dependencies.referenced_database_name,
                                     sys.sql_expression_dependencies.referenced_schema_name,
                                     sys.sql_expression_dependencies.referenced_entity_name,
                                     sys.sql_expression_dependencies.referenced_id,
                                     referenced_objects.type AS referenced_type,
                                     referenced_objects.type_desc AS referenced_type_desc
                                     FROM sys.all_objects AS referenced_objects
                                     RIGHT OUTER JOIN sys.sql_expression_dependencies
                                        ON referenced_objects.object_id = sys.sql_expression_dependencies.referenced_id
                                    LEFT OUTER JOIN sys.all_objects AS referencing_objects
                                        ON sys.sql_expression_dependencies.referencing_id = referencing_objects.object_id
                                    LEFT OUTER JOIN sys.schemas AS schemas_referencing
                                        ON referencing_objects.schema_id = schemas_referencing.schema_id
                                    WHERE referencing_objects.name = @StoredProcedureName;";

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Parameters.AddWithValue("@StoredProcedureName", procedureName);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //dependencies.Add(reader["referenced_entity_name"].ToString());
                            var item = new ReferencingObject()
                            {
                                SourceDatabaseName = cmd.Connection.Database,
                                SourceObjectId = reader["referencing_id"].ToString(),
                                SourceObjectSchemaName = reader["referencing_schema_name"].ToString(),
                                SourceObjectType = reader["referencing_type_desc"].ToString(),
                                SourceObjectName = reader["referencing_name"].ToString(),

                                DependentObjectId = reader["referenced_id"].ToString(),
                                DependentObjectType = reader["referenced_type_desc"].ToString(),
                                DependentObjectClassDescription = reader["referenced_class_desc"].ToString(),
                                DependentObjectDatabaseName = reader["referenced_database_name"].ToString(),
                                DependentObjectSchemaName = reader["referenced_schema_name"].ToString(),
                                DependentObjectName = reader["referenced_entity_name"].ToString(),

                            };

                            if (string.IsNullOrEmpty(item.DependentObjectDatabaseName))
                            {
                                item.DependentObjectDatabaseName = conn.Database;
                            }

                            if (string.IsNullOrEmpty(item.DependentObjectType))
                            {
                                if (item.DependentObjectClassDescription == "TYPE")
                                {
                                    item.DependentObjectType = item.DependentObjectClassDescription;
                                }
                            }

                            dependenciesList.Add(item);
                        }
                    }
                }
            }

            return dependenciesList;
        }
    }

}
