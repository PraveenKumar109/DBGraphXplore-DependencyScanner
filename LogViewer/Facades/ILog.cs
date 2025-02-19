namespace LogViewer.Facades
{
    using System;
    using System.Collections.Generic;
    using DataTypes;
    using EventArgsTypes;

    /// <summary>
    /// Facilitate Log Management
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Raise when a new log Item has been added to the Log
        /// </summary>
        event EventHandler<LogItemBaseEventArgs> ItemAdded;

        /// <summary>
        /// Raise when Log has been cleared
        /// </summary>
        event EventHandler<EventArgs> ItemsCleared;

        /// <summary>
        /// Gets Log Items.
        /// </summary>
        ICollection<LogItemBase> Items
        {
            get;
        }

        /// <summary>
        /// Add new log item in the log
        /// </summary>
        /// <param name="item"> The log item.</param>
        void Add(LogItemBase item);

        /// <summary>
        /// Clear the Log collection
        /// </summary>
        void Clear();
    }
}