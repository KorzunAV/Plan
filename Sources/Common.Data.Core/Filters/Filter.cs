using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
    /// <summary>
    /// Filter is a simplified API for retrieving entities by composing <see cref="Expression"/> objects.
    /// </summary>
    /// <remarks>
    /// Using criteria is a very convenient approach for functionality like "search" screens where there is a variable number of conditions to be placed upon the result set.
    /// Expression instances are usually obtained via the factory methods on <see cref="Expression"/>. eg:
    /// (new Filter(typeof(Cat))) .Add( Expression.Like("name", "Iz%") ) .Add( Expression.Gt( "weight", minWeight ) ) .AddOrder( Order.Asc("age") ) .List(); 
    /// You may navigate associations using Qulix.Common.Interfaces.CreateCriteria(string associationPath, string alias, JoinType joinType).  
    /// (new Filter(typeof(Cat))) .CreateCriteria("kittens", "catKittens", JoinType.InnerJoin) .Add( Expression.like("name", "Iz%") );
    /// Hibernate's query language is much more general and should be used for non-simple cases.
    /// This is an Wrapper for NHibernate's Criterias experimental API.
    /// </remarks>
    [Serializable]
    public class Filter : IFilter
    {
        #region Fields
        private Hashtable _joinList;
        private List<CriterionEntry> _criteria;
        private Junction _junction;
        private Hashtable _subqueries;
        private Type _persistentClass;
        private string _persistentClassName;
        public string Alias { get; set; }
        public ProjectionList Projections { get; set; }
        public Hashtable Subqueries { get; set; }
        public List<OrderEntry> OrderEntries { get; set; }
        public Hashtable JoinList
        {
            get { return _joinList; }
        }
        public string PersistentClassName { get; set; }

        /// <summary>
        /// Критерии отбора
        /// </summary>
        public List<CriterionEntry> Criteria
        {
            get
            {
                _criteria.Clear();
                if (_junction != null)
                {
                    _criteria.Add(new CriterionEntry(_junction, this));
                }
                return _criteria;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Filter"/> used distinct.
        /// </summary>
        /// <value><c>true</c> if distinct used; otherwise, <c>false</c>.</value>
        public bool Distinct { get; set; }
        /// <summary>
        /// Gets or sets Number of first element in Page
        /// </summary>
        public int FirstResult { get; set; }
        /// <summary>
        /// Gets or sets the max results.
        /// </summary>
        /// <value>The max results.</value>
        public int MaxResult { get; set; }
        /// <summary>
        /// Root object type
        /// </summary>
        /// <value></value>
        [XmlIgnore]
        public Type PersistentClass
        {
            get
            {
                //looks like a hack. Для перестраховки
                if (_persistentClass == null)
                {
                    if (!string.IsNullOrEmpty(_persistentClassName))
                    {
                        // TODO: закоментирован т.к. теперь Qulix.DataAccess не будет знать о EntityBase
                        //_persistentClass = ReflectUtil.GetTypeByName(typeof(EntityBase),_persistentClassName);
                    }
                }
                return _persistentClass;

            }
            set { _persistentClass = value; }
        }

        #endregion

        #region [Конструктор]
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="persistentClass">Class for which filter created</param>
        public Filter(Type persistentClass)
            : this(persistentClass, string.Empty) { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="persistentClass">Class for which filter created</param>
        /// <param name="alias">Filter alias</param>
        public Filter(Type persistentClass, string alias)
        {
            _subqueries = new Hashtable();
            OrderEntries = new List<OrderEntry>();
            _joinList = new Hashtable();
            _criteria = new List<CriterionEntry>();
            Projections = new ProjectionList();
            _persistentClass = persistentClass;
            Alias = alias;
            MaxResult = -1;
        }

        protected Filter()
            : this(null) { }

        #endregion [Конструктор]


        #region IFilter Members

        /// <summary>
        /// Add an Expression to constrain the results to be retrieved. Will be added with "AND"
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual IFilter Add(AbstractExpression expression)
        {
            if (_junction == null)
            {
                _junction = Expression.Conjunction().Add(expression);
            }
            else
            {
                _junction = Expression.Conjunction().Add(_junction).Add(expression);
            }
            return this;
        }

        /// <summary>
        /// Add an Expression to constrain the results to be retrieved. Will be added with "OR"
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public virtual IFilter AddOr(AbstractExpression expression)
        {
            if (_junction == null)
            {
                _junction = Expression.Disjunction().Add(expression);
            }
            else
            {
                _junction = Expression.Disjunction().Add(_junction).Add(expression);
            }
            return this;
        }


        /// <summary>
        /// Добавить выражение для отбора
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Filter Add(SubqueryExpression expression)
        {
            int hashCode = expression.GetHashCode();
            if (!Subqueries.ContainsKey(hashCode))
            {
                _subqueries.Add(hashCode, expression);
            }

            return ((SubqueryExpression)_subqueries[hashCode]).CriteriaImpl;
        }

        /// <summary>
        /// Create a new Filter, "rooted" at the associated entity, assigning the given alias and using the specified join type.
        /// </summary>
        /// <param name="associationPath">Property path</param>
        /// <param name="alias">The alias to assign to the joined association (for later reference).</param>
        /// <param name="joinType">The type of join to use</param>
        /// <returns>The created "sub criteria"</returns>
        public IFilter CreateCriteria(string associationPath, string alias, JoinType joinType)
        {
            SubFilter subFilter = new SubFilter(this, associationPath, alias, joinType);
            int hashCode = subFilter.GetHashCode();
            if (JoinList.ContainsKey(hashCode))
            {
                return (IFilter)JoinList[hashCode];
            }
            return subFilter;
        }

        /// <summary>
        /// Create a new NHibernate.ICriteria, "rooted" at the associated entity, using the specified join type.
        /// </summary>
        /// <param name="associationPath">Property path</param>
        /// <param name="joinType">The type of join to use</param>
        /// <returns>The created "sub criteria"</returns>
        public IFilter CreateCriteria(string associationPath, JoinType joinType)
        {
            return CreateCriteria(associationPath, associationPath, joinType);
        }
        
        /// <summary>
        /// Порядок сортировки записей
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public IFilter AddOrder(Order order)
        {
            OrderEntries.Add(new OrderEntry(order, this));
            return this;
        }

        /// <summary>
        /// Reset rows ordering
        /// </summary>
        /// <returns></returns>
        public IFilter ResetOrder()
        {
            OrderEntries.Clear();
            return this;
        }

        /// <summary>
        /// преобразование объекта, для использования в другой объектной модели организации фильтрации данных
        /// </summary>
        /// <param name="visitor"> конвертор </param>
        [CLSCompliant(false)]
        public virtual void AcceptConvert(IConvertor visitor)
        {
            visitor.Convert(this);
        }

        #endregion

        /// <summary>
        /// Used to specify that the query results will be a projection (scalar in nature). Implicitly specifies the projection result transformer.
        /// </summary>
        /// <param name="projection">The projection representing the overall "shape" of the query results.</param>
        /// <returns></returns>
        public virtual IFilter AddProjection(AbstractProjection projection)
        {
            Projections.Add(projection);
            return this;
        }

        /// <summary>
        /// Used to specify that the query results will be a projection (scalar in nature). Implicitly specifies the projection result transformer.
        /// </summary>
        /// <param name="projection">The projection representing the overall "shape" of the query results.</param>
        /// <param name="alias">The projection alias.</param>
        /// <returns></returns>
        public virtual IFilter AddProjection(AbstractProjection projection, string alias)
        {
            Projections.Add(projection, alias);
            return this;
        }

        /// <summary>
        /// Used to specify that the query results will be a projection (scalar in nature). Implicitly specifies the projection result transformer.
        /// </summary>
        /// <param name="projections">The projection list representing the overall "shape" of the query results.</param>
        /// <returns></returns>
        public virtual IFilter AddProjection(ProjectionList projections)
        {
            Projections.Add(projections);
            return this;
        }

        /// <summary>
        /// Return string that contains query expression after "where"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            bool first = true;
            StringBuilder builder = new StringBuilder();

            builder.Append(FilterNameOrAlias() + " - ");

            foreach (CriterionEntry criterionEntry in Criteria)
            {
                if (!first)
                    builder.Append(" and ");
                builder.Append(criterionEntry.ToString());
                first = false;
            }
            if (OrderEntries.Count != 0)
            {
                builder.Append(Environment.NewLine);
            }
            first = true;
            foreach (OrderEntry orderEntry in OrderEntries)
            {
                if (!first)
                    builder.Append(", ");
                builder.Append(orderEntry.ToString());
                first = false;
            }
            return builder.ToString();
        }

        /// <summary>
        /// Returns the Filter name or alias.
        /// </summary>
        /// <returns></returns>
        protected internal virtual string FilterNameOrAlias()
        {
            return PersistentClass.Name;
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
            return PersistentClass.GetHashCode();
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
