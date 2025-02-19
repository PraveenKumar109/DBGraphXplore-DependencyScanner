namespace LogViewer.DataTypes
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using EventArgsTypes;
    using Facades;

    /// <summary>
    /// Facilitate Log Management
    /// </summary>
    public class Log : ILog
    {
        /// <summary>
        /// Collection of basic log item
        /// </summary>
        private readonly ICollection<LogItemBase> items;

        /// <summary>
        /// Initializes a new instance of the Log class.
        /// </summary>
        public Log()
        {
            this.items = new Collection<LogItemBase>();
        }

        /// <summary>
        /// Raise when a new log Item has been added to the Log
        /// </summary>
        public event EventHandler<LogItemBaseEventArgs> ItemAdded;

        /// <summary>
        /// Raise when Log has been cleared
        /// </summary>
        public event EventHandler<EventArgs> ItemsCleared;

        /// <summary>
        /// Gets Log Items.
        /// </summary>
        public ICollection<LogItemBase> Items
        {
            get
            {
                return this.items;
            }
        }

        /// <summary>
        /// Add new log item in the log
        /// </summary>
        /// <param name="item"> The log item.</param>
        public void Add(LogItemBase item)
        {
            this.items.Add(item);
            this.InvokeItemAdded(new LogItemBaseEventArgs(item));
        }

        /// <summary>
        /// Clear the Log collection
        /// </summary>
        public void Clear()
        {
            this.items.Clear();
            this.InvokeItemsCleared(new EventArgs());
        }

        /// <summary>
        /// Invoked ItemAdded
        /// </summary>
        /// <param name="e"> The object of LogItemBaseEventArgs type</param>
        private void InvokeItemAdded(LogItemBaseEventArgs e)
        {
            EventHandler<LogItemBaseEventArgs> handler = this.ItemAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Invoke ItemsCleared
        /// </summary>
        /// <param name="e"> The object of EventArgs type</param>
        private void InvokeItemsCleared(EventArgs e)
        {
            EventHandler<EventArgs> handler = this.ItemsCleared;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}