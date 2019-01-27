﻿using System.Collections.Generic;

namespace SharePointLogViewer.Searching
{
    class LogEntryTokenizer: IEnumerable<string>
    {
        IEnumerable<LogEntryViewModel> logEntries;

        public LogEntryTokenizer(IEnumerable<LogEntryViewModel> logEntries)
        {
            this.logEntries = logEntries;
        }

        #region IEnumerable<string> Members

        public IEnumerator<string> GetEnumerator()
        {
            foreach (var entry in logEntries)
            {
                foreach (var token in entry.Message.Split(' '))
                    yield return token;
                yield return entry.Process;
                yield return entry.Category;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
