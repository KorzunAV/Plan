using System;

namespace Common.Data.Core.Filters
{
    /// <summary>
    /// Описывает критерий поиска
    /// </summary>
    [Serializable]
    public class CriterionEntry
    {
        private AbstractExpression _expression;
        private Filter _filter;

        /// <summary>
        /// Критерий отбора
        /// </summary>
        public AbstractExpression Expression
        {
            get { return _expression; }
            set { _expression = value; }
        }

        public Filter Filter
        {
            get { return _filter; }
            set { _filter = value; }
        }



        public CriterionEntry(AbstractExpression expression, Filter filter)
        {
            _expression = expression;
            _filter = filter;
        }

        public CriterionEntry() { }




        public override string ToString()
        {
            return _expression.ToString();
        }
    }
}
