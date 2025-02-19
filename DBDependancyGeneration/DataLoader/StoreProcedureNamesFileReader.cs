namespace DBGraphXplore.DatabaseScanner.DataLoader
{
    using System.Collections.Generic;
    using System.IO;

    public class StoreProcedureNamesFileReader
    {
        public List<string> Load(string filePath)
        {
            List<string> procedureNames = new List<string>();
            File.ReadAllLines(filePath).ToList().ForEach(line => procedureNames.Add(line.Trim()));
            return procedureNames;
        }
    }

}
