using System;
using System.Collections.Generic;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
    [Serializable]
    public class ProjectionList : AbstractProjection
    {
        private readonly List<AbstractProjection> elements = new List<AbstractProjection>();
        private readonly List<string> _propertyProjections = new List<string>();

        protected List<string> PropertyProjections
        {
            get
            {
                if (_propertyProjections.Count == 0)
                {
                    foreach (AbstractProjection element in elements)
                    {
                        if (element is PropertyProjection)
                        {
                            _propertyProjections.Add(((PropertyProjection) element).PropertyName);
                        }
                    }
                }
                return _propertyProjections;
            }
        }

        public List<AbstractProjection> Elements
        {
            get { return elements; }
        }

        public ProjectionList Add(AbstractProjection projection)
        {
            elements.Add(projection);
            return this;
        }

        public ProjectionList Add(ProjectionList projections)
        {
            elements.AddRange(projections.Elements);
            return this;
        }

        public ProjectionList Add(AbstractProjection projection, String alias)
        {
            return Add(Projections.Alias(projection, alias));
        }

        /// <summary>
        /// Clear projections
        /// </summary>
        public void Clear()
        {
            elements.Clear();
        }
        
        public AbstractProjection this[int index]
        {
            get { return elements[index]; }
        }

        public int Length
        {
            get { return elements.Count; }
        }

        public override String ToString()
        {
            return elements.ToString();
        }

        public override bool IsGrouped
        {
            get { return false; }
        }

        public bool IsPropertyProjectionAdded(string propertyName)
        {
            return PropertyProjections.Contains(propertyName);
        }
        
        /// <summary>
        /// преобразование объекта, для использования в другой объектной модели организации фильтрации данных
        /// </summary>
        /// <param name="visitor"> конвертор </param>
        public override void AcceptConvert(IConvertor visitor)
        {
            visitor.Convert(this);
        }
    }
}
