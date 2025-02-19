using ClosedXML.Excel;
using DBGraphXplore.DatabaseScanner.Entities;
using System.Reflection;

namespace DBGraphXplore.DatabaseScanner.DependancyData.Loader
{
    public class ExcelFileFormatLoader : IDataFileLoader
    {
        public Entities.ScannedData Load(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException($"'{nameof(filePath)}' cannot be null or empty.", nameof(filePath));
            }


            var routineObjects = new List<SqlRoutine>();
            //var referencingObjects = new List<ReferencingObject>();
            var dataFile = new ScannedData();  

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet("Source Object List");
                var rows = worksheet.RangeUsed().RowsUsed(); // Get all used rows in the sheet

                // Skip the header row
                foreach (var row in rows.Skip(1))
                {
                    var routine = new SqlRoutine
                    {
                        RoutineType = row.Cell(2).GetString(),
                        DatabaseName = row.Cell(3).GetString(),
                        SchemaName = row.Cell(4).GetString(),
                        RoutineName = row.Cell(5).GetString(),
                        RoutineDefinition = row.Cell(6).GetString(),
                    };

                    routineObjects.Add(routine);
                }

                foreach(var worksheet1 in workbook.Worksheets.Skip(1))
                {
                    var name = worksheet1.Name;
                    if (name == "ReferencingObject")
                    {
                        dataFile.ReferencingObjects = ReadObjectCollection<ReferencingObject>(worksheet1);
                    } 
                    else if (name == "SqlObject")
                    {
                        dataFile.SqlObjects = ReadObjectCollection<SqlObject>(worksheet1);
                    }
                    else if (name == "SqlTable")
                    {
                        dataFile.SqlTables = ReadObjectCollection<SqlTable>(worksheet1);
                    }
                    else if (name == "SqlTableColumn")
                    {
                        dataFile.SqlTableColumns = ReadObjectCollection<SqlTableColumn>(worksheet1);
                    }
                    else if (name == "SqlKeyConstraint")
                    {
                        dataFile.SqlKeyConstraints = ReadObjectCollection<SqlKeyConstraint>(worksheet1);
                    }
                    else if (name == "SqlForeignKeyConstraint")
                    {
                        dataFile.SqlForeignKeyConstraints = ReadObjectCollection<SqlForeignKeyConstraint>(worksheet1);
                    }
                    else if (name == "SqlTableIndex")
                    {
                        dataFile.SqlTableIndexes = ReadObjectCollection<SqlTableIndex>(worksheet1);
                    }
                    else if (name == "SqlTableColumnDependency")
                    {
                        dataFile.SqlTableColumnDependencies = ReadObjectCollection<SqlTableColumnDependency>(worksheet1);
                    }
                    else
                    {
                        throw new NotImplementedException("Worksheet : "+ name +" Not define in file loader.");
                    }
                }
                             
            }
            dataFile.SourceRoutineObjects = routineObjects;   
            //dataFile.ReferencingObjects = referencingObjects;
            return dataFile;
        }

        private List<T> ReadObjectCollection<T>(IXLWorksheet worksheet)
        {
            List<T> list = new();

            IXLRangeRows rows = worksheet.RangeUsed().RowsUsed(); // Get all used rows in the sheet
            IXLRangeRow headerRow = rows.First();
            
            // Skip the header row
            foreach (IXLRangeRow row in rows.Skip(1))
            {
                var obj = (T) CreateObjectFromRow("DBGraphXplore.DatabaseScanner.Entities."+ worksheet.Name, headerRow, row);
                list.Add(obj);
            }

            return list;    

        }

        static object CreateObjectFromRow(string className, IXLRangeRow headerRow, IXLRangeRow dataRow)
        {
            // Get the type from the class name
            Type type = Type.GetType(className);
            if (type == null)
                throw new ArgumentException($"Type '{className}' not found.");

            // Create an instance of the type
            object instance = Activator.CreateInstance(type);

            // Iterate over the header cells to get property names
            foreach (var headerCell in headerRow.Cells().Skip(1))
            {
                string propertyName = headerCell.GetString().Trim();
                PropertyInfo propInfo = type.GetProperty(propertyName);

                if (propInfo != null && propInfo.CanWrite)
                {
                    // Find the corresponding value in the data row
                    var dataCell = dataRow.Cell(headerCell.Address.ColumnNumber);
                    object value = Convert.ChangeType(dataCell.GetValue<string>(), propInfo.PropertyType);

                    // Set the property value
                    propInfo.SetValue(instance, value);
                }
            }

            return instance;
        }
    }


}
