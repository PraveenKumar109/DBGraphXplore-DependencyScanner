namespace LogViewer.EventArgsTypes
{
    using System;
    using DataTypes;

    /// <summary>
    /// LogItemBaseEventArgs class
    /// </summary>
    public class LogItemBaseEventArgs : EventArgs
    {
        /// <summary>
        /// Represent LogItemBase item
        /// </summary>
        private readonly LogItemBase item;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogItemBaseEventArgs"/> class. 
        /// </summary>
        /// <param name="item">
        /// The object of LogItemBase
        /// </param>
        public LogItemBaseEventArgs(LogItemBase item)
        {
            this.item = item;
        }

        /// <summary>
        /// Gets Log Item
        /// </summary>
        public LogItemBase Item
        {
            get
            {
                return this.item;
            }
        }
    }
}