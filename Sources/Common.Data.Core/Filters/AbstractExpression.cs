using System;
using Common.Data.Core.Interfaces;

namespace Common.Data.Core.Filters
{
    ///<summary>
    /// ����������� ����� ��� ���� ��������� ������������ ��� ������ � ��������
    ///</summary>
    [Serializable]
    public abstract class AbstractExpression : IExpression
    {
        /// <summary>
        /// �����������
        /// </summary>
        public AbstractExpression() { }

        #region IExpression Members

        /// <summary>
        /// �������������� �������, ��� ������������� � ������ ��������� ������ ����������� ���������� ������
        /// </summary>
        /// <param name="visitor"> ��������� </param>
        public abstract void AcceptConvert(IConvertor visitor);

        #endregion
    }
}
