using System;

namespace Common.Data.Core
{
    public class OrderBy
    {
        public string Column { get; set; }
        public bool Asc { get; set; }

        public OrderBy()
        {
        }

        public OrderBy(string column, string asc)
        {
            Column = column;
            Asc = asc.Equals("asc", StringComparison.OrdinalIgnoreCase);
        }

        public OrderBy(string column, bool asc)
        {
            Column = column;
            Asc = asc;
        }
    }
}
