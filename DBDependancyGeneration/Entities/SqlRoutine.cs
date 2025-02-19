namespace DBGraphXplore.DatabaseScanner.Entities
{
    public class SqlRoutine
    {
        public string DatabaseName { get; set; }
        public string SchemaName { get; set; }
        public string RoutineType { get; set; }
        public string RoutineName { get; set; }
        public string RoutineDefinition { get; set; }
    }
}
