using System;
using System.Collections.Generic;

namespace Common.Data.Core.Filters
{
    /// <summary>
    /// A sequence of logical <see cref="AbstractExpression"/>s combined by some associative
    /// logical operator.
    /// </summary>
    [Serializable]
    public abstract class Junction : AbstractExpression
    {
        private List<AbstractExpression> _criteria = new List<AbstractExpression>();

        /// <summary>
        /// Logical <see cref="AbstractExpression"/>s
        /// </summary>
        public List<AbstractExpression> Criteria
        {
            get { return _criteria; }
            set { _criteria = value; }
        }

        /// <summary>
        /// Adds an <see cref="AbstractExpression"/> to the list of <see cref="AbstractExpression"/>s
        /// to junction together.
        /// </summary>
        /// <param name="criterion">The <see cref="AbstractExpression"/> to add.</param>
        /// <returns>
        /// This <see cref="Junction"/> instance.
        /// </returns>
        public Junction Add(AbstractExpression criterion)
        {
            _criteria.Add(criterion);
            return this;
        }

        /// <summary>
        /// Adds an <see cref="AbstractExpression"/> to the list of <see cref="AbstractExpression"/>s
        /// to junction together.
        /// </summary>
        /// <param name="criterions">The <see cref="AbstractExpression"/> to add.</param>
        /// <returns>
        /// This <see cref="Junction"/> instance.
        /// </returns>
        public Junction Add(params AbstractExpression[] criterions)
        {
            _criteria.AddRange(criterions);
            return this;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        protected Junction()
        {
        }

        /// <summary>
        /// Get the Sql operator to put between multiple <see cref="AbstractExpression"/>s.
        /// </summary>
        protected abstract String Op { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return '(' + string.Join(Op, _criteria) + ')';
        }
    }
}
