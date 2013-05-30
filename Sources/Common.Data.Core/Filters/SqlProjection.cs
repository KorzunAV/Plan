using System;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// A SQL fragment. The string {alias} will be replaced by the alias of the root entity.
	/// </summary>
	[Serializable]
	public sealed class SqlProjection : AbstractProjection
	{
		private readonly string _sql;
		private readonly FilterDataType[] _types;
		private readonly string[] _aliases;
		private readonly string[] _columnAliases;

		internal SqlProjection(string sql, string[] columnAliases, FilterDataType[] type)
		{
            _sql = sql;
			_types = type;
			_aliases = columnAliases;
			_columnAliases = columnAliases;
		}

		public override string ToString()
		{
			return _sql;
		}

        /// <summary>
        /// Gets the aliases.
        /// </summary>
        /// <returns></returns>
		public string[] GetAliases()
		{
			return _aliases;
		}

        /// <summary>
        /// Gets the SQL.
        /// </summary>
        /// <value>The SQL.</value>
		public string Sql
		{
			get { return _sql; }
		}

        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <returns></returns>
		public FilterDataType[] GetTypes()
		{
			return _types;
		}

        /// <summary>
        /// Gets the column aliases.
        /// </summary>
        /// <returns></returns>
		public string[] GetColumnAliases()
		{
			return _columnAliases;
		}

        /// <summary>
        /// Gets the column aliases.
        /// </summary>
        /// <param name="loc">The loc.</param>
        /// <returns></returns>
		public string[] GetColumnAliases(int loc)
		{
			return _columnAliases;
		}

        /// <summary>
        /// Does this projection specify grouping attributes?
        /// </summary>
        /// <value></value>
		public override bool IsGrouped
		{
			get { return false; }
		}


        /// <summary>
        /// Convert object to use in another abstract model of data filtering
        /// </summary>
        /// <param name="visitor">The convertor</param>
		public override void AcceptConvert(IConvertor visitor)
		{
			visitor.Convert(this);
		}
	}
}
