using System;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
	/// <summary>
	/// �������� ��� ��������
	/// </summary>
	[Serializable]
    public class PropertyProjection : AbstractProjection
	{
		private string _propertyName;
		private bool _grouped;

		/// <summary>
		/// �����������
		/// </summary>
		public PropertyProjection()
		{
		}

		/// <summary>
		/// �����������
		/// </summary>
		/// <param name="propertyName">��� ��������</param>
		/// <param name="grouped">������������</param>
		public PropertyProjection(string propertyName, bool grouped)
		{
			_propertyName = propertyName;
			_grouped = grouped;
		}

		/// <summary>
		/// �����������
		/// </summary>
		/// <param name="propertyName">��� ��������</param>
		public PropertyProjection(string propertyName)
			: this(propertyName, false)
		{
		}

		/// <summary>
		/// ��� ��������
		/// </summary>
		public string PropertyName
		{
			get { return _propertyName; }
			set { _propertyName = value; }
		}

		/// <summary>
		/// ToString
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return _propertyName;
		}

		/// <summary>
		/// ������������
		/// </summary>
		public override bool IsGrouped
		{
			get { return _grouped; }
		}

		/// <summary>
		/// �������������� �������, ��� ������������� � ������ ��������� ������ ����������� ���������� ������
		/// </summary>
		/// <param name="visitor"> ��������� </param>
        [CLSCompliant(false)]
        public override void AcceptConvert(IConvertor visitor)
		{
			visitor.Convert(this);
		}
	}
}
