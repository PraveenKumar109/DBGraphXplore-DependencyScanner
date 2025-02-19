using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace DBGraphXplore.CodeAnalysis.DotNet
{
    public class DatabaseObjectExtractor
    {
        public List<DatabaseReference> ExtractDatabaseObjects(string solutionPath)
        {
            string solutionDirectory = Path.GetDirectoryName(solutionPath);
            List<string> projectPaths = GetProjectsFromSolution(solutionPath, solutionDirectory);
            List<DatabaseReference> allReferences = new List<DatabaseReference>();

            if (projectPaths.Count == 0)
            {
                Debug.WriteLine("No C# projects found in the solution.");
                return allReferences;
            }

            foreach (var projectPath in projectPaths)
            {
                Debug.WriteLine($"Processing project: {projectPath}");
                allReferences.AddRange(ProcessProject(projectPath));
            }

            return allReferences;
        }

        private List<string> GetProjectsFromSolution(string solutionFilePath, string solutionDirectory)
        {
            List<string> projectPaths = new List<string>();

            foreach (var line in File.ReadAllLines(solutionFilePath))
            {
                if (line.StartsWith("Project(") && line.Contains(".csproj"))
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 2)
                    {
                        string relativePath = parts[1].Trim().Trim('"');
                        string projectFullPath = Path.Combine(solutionDirectory, relativePath);
                        if (File.Exists(projectFullPath))
                        {
                            projectPaths.Add(projectFullPath);
                        }
                    }
                }
            }
            return projectPaths;
        }

        private List<DatabaseReference> ProcessProject(string projectPath)
        {
            List<DatabaseReference> references = new List<DatabaseReference>();
            string projectDirectory = Path.GetDirectoryName(projectPath);
            List<string> csFiles = GetCSharpFilesFromProject(projectPath, projectDirectory);

            foreach (var file in csFiles)
            {
                try
                {
                    var tree = Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree.ParseText(File.ReadAllText(file));
                    var root = tree.GetRoot();

                    references.AddRange(ExtractDatabaseReferences(root, file));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing file {file}: {ex.Message}");
                }
            }
            return references;
        }

        private List<string> GetCSharpFilesFromProject(string projectFilePath, string projectDirectory)
        {
            List<string> csFiles = new List<string>();

            System.Xml.Linq.XDocument doc = System.Xml.Linq.XDocument.Load(projectFilePath);
            //foreach (var element in doc.Root)
            //{
            //    //element.
            //    var includeAttr = element.Attribute("Include");
            //    if (includeAttr != null)
            //    {
            //        string filePath = Path.Combine(projectDirectory, includeAttr.Value);
            //        if (File.Exists(filePath))
            //        {
            //            csFiles.Add(filePath);
            //        }
            //    }
            //}
            return csFiles;
        }

        private List<DatabaseReference> ExtractDatabaseReferences(Microsoft.CodeAnalysis.SyntaxNode root, string filePath)
        {
            List<DatabaseReference> references = new List<DatabaseReference>();

            var invocations = root.DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.InvocationExpressionSyntax>();

            foreach (var invocation in invocations)
            {
                string methodName = invocation.Expression.ToString();

                if (methodName.Contains("ExecuteSqlCommand") || methodName.Contains("ExecuteSqlRaw") || methodName.Contains("FromSqlRaw"))
                {
                    var argumentList = invocation.ArgumentList.Arguments;
                    if (argumentList.Count > 0)
                    {
                        string sqlQuery = argumentList[0].ToString();
                        (string databaseName, string dbObjectName, string dbObjectType) = ExtractDatabaseDetails(sqlQuery);

                        references.Add(new DatabaseReference(
                            Path.GetFileName(filePath),
                            "UnknownNamespace",
                            Path.GetFileNameWithoutExtension(filePath),
                            methodName,
                            databaseName,
                            dbObjectName,
                            dbObjectType));
                    }
                }
            }
            return references;
        }

        private (string databaseName, string dbObjectName, string dbObjectType) ExtractDatabaseDetails(string sqlQuery)
        {
            string databaseName = "UnknownDatabase";
            string dbObjectName = "UnknownDBObject";
            string dbObjectType = "UnknownType";

            var match = System.Text.RegularExpressions.Regex.Match(sqlQuery, @"(?:FROM|JOIN|EXEC)\s+(?:\[?([^\]\[]+)\]?\.)?(?:\[?([^\]\[]+)\]?\.)?\[?([^\]\[]+)\]?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (match.Success)
            {
                databaseName = match.Groups[1].Success ? match.Groups[1].Value : "UnknownDatabase";
                dbObjectName = match.Groups[3].Success ? match.Groups[3].Value : "UnknownDBObject";

                if (System.Text.RegularExpressions.Regex.IsMatch(sqlQuery, @"\bEXEC\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    dbObjectType = "Stored Procedure";
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(sqlQuery, @"\bFROM\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    dbObjectType = "Table/View";
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(sqlQuery, @"\bFUNCTION\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    dbObjectType = "Function";
                }
            }

            return (databaseName, dbObjectName, dbObjectType);
        }
    }

    public class DatabaseReference
    {

        public string AssemblyName { get; set; }
        public string FileName { get; set; }
        public string NamespaceName { get; set; }
        public string ClassName { get; set; }
        public string FunctionName { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseObjectName { get; set; }
        public string DatabaseObjectType { get; set; }

        public DatabaseReference(string fileName, string namespaceName, string className, string functionName, string databaseName, string dbObjectName, string dbObjectType)
        {
            FileName = fileName;
            NamespaceName = namespaceName;
            ClassName = className;
            FunctionName = functionName;
            DatabaseName = databaseName;
            DatabaseObjectName = dbObjectName;
            DatabaseObjectType = dbObjectType;
        }

        public override string ToString()
        {
            return $"{FileName}.{NamespaceName}.{ClassName}.{FunctionName} → {DatabaseName}.{DatabaseObjectName} ({DatabaseObjectType})";
        }
    }

}
