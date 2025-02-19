namespace LogViewer.DataTypes
{
    /// <summary>
    /// Represent Log item
    /// </summary>
    public class LogItem : LogItemBase 
    {
        /// <summary>
        /// Contains log data
        /// </summary>
        private readonly string data;

        /// <summary>
        /// Initializes a new instance of the LogItem class.
        /// </summary>
        /// <param name="logData"> The log data. </param>
        public LogItem(string logData)
        {
            this.data = logData;
        }

        /// <summary>
        /// Gets log item data
        /// </summary>
        public string Data
        {
            get
            {
                return this.data;
            }
        }
    }
}