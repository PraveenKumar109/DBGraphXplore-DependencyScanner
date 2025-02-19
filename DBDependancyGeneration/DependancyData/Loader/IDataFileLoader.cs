using DBGraphXplore.DatabaseScanner.Entities;

namespace DBGraphXplore.DatabaseScanner.DependancyData.Loader
{
    public interface IDataFileLoader
    {
        public ScannedData Load(string filePath);
    }


}
