namespace DBGraphXplore.DatabaseScanner.Scanner
{
    using System;
    using System.Collections.Generic;
    using DBGraphXplore.DatabaseScanner.Entities;
    using DBGraphXplore.DatabaseScanner.DependancyData.Export;
    using DBGraphXplore.Core.EventHandlers;
    using DBGraphXplore.DatabaseScanner.Database;

    public class SQLServerScanner : IDatabaseScanner
    {
        private DatabaseHelper databaseHelper;
        private ScannedData scannedData;
        private string exportFileName = "";
        private Dictionary<string, string> connectionStrings = new Dictionary<string, string>();

        public ScannedData DependancyData { get => scannedData; }

        private List<string> uniqueSPNameList = []; //This list will be used to store the unique sp name, to avoid processing of duplidate sps 

        //public bool GenerateTechnicalDocumentUsingAI { get; set; } = false;



        public event EventHandler Started;
        public event EventHandler Completed;
        public event EventHandler<GenericEventHandler<string>> ProgressChanged;
        public event EventHandler<GenericEventHandler<long>> ProgressPercentageChanged;

        #region PrivateEventInvoker

        private void InvokeProgressPercentageChanged(GenericEventHandler<long> e)
        {
            EventHandler<GenericEventHandler<long>> handler = ProgressPercentageChanged;
            if (handler != null) handler(this, e);
        }

