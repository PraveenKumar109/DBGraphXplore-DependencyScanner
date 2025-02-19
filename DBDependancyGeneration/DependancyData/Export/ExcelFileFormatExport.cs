using ClosedXML.Excel;
using DBGraphXplore.DatabaseScanner.Entities;

namespace DBGraphXplore.DatabaseScanner.DependancyData.Export
{
    internal class ExcelFileFormatExport : IDatatFileExport
    {
        private readonly ScannedData scannedData;

        public ExcelFileFormatExport(ScannedData scannedData)
        {
            this.scannedData = scannedData;
        }


        public void Export(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException($"'{nameof(filePath)}' cannot be null or empty.", nameof(filePath));
            }

            using (var workbook = new XLWorkbook())
            {
                AddSourceObjectSheet(workbook);
                //AddDependenciesSheet(workbook);
                AddSheet(workbook, scannedData.ReferencingObjects);
                AddSheet(workbook, scannedData.SqlObjects);
                AddSheet(workbook, scannedData.SqlTables);
                AddSheet(workbook, scannedData.SqlTableColumns);
                AddSheet(workbook, scannedData.SqlKeyConstraints);
                AddSheet(workbook, scannedData.SqlForeignKeyConstraints);
                AddSheet(workbook, scannedData.SqlTableIndexes);
                AddSheet(workbook, scannedData.SqlTableColumnDependencies);

                workbook.SaveAs(filePath);
                Console.WriteLine("Report generated: " + filePath);
            }
        }

        private void AddSourceObjectSheet(XLWorkbook workbook)
        {
            // Add Source Object List Sheet
            IXLWorksheet worksheet = workbook.Worksheets.Add("Source Object List");
            worksheet.Cell(1, 1).Value = "No";
            worksheet.Cell(1, 2).Value = "Type";
            worksheet.Cell(1, 3).Value = "Database Name";
            worksheet.Cell(1, 4).Value = "SchemaName";
            worksheet.Cell(1, 5).Value = "Name";
            worksheet.Cell(1, 6).Value = "Definition";

            int currentRow = 2;
            int index = 1;
            foreach (var routine in this.scannedData.SourceRoutineObjects)
            {
                worksheet.Cell(currentRow, 1).Value = index;
                worksheet.Cell(currentRow, 2).Value = routine.RoutineType;
                worksheet.Cell(currentRow, 3).Value = routine.DatabaseName;
                worksheet.Cell(currentRow, 4).Value = routine.SchemaName;
                worksheet.Cell(currentRow, 5).Value = routine.RoutineName;
                if (routine.RoutineDefinition.Length > 32767) //32767 is the max length that excel cell can hold
                {
                    worksheet.Cell(currentRow, 6).Value = routine.RoutineDefinition.Substring(0, 32766);
                }
                else
                {
                    worksheet.Cell(currentRow, 6).Value = routine.RoutineDefinition;
                }

                currentRow++;
                index++;
            }
        }

        private void AddDependenciesSheet(XLWorkbook workbook)
        {
            // Add Dependencies List Sheet
            IXLWorksheet worksheet = workbook.Worksheets.Add("Dependencies List");
            worksheet.Cell(1, 1).Value = "No";
            worksheet.Cell(1, 2).Value = "Database Name";
            worksheet.Cell(1, 3).Value = "Type";
            worksheet.Cell(1, 4).Value = "Schema";
            worksheet.Cell(1, 5).Value = "Procedure Id";
            worksheet.Cell(1, 6).Value = "Procedure Name";

            worksheet.Cell(1, 7).Value = "Referenced Object Id";
            worksheet.Cell(1, 8).Value = "Referenced Object Type";
            worksheet.Cell(1, 9).Value = "Referenced Object ClassDescription";
            worksheet.Cell(1, 10).Value = "Referenced Object DatabaseName";
            worksheet.Cell(1, 11).Value = "Referenced Object SchemaName";
            worksheet.Cell(1, 12).Value = "Referenced Object EntityName";

            int currentRow = 2;
            int index = 1;
            foreach (var reference in this.scannedData.ReferencingObjects)
            {
                worksheet.Cell(currentRow, 1).Value = index;
                worksheet.Cell(currentRow, 2).Value = reference.SourceDatabaseName;
                worksheet.Cell(currentRow, 3).Value = reference.SourceObjectType;
                worksheet.Cell(currentRow, 4).Value = reference.SourceObjectSchemaName;
                worksheet.Cell(currentRow, 5).Value = reference.SourceObjectId;
                worksheet.Cell(currentRow, 6).Value = reference.SourceObjectName;

                worksheet.Cell(currentRow, 7).Value = reference.DependentObjectId;
                worksheet.Cell(currentRow, 8).Value = reference.DependentObjectType;
                worksheet.Cell(currentRow, 9).Value = reference.DependentObjectClassDescription;
                worksheet.Cell(currentRow, 10).Value = reference.DependentObjectDatabaseName;
                worksheet.Cell(currentRow, 11).Value = reference.DependentObjectSchemaName;
                worksheet.Cell(currentRow, 12).Value = reference.DependentObjectName;

                currentRow++;
                index++;
            }
        }



        private void AddSheet<T>(XLWorkbook workbook, IEnumerable<T> collection)
        {
            if (collection == null || !collection.Any())
                return;

            var properties = typeof(T).GetProperties();
            IXLWorksheet worksheet = workbook.Worksheets.Add(typeof(T).Name);
            
            worksheet.Cell(1, 1).Value = "No";
            int col = 2;
            foreach (var property in properties) 
            {
                worksheet.Cell(1, col).Value = property.Name;
                col++;
            }

            int row = 2;
           
            int index = 1;
            foreach (var item in collection)
            {
                worksheet.Cell(row, 1).Value = index;
                col = 2;
                foreach (var property in properties)
                {
                    worksheet.Cell(row, col).Value = property.GetValue(item)?.ToString() ?? string.Empty;
                   
                    col++;
                }
                index++;
                row++;
            }
        }
    }
}