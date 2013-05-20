using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common.Exeptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public List<ValidationErrorInfo> ErrorInfos;

        public ValidationException()
            : this(new List<ValidationErrorInfo>())
        {
        }

        public ValidationException(List<ValidationErrorInfo> validationErrors)
        {
            ErrorInfos = validationErrors;
        }

        public ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        
        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (ValidationErrorInfo validationErrorInfo in ErrorInfos)
            {
                builder.AppendLine(validationErrorInfo.ToString());
            }
            builder.Append(base.ToString());
            return builder.ToString();
        }
    }
}
