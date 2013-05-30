using System;
using Common.Data.Core.Filters;

namespace Common.Data.Core.Interfaces
{
	/// <summary>
	///	IFilter is a simplified API for retrieving entities by composing Qulix.Common.Filters.Expression objects.
	/// </summary>
    public interface IFilter
	{
		/// <summary>
		/// Create a new Filter, "rooted" at the associated entity, assigning the given alias and using the specified join type.
		/// </summary>
		/// <param name="associationPath">Property path</param>
		/// <param name="alias"> The alias to assign to the joined association (for later reference).</param>
		/// <param name="joinType">The type of join to use</param>
		/// <returns>The created "sub criteria"</returns>
		IFilter CreateCriteria(string associationPath, string alias, JoinType joinType);

        /// <summary>
        /// Create a new NHibernate.ICriteria, "rooted" at the associated entity, using the specified join type.
        /// </summary>
        /// <param name="associationPath">Property path</param>
        /// <param name="joinType">The type of join to use</param>
        /// <returns>The created "sub criteria"</returns>
        IFilter CreateCriteria(string associationPath, JoinType joinType);

		/// <summary>
		/// Преобразование объекта, для использования в другой объектной модели организации фильтрации данных
		/// </summary>
		/// <param name="visitor"> конвертор </param>
        void AcceptConvert(IConvertor visitor);

		/// <summary>
		/// Used to specify that the query results will be a projection (scalar in nature). Implicitly specifies the projection result transformer.
		/// </summary>
		/// <param name="projection">The projection representing the overall "shape" of the query results.</param>
		/// <returns></returns>
		IFilter AddProjection(AbstractProjection projection);

		/// <summary>
		/// Root object type
		/// </summary>
		Type PersistentClass
		{
			get;
			set;
		}

		/// <summary>
		/// Used to specify that the query results will be a projection (scalar in nature). Implicitly specifies the projection result transformer.
		/// </summary>
		/// <param name="projections">The projection list representing the overall "shape" of the query results.</param>
		/// <returns></returns>
		IFilter AddProjection(ProjectionList projections);

	    /// <summary>
	    /// Reset rows ordering
	    /// </summary>
	    /// <returns></returns>
	    IFilter ResetOrder();

	    /// <summary>
	    /// Used to specify that the query results will be a projection (scalar in nature). Implicitly specifies the projection result transformer.
	    /// </summary>
	    /// <param name="projection">The projection representing the overall "shape" of the query results.</param>
	    /// <param name="alias">The projection alias.</param>
	    /// <returns></returns>
	    IFilter AddProjection(AbstractProjection projection, string alias);
	}
}
