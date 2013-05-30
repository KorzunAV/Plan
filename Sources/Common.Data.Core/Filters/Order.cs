using System;

namespace Common.Data.Core.Filters
{
    /// <summary>
    /// Represents an order
    /// result set.
    /// </summary>
    [Serializable]
    public class Order
    {
        private readonly bool _ascending;
        private readonly string _propertyName;

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>The name of the property.</value>
        public string PropertyName
        {
            get { return _propertyName; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Order"/> is ascending.
        /// </summary>
        /// <value><c>true</c> if ascending; otherwise, <c>false</c>.</value>
        public bool Ascending
        {
            get { return _ascending; }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order() { }

        /// <summary>
        /// Constructor for Order.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="ascending"></param>
        public Order(string propertyName, bool ascending)
        {
            _propertyName = propertyName;
            _ascending = ascending;
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
            return PropertyName + (_ascending ? " asc" : " desc");
        }

        /// <summary>
        /// Ascending order
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Asc", Justification = "Standard shortage")]
        public static Order Asc(string propertyName)
        {
            return new Order(propertyName, true);
        }

        /// <summary>
        /// Descending order
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Desc", Justification = "Standard shortage")]
        public static Order Desc(string propertyName)
        {
            return new Order(propertyName, false);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"></see>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }
    }
}
