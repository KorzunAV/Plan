using System;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// Абстрактный класс подзапроса
	/// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Subquery", Justification = "Standard shortage"), Serializable]
    public abstract class SubqueryExpression: AbstractExpression
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		protected SubqueryExpression()
		{
		}

		private Filter _criteriaImpl;
		private String _expressionIdentifier;
		
		/// <summary>
		/// Выражение
		/// </summary>
		public string ExpressionIdentifier
		{
			get { return _expressionIdentifier; }
			set { _expressionIdentifier = value; }
		}

		/// <summary>
		/// Подзапрос
		/// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Impl", Justification = "Standard shortage")]
		public Filter CriteriaImpl
		{
			get { return _criteriaImpl; }
			set { _criteriaImpl = value; }
		}

	    /// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="identifier">Идентификатор выражения(константа в SubQuery class)</param>
		/// <param name="filter">Фильтр</param>
		protected SubqueryExpression(String identifier, Filter filter)
		{
			_criteriaImpl = filter;
			_expressionIdentifier = identifier;
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

	    /// <summary>
	    /// Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
	    /// </summary>
	    /// <returns>
	    /// A hash code for the current <see cref="T:System.Object"></see>.
	    /// </returns>
	    /// <filterpriority>2</filterpriority>
	    public override int GetHashCode()
	    {
	        return CriteriaImpl.GetHashCode() + _expressionIdentifier.GetHashCode();
	    }
	}
}
