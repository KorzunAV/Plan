using System;
using System.Runtime.Serialization;
using System.Text;

namespace Common.Exeptions
{
    [Serializable]
    public class BusinessExeption : Exception
    {
        public BusinessErrorInfo ErrorInfo;

        public BusinessExeption()
            : this(new BusinessErrorInfo())
        {
        }

        public BusinessExeption(string message)
        {
            ErrorInfo = new BusinessErrorInfo(message);
        }

        public BusinessExeption(string key, string message)
        {
            ErrorInfo = new BusinessErrorInfo(key, message);
        }

        public BusinessExeption(BusinessErrorInfo validationError)
        {
            ErrorInfo = validationError;
        }

        public BusinessExeption(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }


        public BusinessErrorInfo BusinessError { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(ErrorInfo.ToString());
            builder.Append(base.ToString());
            return builder.ToString();
        }
    }
}
