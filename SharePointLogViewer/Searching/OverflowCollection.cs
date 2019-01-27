﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace SharePointLogViewer.Searching
{
    class OverflowCollection<T>:ObservableCollection<T>
    {
        Func<T, bool> evictionCriterea;
        bool deferNotification;

        public int MaxItems { get; set; }

        public OverflowCollection(Func<T, bool> evictionCriterea) : base()
        {
            this.evictionCriterea = evictionCriterea;
        }

        public OverflowCollection(IEnumerable<T> collection) : base(collection) { }

        public void AddRange(IEnumerable<T> collection)
        {
            deferNotification = true;
            foreach (T itm in collection)
                Add(itm);
            deferNotification = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        } 

        protected override void InsertItem(int index, T item)
        {
            bool itemFound = false;
            T removeItem = default(T);

            if (MaxItems > 0 && Count == MaxItems)
                foreach (var target in Items)
                    if (evictionCriterea(target))
                    {
                        removeItem = target;
                        itemFound = true;
                        break;
                    }

            base.InsertItem(index, item);
            if (itemFound)
                Remove(removeItem);
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!deferNotification)
                base.OnCollectionChanged(e);
        }
    }
}
