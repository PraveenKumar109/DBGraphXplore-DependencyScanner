using DBGraphXplore.Core.EventHandlers;

namespace DBGraphXplore.DatabaseScanner.Scanner
{
    internal interface IDatabaseScanner
    {
        event EventHandler Started;
        event EventHandler<GenericEventHandler<long>> ProgressPercentageChanged;
        event EventHandler<GenericEventHandler<string>> ProgressChanged;
        event EventHandler Completed;

        void Scan();
    }
}
