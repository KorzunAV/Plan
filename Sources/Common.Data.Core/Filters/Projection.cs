using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// The <tt>criterion</tt> package may be used by applications as a framework for building
	/// new kinds of <tt>Projections</tt>. However, it is intended that most applications will
	/// simply use the built-in projection types via the static factory methods of this class.<br/>
	/// <br/>
	/// The factory methods that take an alias allow the projected value to be referred to by 
	/// criterion and order instances.
	/// </summary>
	[Serializable]
    [CLSCompliant(false)]
	public class Projections
	{
	    public const string AGGREGATE_MAX = "max";
	    public const string AGGREGATE_MIN = "min";
	    public const string AGGREGATE_SUM = "sum";

	    private Projections()
		{
			// Private Constructor, never called.
		}

		/// <summary>
		/// Create a distinct projection from a projection
		/// </summary>
		/// <param name="projection"></param>
		/// <returns></returns>
		public static AbstractProjection Distinct(AbstractProjection projection)
		{
			return new Distinct(projection);
		}

		/// <summary>
		/// The query row count, ie. <tt>count(*)</tt>
		/// </summary>
		/// <returns></returns>
		public static AbstractProjection RowCount()
		{
		    return new RowCountProjection();
		}

		/// <summary>
		/// A property value count
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		public static CountProjection Count(string propertyName)
		{
		    return new CountProjection(propertyName);
		}

        /// <summary>
        /// A property value count
        /// </summary>
        /// <returns></returns>
        public static SqlProjection CountOne()
        {
            return new SqlProjection("count(1) as CountValue", new[]{"CountValue"}, new []{FilterDataType.Int});
        }

		/// <summary>
		/// A distinct property value count
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		public static CountProjection CountDistinct(string propertyName)
		{
		    return new CountProjection(propertyName).SetDistinct();
		}

		/// <summary>
		/// A property maximum value
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		public static AggregateProjection Max(String propertyName)
		{
		    return new AggregateProjection(AGGREGATE_MAX, propertyName);
		}

		/// <summary>
		/// A property minimum value
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		public static AggregateProjection Min(String propertyName)
		{
		    return new AggregateProjection(AGGREGATE_MIN, propertyName);
		}

		/// <summary>
		/// A property average value
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Avg", Justification = "Standard shortage")]
		public static AggregateProjection Avg(string propertyName)
		{
		    return new AvgProjection(propertyName);
		}

		/// <summary>
		/// A property value sum
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		public static AggregateProjection Sum(String propertyName)
		{
		    return new AggregateProjection(AGGREGATE_SUM, propertyName);
		}

        /// <summary>
        /// A property value sum
        /// </summary>
        /// <param name="projection"></param>
        /// <returns></returns>
        public static AbstractProjection Sum(AbstractProjection projection)
        {
            return new SumProjection(projection);
        }

        /// <summary>
        /// A property value sum
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="castToBool">Cast result to bool</param>
        /// <returns></returns>
        public static AbstractProjection Sum(AbstractProjection projection, bool castToBool)
        {
            return new SumProjection(projection, castToBool);
        }

		/// <summary>
		/// A SQL projection, a typed select clause fragment
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="columnAliases"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public static AbstractProjection SqlProjection(string sql, string[] columnAliases, FilterDataType[] type)
		{
			return new SqlProjection(sql, columnAliases, type);
		}

		/// <summary>
		/// A grouping SQL projection, specifying both select clause and group by clause fragments
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="groupBy"></param>
		/// <param name="columnAliases"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public static AbstractProjection SqlGroupProjection(string sql, string groupBy, string[] columnAliases, FilterDataType[] type)
		{
			return new SQLGroupProjection(sql, groupBy, columnAliases, type);
		}

        /// <summary>
        /// An SQL projection, that renders properties as if they were added via PropertyProjection
        /// </summary>
        /// <param name="formatSql">SQL format string the properties should be put in.</param>
        /// <param name="properties">The properties.</param>
        /// <param name="columnAliases">The column aliases.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        public static AbstractProjection SqlFormatProjection(string formatSql, string[] properties, string[] columnAliases, FilterDataType[] types)
        {
            return new SQLFormatProjection(formatSql, properties, columnAliases, types);
        }

		/// <summary>
		/// A grouping property value
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		public static PropertyProjection GroupProperty(string propertyName)
		{
            return new PropertyProjection(propertyName, true);
		}
        
		/// <summary>
		/// A projected property value
		/// </summary>
		/// <param name="propertyName">Property name</param>
		/// <returns></returns>
		public static AbstractProjection Property(string propertyName)
		{
			return new PropertyProjection(propertyName);
		}

        /// <summary>
        /// A projected property value
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="groupProperty">if set to <c>true</c> [group property].</param>
        /// <returns></returns>
        public static AbstractProjection Property(string propertyName, bool groupProperty)
        {
            return new PropertyProjection(propertyName, groupProperty);
        }

	    /// <summary>
		/// A projected property value
		/// </summary>
		/// <param name="projection">Projection object</param>
		/// <param name="propertiesToGroup">Properties from projectionToGroup</param>
		/// <returns></returns>
		public static AbstractProjection Group(AbstractProjection projection, params string [] propertiesToGroup)
		{
			return new GroupProjection(projection, propertiesToGroup);
		}

		/// <summary>
        /// Create a new projection list
        /// </summary>
        /// <returns></returns>
        public static ProjectionList ProjectionList()
        {
            return new ProjectionList();
        }

		///// <summary>
		///// A projected identifier value
		///// </summary>
		///// <returns></returns>
		//public static IdentifierProjection Id()
		//{
		//    return new IdentifierProjection();
		//}

        /// <summary>
        /// Assign an alias to a projection, by wrapping it
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        public static AbstractProjection Alias(AbstractProjection projection, string alias)
        {
            return new AliasedProjection(projection, alias);
        }

        /// <summary>
        /// Casts the projection result to the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="projection">The projection.</param>
        /// <returns></returns>
        public static AbstractProjection Cast(FilterDataType type, AbstractProjection projection)
        {
            return new CastProjection(type, projection);
        }

        /// <summary>
        /// Conditionally return the true or false part, dependention on the criterion
        /// </summary>
        /// <param name="criterion">The criterion.</param>
        /// <param name="whenTrue">The when true.</param>
        /// <param name="whenFalse">The when false.</param>
        /// <returns></returns>
        public static AbstractProjection Conditional(AbstractExpression criterion, AbstractProjection whenTrue, AbstractProjection whenFalse)
        {
            return new ConditionalProjection(criterion, whenTrue, whenFalse);
        }

        /// <summary>
        /// Return a constant value
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static AbstractProjection Constant(object obj)
        {
            return new ConstantProjection(obj);
        }

        /// <summary>
        /// Returns constant true projection
        /// </summary>
        /// <returns></returns>
        public static AbstractProjection True()
        {
            return new ConstantProjection(true);
        }
    
        /// <summary>
        /// Returns constant false projection
        /// </summary>
        /// <returns></returns>
        public static AbstractProjection False()
        {
            return new ConstantProjection(false);
        }

        /// <summary>
        /// Returns constant null projection
        /// </summary>
        /// <returns></returns>
	    public static AbstractProjection Null(FilterDataType type)
	    {
	        return SqlProjection("NULL as nullColumn", new[] {"nullColumn"}, new[] {type});
	    }

        /// <summary>
		/// Calls the named SQL Function
		/// </summary>
		/// <param name="functionName">Name of the function.</param>
		/// <param name="type">The type.</param>
		/// <param name="projections">The projections.</param>
		/// <returns></returns>
		public static AbstractProjection SqlFunction(string functionName, FilterDataType type, params AbstractProjection [] projections)
		{
			return new SqlFunctionProjection(functionName, type, projections);
		}

        /// <summary>
        /// Create sql CASE statement <br/>
        /// for example<br/> 
        /// <example>
        ///  case<br/>
        ///     when Expression1 then Projection 1 <br/>
        ///     when Expression2 then Projection 2<br/>
        ///     when Expression3 then Projection 3<br/>
        ///     else elseProjection <br/>
        ///  end<br/>
        /// </example>
        /// </summary>
        /// <param name="whenThenExpressions">List of pairs of WhenExpression/ThenProjection's</param>
        /// <param name="elseProjection">Projection for else</param>
        /// <param name="alias">Alias of projection</param>
        /// <param name="filterDataType">Type of result projection</param>
        /// <returns>Projection</returns>
        public static AbstractProjection Case(List<KeyValuePair<AbstractExpression, AbstractProjection>> whenThenExpressions, AbstractProjection elseProjection, string alias, FilterDataType filterDataType)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("(case ");
            foreach (var whenThenExpression in whenThenExpressions)
            {
                sb.AppendFormat(" when ");
                sb.Append(whenThenExpression.Key);
                sb.AppendFormat(" then ");
                sb.Append(whenThenExpression.Value);
            }
            sb.Append(" else ");
            sb.Append(elseProjection);
            sb.Append(" end )");
            sb.AppendFormat(" as {0}", alias);

            string sql = sb.ToString();

            return SqlProjection(sql, new[] { alias }, new[] { filterDataType });
        }
	}
}
