using System;

namespace Common.Data.Core.Filters
{
    /// <summary>
    /// ��������� ������� ���������� �������
    /// </summary>
    [Serializable]
    public class OrderEntry
    {
        /// <summary>
        /// ������� ����������
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public Filter Filter { get; set; }



        internal OrderEntry()
            : this(null, null) { }

        internal OrderEntry(Order order, Filter filter)
        {
            Order = order;
            Filter = filter;
        }
        
        ///<summary>
        ///Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Order.ToString();
        }
    }
}