        private void InvokeStarted(EventArgs e)
        {
            EventHandler handler = Started;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void InvokeCompleted(EventArgs e)
        {
            EventHandler handler = Completed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void InvokeProgressChanged(GenericEventHandler<string> e)
        {
            EventHandler<GenericEventHandler<string>> handler = ProgressChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion



        public SQLServerScanner(Dictionary<string, string> connectionStrings, List<SqlRoutine> sourceRoutineObjects, string exportFileName)
        {
            scannedData = new ScannedData();
            databaseHelper = new DatabaseHelper();

            this.connectionStrings = connectionStrings;
            scannedData.SourceRoutineObjects = sourceRoutineObjects;
            this.exportFileName = exportFileName;
        }

        public void Scan()
        {
            InvokeStarted(new EventArgs());
            InvokeProgressChanged(new GenericEventHandler<string>("SQL Dependancy Generator Started .... "));

            try
            {
                scannedData.ReferencingObjects = [];
                uniqueSPNameList = [];

                var index = 0;
                foreach (var routine in scannedData.SourceRoutineObjects)
                {
                    InvokeProgressChanged(new GenericEventHandler<string>("Processing : [" + routine.RoutineType +"] " + routine.DatabaseName + "." + routine.SchemaName + "." + routine.RoutineName));

                    GetDependencies(routine.DatabaseName, "", routine.RoutineName);

                    index = index + 1;
                    double percentage = index / (double)scannedData.SourceRoutineObjects.Count * 100;
                    InvokeProgressPercentageChanged(new GenericEventHandler<long>((long)percentage));
                }
                foreach (var table in scannedData.SqlTables)
                {
                    var exist = scannedData.ReferencingObjects.Exists(d => d.DependentObjectDatabaseName.ToLower() == table.DatabaseName.ToLower() && d.DependentObjectType == "USER_TABLE" && d.DependentObjectName.ToLower() == table.TableName.ToLower());
                    if (!exist)
                    {
                        scannedData.ReferencingObjects.Add(new ReferencingObject
                        {
                            SourceDatabaseName = "",
                            SourceObjectSchemaName = "",
                            SourceObjectType = "",
                            SourceObjectName = "",
                            SourceObjectId = "",
                            DependentObjectId = table.ObjectId,
                            DependentObjectDatabaseName = table.DatabaseName,
                            DependentObjectSchemaName = table.SchemaName,
                            DependentObjectType = "",
                            DependentObjectClassDescription = table.TypeDescription,
                            DependentObjectName = table.TableName
                        });
                    }
                }

                InvokeProgressChanged(new GenericEventHandler<string>("Exporting Data in excel report format ..."));
                IDatatFileExport excelReportGenerator = new ExcelFileFormatExport(scannedData);
                excelReportGenerator.Export(exportFileName);

                InvokeProgressChanged(new GenericEventHandler<string>("SQL Dependancy Generator Completed .... "));
                InvokeCompleted(new EventArgs());
            }
            catch (Exception exception)
            {
                InvokeProgressChanged(new GenericEventHandler<string>("Error: " + exception.Message + "\n"+exception.StackTrace));
                InvokeProgressChanged(new GenericEventHandler<string>("Unable to proceed, Exiting with Error"));
            }
        }

        public void Generate(List<string> databases)
        {
            InvokeStarted(new EventArgs());
            InvokeProgressChanged(new GenericEventHandler<string>("SQL Dependancy Generator Started .... "));

            scannedData.ReferencingObjects = [];
            uniqueSPNameList = [];
            var index = 0;
            try
            {
                foreach (var database in databases)
                {
                    var connectionString = "";
                    try
                    {
                        connectionString = connectionStrings[database.ToLower()];
                    }
                    catch (KeyNotFoundException exception)
                    {
                        InvokeProgressChanged(new GenericEventHandler<string>("Error: " + database + ", Database connection is not configured."));
                        return;
                    }

                    InvokeProgressChanged(new GenericEventHandler<string>("Retrieving SQL Objects information from " + database + " database."));
                    scannedData.SqlObjects.AddRange(databaseHelper.GetAllSqlObjects(connectionString));

                    InvokeProgressChanged(new GenericEventHandler<string>("Retrieving SQL Routines information from " + database + " database."));
                    scannedData.SourceRoutineObjects.AddRange(databaseHelper.GetAllRoutines(connectionString));

                    InvokeProgressChanged(new GenericEventHandler<string>("Retrieving SQL Tables information from " + database + " database."));
                    scannedData.SqlTables.AddRange(databaseHelper.GetAllSqlTables(connectionString));

                    InvokeProgressChanged(new GenericEventHandler<string>("Retrieving SQL TableColumns information from " + database + " database."));
                    scannedData.SqlTableColumns.AddRange(databaseHelper.GetAllSqlTableColumns(connectionString));

                    InvokeProgressChanged(new GenericEventHandler<string>("Retrieving SQL KeyConstraints information from " + database + " database."));
                    scannedData.SqlKeyConstraints.AddRange(databaseHelper.GetAllSqlKeyConstraints(connectionString));

                    InvokeProgressChanged(new GenericEventHandler<string>("Retrieving SQL Foreign KeyConstraints information from " + database + " database."));
                    scannedData.SqlForeignKeyConstraints.AddRange(databaseHelper.GetAllSqlForeignKeyConstraints(connectionString));

                    InvokeProgressChanged(new GenericEventHandler<string>("Retrieving SQL Table Index information from " + database + " database."));
                    scannedData.SqlTableIndexes.AddRange(databaseHelper.GetAllTableIndexes(connectionString));

                    InvokeProgressChanged(new GenericEventHandler<string>("Retrieving SQL TableColumnDependency information from " + database + " database."));
                    try
                    {
                        scannedData.SqlTableColumnDependencies.AddRange(databaseHelper.GetAllSqlTableColumnDependencies(connectionString));
                    }
                    catch (Exception exception)
                    {
                        InvokeProgressChanged(new GenericEventHandler<string>("Error: "+ exception.Message));
                    }

                }

                InvokeProgressChanged(new GenericEventHandler<string>("Generate Procedures/Functions Child Depencincies from database(s)."));

                foreach (var routine in scannedData.SourceRoutineObjects)
                {
                    InvokeProgressChanged(new GenericEventHandler<string>("Processing : [" + routine.RoutineType + "] " + routine.DatabaseName + "." + routine.SchemaName + "." + routine.RoutineName));

                    GetDependencies(routine.DatabaseName, routine.RoutineType, routine.RoutineName);

                    index = index + 1;
                    double percentage = index / (double)scannedData.SourceRoutineObjects.Count * 100;
                    InvokeProgressPercentageChanged(new GenericEventHandler<long>((long)percentage));
                }
                foreach (var table in scannedData.SqlTables)
                {
                    var exist = scannedData.ReferencingObjects.Exists(d => d.DependentObjectDatabaseName.ToLower() == table.DatabaseName.ToLower() && d.DependentObjectType == "USER_TABLE" && d.DependentObjectName.ToLower() == table.TableName.ToLower());
                    if (!exist)
                    {
                        scannedData.ReferencingObjects.Add(new ReferencingObject
                        {
                            SourceDatabaseName = "NA",
                            SourceObjectSchemaName = "NA",
                            SourceObjectType = "NA",
                            SourceObjectName = "NA",
                            SourceObjectId = "NA",
                            DependentObjectId = table.ObjectId,
                            DependentObjectDatabaseName = table.DatabaseName,
                            DependentObjectSchemaName = table.SchemaName,
                            DependentObjectType = table.TypeDescription,
                            DependentObjectClassDescription = "",
                            DependentObjectName = table.TableName
                        });
                    }
                }


                InvokeProgressChanged(new GenericEventHandler<string>("Exporting Data in excel report format ..."));
                IDatatFileExport excelReportGenerator = new ExcelFileFormatExport(scannedData);
                excelReportGenerator.Export(exportFileName);

                InvokeProgressChanged(new GenericEventHandler<string>("SQL Dependancy Generator Completed .... "));
                InvokeCompleted(new EventArgs());
            }
            catch (Exception exception)
            {
                InvokeProgressChanged(new GenericEventHandler<string>("Error: " + exception.Message + "\n" + exception.StackTrace));
                InvokeProgressChanged(new GenericEventHandler<string>("Unable to proceed, Exiting with Error"));
            }
        }

        private void GetDependencies(string databaseName, string objectType, string procedureName)
        {
            var uniqname = databaseName.ToLower() + "." + procedureName.ToLower();
            //Avoid duplicate processing, Make sure that stored procedure should be processed only once
            if (uniqueSPNameList.Contains(uniqname))
            {
                return;
            }
            uniqueSPNameList.Add(uniqname);


            var connectionString = "";
            try
            {
                connectionString = connectionStrings[databaseName.ToLower()];
            }
            catch (KeyNotFoundException exception)
            {
                InvokeProgressChanged(new GenericEventHandler<string>("Error: " + databaseName + "." + procedureName + ", Database connection is not configured."));
                return;
            }

            var directDependencies = databaseHelper.GetObjectDependencies(connectionString, procedureName);
            //this.scannedData.ReferencingObjects.AddRange(directDependencies);
            if (directDependencies.Count == 0)
            {
                if (scannedData.SqlObjects != null)
                {
                    var objectData = scannedData.SqlObjects.FirstOrDefault(d => d.DatabaseName.ToLower() == databaseName.ToLower() && d.Name.ToLower() == procedureName.ToLower());
                    if (objectData != null)
                    {
                        if (objectData.TypeDescription != "USER_TABLE")
                        {
                            scannedData.ReferencingObjects.Add(new ReferencingObject
                            {
                                SourceDatabaseName = objectData.DatabaseName,
                                SourceObjectSchemaName = objectData.SchemaName,
                                SourceObjectType = objectData.TypeDescription,
                                SourceObjectName = objectData.Name,
                                SourceObjectId = objectData.ObjectId,
                                DependentObjectId = "NA",
                                DependentObjectDatabaseName = "NA",
                                DependentObjectSchemaName = "NA",
                                DependentObjectType = "NA",
                                DependentObjectClassDescription = "NA",
                                DependentObjectName = "NA"
                            });
                        }
                    }
                }

                return;
            }

            foreach (var dependency in directDependencies)
            {
                var _databaseName = dependency.DependentObjectDatabaseName;
                if (string.IsNullOrEmpty(_databaseName))
                {
                    _databaseName = databaseName;
                }
                if (!scannedData.ReferencingObjects.Exists(d => d.SourceDatabaseName.ToLower() == dependency.SourceDatabaseName.ToLower() && d.SourceObjectName.ToLower() == dependency.SourceObjectName.ToLower() && d.DependentObjectDatabaseName.ToLower() == dependency.DependentObjectDatabaseName.ToLower() && d.DependentObjectType.ToLower() == dependency.DependentObjectType.ToLower() && d.DependentObjectName.ToLower() == dependency.DependentObjectName.ToLower()))
                {
                    if (dependency.DependentObjectType.Trim() == "")
                    {
                        var objectData = scannedData.SqlObjects.FirstOrDefault(d => d.DatabaseName.ToLower() == dependency.DependentObjectDatabaseName.ToLower() && d.Name.ToLower() == dependency.DependentObjectName.ToLower());
                        if (objectData != null)
                        {
                            if (objectData.TypeDescription != "")
                            {
                                dependency.DependentObjectType = objectData.TypeDescription;
                            }
                        }
                    }

                    scannedData.ReferencingObjects.Add(dependency);
                }

                //this.InvokeProgressChanged(new GenericEventHandler<string>(dependency.ReferencedObjectDatabaseName+", "+dependency.ReferencedObjectEntityName));
                GetDependencies(_databaseName, dependency.DependentObjectType, dependency.DependentObjectName);
            }
        }
    }

}
