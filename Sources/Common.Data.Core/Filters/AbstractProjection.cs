using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// Projection abstract class
	/// </summary>
    public abstract class AbstractProjection
	{
		/// <summary>
		/// Does this projection specify grouping attributes?
		/// </summary>
		public abstract bool IsGrouped { get; }

		/// <summary>
		/// Convert object to use in another abstract model of data filtering
		/// </summary>
		/// <param name="visitor"> The convertor </param>
        public abstract void AcceptConvert(IConvertor visitor);
	}
}
