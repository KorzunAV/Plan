namespace Common.Data.Core.Interfaces
{
    /// <summary>
    /// Interface for converting search Criterias 
    /// </summary>
    /// TODO: CR: PYA: Convertor seems incorrect name
    /// TODO: CR: PYA-ANS: I have no ideas why this name is incorrect
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Convertor")]
    public interface IConvertor
    {
        #region Expressions

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(GeExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(InExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(LeExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(EqExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(GtExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(LikeExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(LtExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(OrExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(AndExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(NullExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(BetweenExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(NotExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(NotNullExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(IdentifierEqExpression exp);

        /// <summary>
        /// Converts the specified disjunction.
        /// </summary>
        /// <param name="disjunction">The disjunction.</param>
        void Convert(Disjunction disjunction);

        /// <summary>
        /// Converts the specified conjunction.
        /// </summary>
        /// <param name="conjunction">The conjunction.</param>
        void Convert(Conjunction conjunction);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(SQLCriterion exp);

        #endregion

        /// <summary>
        /// Converts the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        void Convert(Filter filter);

        #region SubQueries

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(PropertySubqueryExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(SimpleSubqueryExpression exp);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        void Convert(ExistsSubqueryExpression exp);

        #endregion

        #region Projections

        /// <summary>
        /// Converts the specified projection.
        /// </summary>
        /// <param name="projection">The projection.</param>
        void Convert(PropertyProjection projection);

        /// <summary>
        /// Converts the specified distinct.
        /// </summary>
        /// <param name="distinct">The distinct.</param>
        void Convert(Distinct distinct);

        /// <summary>
        /// Converts the specified projection.
        /// </summary>
        /// <param name="projection">The projection.</param>
        void Convert(CountProjection projection);

        /// <summary>
        /// Converts the specified having.
        /// </summary>
        /// <param name="having">The having.</param>
        void Convert(PropertyProjectionHaving having);

        /// <summary>
        /// Converts the specified projection.
        /// </summary>
        /// <param name="projection">The projection.</param>
        void Convert(AliasedProjection projection);

        /// <summary>
        /// Converts the specified list.
        /// </summary>
        /// <param name="list">The Projection list.</param>
        void Convert(ProjectionList list);

        /// <summary>
        /// Converts the specified projection.
        /// </summary>
        /// <param name="projection">The projection.</param>
        void Convert(SQLProjection projection);

        /// <summary>
        /// Converts the specified projection.
        /// </summary>
        /// <param name="projection">The projection.</param>
        void Convert(SQLGroupProjection projection);

        #endregion

        /// <summary>
        /// Converts the specified multi filter.
        /// </summary>
        /// <param name="multiFilter">The multi filter.</param>
        void Convert(MultiFilter multiFilter);
        
        /// <summary>
        /// Converts the specified projection.
        /// </summary>
        /// <param name="projection">The projection.</param>
        void Convert(AggregateProjection projection);
        
        /// <summary>
        /// Converts the specified projection.
        /// </summary>
        /// <param name="projection">The projection.</param>
        void Convert(CastProjection projection);

        /// <summary>
        /// Converts the specified projection.
        /// </summary>
        /// <param name="projection">The projection.</param>
        void Convert(ConditionalProjection projection);

        /// <summary>
        /// Converts the specified projection.
        /// </summary>
        /// <param name="projection">The projection.</param>
        void Convert(ConstantProjection projection);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        void Convert(LePropertyExpression expression);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        void Convert(GePropertyExpression expression);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        void Convert(ILikeExpression expression);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        void Convert(EqPropertyExpression expression);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        void Convert(LtPropertyExpression expression);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        void Convert(FullTextSearchExpression expression);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        void Convert(SQLFormatProjection expression);

        /// <summary>
        /// Converts the specified projection.
        /// </summary>
        /// <param name="projection">The projection.</param>
        void Convert(SumProjection projection);

        /// <summary>
        /// Converts the specified projection.
        /// </summary>
        /// <param name="projection">The projection.</param>
        void Convert(SqlFunctionProjection projection);

        /// <summary>
        /// Converts the specified projection.
        /// </summary>
        /// <param name="projection">The projection.</param>
        void Convert(GroupProjection projection);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        void Convert(FreeTextSearchExpression expression);

        /// <summary>
        /// Converts the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        void Convert(CharindexSearchExpression expression);
    }
}
