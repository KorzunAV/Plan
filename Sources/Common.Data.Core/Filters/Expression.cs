using System;
using System.Collections;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// The <c>Expression</c> namespace may be used by applications as a framework for building 
	/// new kinds of <see cref="AbstractExpression" />. However, it is intended that most applications will 
	/// simply use the built-in criterion types via the static factory methods of this class.
	/// </summary>
    [CLSCompliant(false)]
	public sealed class Expression
	{
		private Expression()
		{
			// can not be instantiated
		}

		/// <summary>
		/// Apply an "equal" constraint to the identifier property
		/// </summary>
		/// <param name="value"></param>
		/// <returns>AbstractExpression</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Eq", Justification = "Standard shortage")]
		public static AbstractExpression IdEq(object value)
		{
			return new IdentifierEqExpression(value);
		}

		/// <summary>
		/// Group expressions together in a single conjunction (A and B and C...)
		/// </summary>
		public static Conjunction Conjunction()
		{
			return new Conjunction();
		}

		/// <summary>
		/// Group expressions together in a single disjunction (A or B or C...)
		/// </summary>
		public static Disjunction Disjunction()
		{
			return new Disjunction();
		}

        /// <summary>
		/// Expression that always has false value
		/// </summary>
		public static Disjunction False()
		{
			return new Disjunction();
		}

        /// <summary>
		/// Expression that always has true value
		/// </summary>
		public static Conjunction True()
		{
			return new Conjunction();
		}

		/// <summary>
		/// Apply an "equal" constraint to the named property
		/// </summary>
		/// <param name="propertyName">The name of the Property in the class.</param>
		/// <param name="value">The value for the Property.</param>
		/// <returns>An <see cref="EqExpression" />.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Eq", Justification = "Standard shortage")]
		public static SimpleExpression Eq(string propertyName, object value)
		{
			return new EqExpression(propertyName, value);
		}

        /// <summary>
        /// Apply a "like" constraint to the named property
        /// </summary>
        /// <param name="propertyName">The name of the Property in the class.</param>
        /// <param name="value">The value for the Property.</param>
        /// <returns>A <see cref="LikeExpression" />.</returns>
        /// <param name="matchMode">Режим сравнения</param>
        public static AbstractExpression Like(string propertyName, string value, MatchMode matchMode)
        {
            return new LikeExpression(propertyName, value, matchMode);
        }

        /// <summary>
        /// Apply a "like" constraint to the named property
        /// </summary>
        /// <param name="propertyName">The name of the Property in the class.</param>
        /// <param name="value">The value for the Property.</param>
        /// <returns>A <see cref="LikeExpression" />.</returns>
        /// <param name="matchMode">Режим сравнения</param>
        /// <param name="escapeCharacter">Escape character</param>
        public static AbstractExpression Like(string propertyName, string value, MatchMode matchMode, char escapeCharacter)
        {
            return new LikeExpression(propertyName, value, escapeCharacter, matchMode);
        }

        /// <summary>
        /// Apply a "like" constraint to the named property
        /// </summary>
        /// <param name="propertyName">The name of the Property in the class.</param>
        /// <param name="value">The value for the Property.</param>
        /// <returns>A <see cref="LikeExpression" />.</returns>
        /// <param name="matchMode">Режим сравнения</param>
        public static AbstractExpression ILike(string propertyName, string value, MatchMode matchMode)
        {
            return new ILikeExpression(propertyName, value, matchMode);
        }

		/// <summary>
		/// Apply a "greater than" constraint to the named property
		/// </summary>
		/// <param name="propertyName">The name of the Property in the class.</param>
		/// <param name="value">The value for the Property.</param>
		/// <returns>A <see cref="GtExpression" />.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Gt", Justification = "Standard shortage")]
		public static SimpleExpression Gt(string propertyName, object value)
		{
			return new GtExpression(propertyName, value);
		}

		/// <summary>
		/// Apply a "less than" constraint to the named property
		/// </summary>
		/// <param name="propertyName">The name of the Property in the class.</param>
		/// <param name="value">The value for the Property.</param>
		/// <returns>A <see cref="LtExpression" />.</returns>
		public static SimpleExpression Lt(string propertyName, object value)
		{
			return new LtExpression(propertyName, value);
		}

		/// <summary>
		/// Apply a "less than or equal" constraint to the named property
		/// </summary>
		/// <param name="propertyName">The name of the Property in the class.</param>
		/// <param name="value">The value for the Property.</param>
		/// <returns>A <see cref="LeExpression" />.</returns>
		public static SimpleExpression Le(string propertyName, object value)
		{
			return new LeExpression(propertyName, value);
		}

		/// <summary>
		/// Apply a "greater than or equal" constraint to the named property
		/// </summary>
		/// <param name="propertyName">The name of the Property in the class.</param>
		/// <param name="value">The value for the Property.</param>
		/// <returns>A <see cref="GtExpression" />.</returns>
		public static SimpleExpression Ge(string propertyName, object value)
		{
			return new GeExpression(propertyName, value);
		}

		/// <summary>
		/// Apply a "between" constraint to the named property
		/// </summary>
		/// <param name="propertyName">The name of the Property in the class.</param>
		/// <param name="lo">The low value for the Property.</param>
		/// <param name="hi">The high value for the Property.</param>
		/// <returns>A <see cref="BetweenExpression" />.</returns>
		public static AbstractExpression Between(string propertyName, object lo, object hi)
		{
			return new BetweenExpression(propertyName, lo, hi);
		}

        /// <summary>
        /// Apply a "between" constraint to the named property
        /// </summary>
        /// <param name="propertyName">The name of the Property in the class.</param>
        /// <param name="loProperty">The low Property for the Property.</param>
        /// <param name="hiProperty">The high Property for the Property.</param>
        /// <returns>A <see cref="BetweenExpression" />.</returns>
        public static AbstractExpression PropertyBetween(string propertyName, string loProperty, string hiProperty)
        {
            return new PropertyBetweenExpression(propertyName, loProperty, hiProperty);
        }

		/// <summary>
		/// Apply an "in" constraint to the named property 
		/// </summary>
		/// <param name="propertyName">The name of the Property in the class.</param>
		/// <param name="values">An array of values.</param>
		/// <returns>An <see cref="InExpression" />.</returns>
		public static AbstractExpression In(string propertyName, object[] values)
		{
			return new InExpression(propertyName, values);
		}

		/// <summary>
		/// Apply an "in" constraint to the named property
		/// </summary>
		/// <param name="propertyName">The name of the Property in the class.</param>
		/// <param name="values">An ICollection of values.</param>
		/// <returns>An <see cref="InExpression" />.</returns>
		public static AbstractExpression In(string propertyName, ICollection values)
		{
			object[] ary = new object[values.Count];
			values.CopyTo(ary, 0);
			return new InExpression(propertyName, ary);
		}

#if NET_2_0
    /// <summary>
    /// Apply an "in" constraint to the named property. This is the generic equivalent
    /// of <see cref="In(string, ICollection)" />, renamed to avoid ambiguity.
    /// </summary>
    /// <param name="propertyName">The name of the Property in the class.</param>
    /// <param name="values">An <see cref="System.Collections.Generic.ICollection{T}" />
    /// of values.</param>
    /// <returns>An <see cref="InExpression" />.</returns>
		public static ICriterion InG<T>(string propertyName, System.Collections.Generic.ICollection<T> values)
		{
			object[] array = new object[values.Count];
			int i = 0;
			foreach (T item in values)
			{
				array[i] = item;
				i++;
			}
			return new InExpression(propertyName, array);
		}
#endif

		/// <summary>
		/// Apply an "is null" constraint to the named property
		/// </summary>
		/// <param name="propertyName">The name of the Property in the class.</param>
		/// <returns>A <see cref="NullExpression" />.</returns>
		public static AbstractExpression IsNull(string propertyName)
		{
			return new NullExpression(propertyName);
		}

		/// <summary>
		/// Apply an "equal" constraint to two properties
		/// </summary>
		/// <param name="propertyName">The lhs Property Name</param>
		/// <param name="otherPropertyName">The rhs Property Name</param>
		/// <returns>A <see cref="EqPropertyExpression"/> .</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Eq", Justification = "Standard shortage")]
		public static AbstractExpression EqProperty(string propertyName, string otherPropertyName)
		{
			return new EqPropertyExpression(propertyName, otherPropertyName);
		}

		/// <summary>
		/// Apply an "not equal" constraint to two properties
		/// </summary>
		/// <param name="propertyName">The lhs Property Name</param>
		/// <param name="otherPropertyName">The rhs Property Name</param>
		/// <returns>A <see cref="EqPropertyExpression"/> .</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Eq", Justification = "Standard shortage")]
		public static AbstractExpression NotEqProperty(string propertyName, string otherPropertyName)
		{
			return new NotExpression(new EqPropertyExpression(propertyName, otherPropertyName));
		}

		/// <summary>
		/// Apply a "greater than" constraint to two properties
		/// </summary>
		/// <param name="propertyName">The lhs Property Name</param>
		/// <param name="otherPropertyName">The rhs Property Name</param>
		/// <returns>A <see cref="LtPropertyExpression"/> .</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Gt", Justification = "Standard shortage")]
		public static AbstractExpression GtProperty(string propertyName, string otherPropertyName)
		{
			return new GtPropertyExpression(propertyName, otherPropertyName);
		}

		/// <summary>
		/// Apply a "greater than or equal" constraint to two properties
		/// </summary>
		/// <param name="propertyName">The lhs Property Name</param>
		/// <param name="otherPropertyName">The rhs Property Name</param>
		/// <returns>A <see cref="LePropertyExpression"/> .</returns>
		public static AbstractExpression GeProperty(string propertyName, string otherPropertyName)
		{
			return new GePropertyExpression(propertyName, otherPropertyName);
		}

		/// <summary>
		/// Apply a "less than" constraint to two properties
		/// </summary>
		/// <param name="propertyName">The lhs Property Name</param>
		/// <param name="otherPropertyName">The rhs Property Name</param>
		/// <returns>A <see cref="LtPropertyExpression"/> .</returns>
		public static AbstractExpression LtProperty(string propertyName, string otherPropertyName)
		{
			return new LtPropertyExpression(propertyName, otherPropertyName);
		}

		/// <summary>
		/// Apply a "less than or equal" constraint to two properties
		/// </summary>
		/// <param name="propertyName">The lhs Property Name</param>
		/// <param name="otherPropertyName">The rhs Property Name</param>
		/// <returns>A <see cref="LePropertyExpression"/> .</returns>
		public static AbstractExpression LeProperty(string propertyName, string otherPropertyName)
		{
			return new LePropertyExpression(propertyName, otherPropertyName);
		}

		/// <summary>
		/// Apply an "is not null" constraint to the named property
		/// </summary>
		/// <param name="propertyName">The name of the Property in the class.</param>
		/// <returns>A <see cref="NotNullExpression" />.</returns>
		public static AbstractExpression IsNotNull(string propertyName)
		{
			return new NotNullExpression(propertyName);
		}

        /// <summary>
        /// Return the conjuction of specified expressions.
        /// NOTE! At least 2 expressions must be specified
        /// </summary>
        /// <returns>An <see cref="AndExpression" />.</returns>
        public static AbstractExpression And(params AbstractExpression[] abstractExpressions)
        {
            // TODO: AGO: exctract common implementation for 'Or' and 'And'

            if (abstractExpressions == null)
                throw new ArgumentNullException("abstractExpressions");
            if (abstractExpressions.Length < 2)
                throw new ArgumentOutOfRangeException("abstractExpressions", "At least 2 expressions must be specified for 'And' operator");

            AbstractExpression result = new AndExpression(abstractExpressions[0], abstractExpressions[1]);
            for (int i = 2; i < abstractExpressions.Length; i++)
            {
                result = new AndExpression(result, abstractExpressions[i]);
            }
            return result;
        }

        /// <summary>
        /// Return the conjuction of specified expressions.
        /// NOTE! At least 2 expressions must be specified
        /// </summary>
        /// <returns>An <see cref="OrExpression" />.</returns>
        public static AbstractExpression Or(params AbstractExpression[] abstractExpressions)
        {
            // TODO: AGO: exctract common implementation for 'Or' and 'And'

            if (abstractExpressions == null)
                throw new ArgumentNullException("abstractExpressions");
            if (abstractExpressions.Length < 2)
                throw new ArgumentOutOfRangeException("abstractExpressions", "At least 2 expressions must be specified for 'Or' operator");

            AbstractExpression result = new OrExpression(abstractExpressions[0], abstractExpressions[1]);
            for (int i = 2; i < abstractExpressions.Length; i++)
            {
                result = new OrExpression(result, abstractExpressions[i]);
            }
            return result;
        }

		/// <summary>
		/// Return the negation of an expression
		/// </summary>
		/// <param name="expression">The Expression to negate.</param>
		/// <returns>A <see cref="NotExpression" />.</returns>
		public static AbstractExpression Not(AbstractExpression expression)
		{
			return new NotExpression(expression);
		}

		/// <summary>
		/// Apply a constraint expressed in SQL
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public static AbstractExpression Sql(string sql)
		{
			return Sql(sql, new object[0], new object[0]);
		}

		/// <summary>
		/// Apply a constraint expressed in SQL, with the given SQL parameter
		/// </summary>
		private static AbstractExpression Sql(string sql, object[] values, object [] types)
		{
			return new SQLCriterion(sql, values, types);
		}

        /// <summary>
        /// Return expression checking is null condition or equality to some value
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="value">Value</param>
        /// <returns>Abstract expression</returns>
        public static AbstractExpression IsNullOrEqual(string propertyName, object value)
        {
            return Or(IsNull(propertyName), Eq(propertyName, value));
        }
	}
}
