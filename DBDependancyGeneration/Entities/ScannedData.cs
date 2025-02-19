using DBGraphXplore.DatabaseScanner.Entities;

namespace DBGraphXplore.DatabaseScanner.Entities
{
    public class ScannedData
    {
        public List<SqlRoutine> SourceRoutineObjects { get; set; } = [];
        public List<ReferencingObject> ReferencingObjects { get; set; } = [];
        public List<SqlObject> SqlObjects { get; set; } = [];
        public List<SqlTable> SqlTables { get; set; } = [];
        public List<SqlTableColumn> SqlTableColumns { get; set; } = [];
        public List<SqlKeyConstraint> SqlKeyConstraints { get; set; } = [];
        public List<SqlForeignKeyConstraint> SqlForeignKeyConstraints { get; set; } = [];
        public List<SqlTableIndex> SqlTableIndexes { get; set; } = [];
        public List<SqlTableColumnDependency> SqlTableColumnDependencies { get; set; } = [];
    }
}
