using System;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// An Aggregation
	/// </summary>
	[Serializable]
    public class AggregateProjection : AbstractProjection
	{
		private string _propertyName;
		private string _aggregate;

		/// <summary>
		/// ��� ��������
		/// </summary>
		public string PropertyName
		{
			get { return _propertyName; }
			set { _propertyName = value; }
		}

		/// <summary>
		/// ���������
		/// </summary>
		public string Aggregate
		{
			get { return _aggregate; }
			set { _aggregate = value; }
		}

		/// <summary>
		/// �����������
		/// </summary>
		/// <param name="aggregate">���������</param>
		/// <param name="propertyName">��� ��������</param>
		protected internal AggregateProjection(string aggregate, string propertyName)
		{
			_aggregate = aggregate;
			_propertyName = propertyName;
		}

		/// <summary>
		/// Override ��� ToString
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return _aggregate + "(" + _propertyName + ')';
		}

		/// <summary>
		/// �����������
		/// </summary>
		public AggregateProjection()
		{
		}

		/// <summary>
		/// Does this projection specify grouping attributes?
		/// </summary>
		public override bool IsGrouped
		{
			get { return false; }
		}

		/// <summary>
		/// �������������� �������, ��� ������������� � ������ ��������� ������ ����������� ���������� ������
		/// </summary>
		/// <param name="visitor"> ��������� </param>
        public override void AcceptConvert(IConvertor visitor)
		{
			visitor.Convert(this);
		}
	}
}
