using System;
using System.Runtime.Serialization;

namespace Common.Exeptions
{
    [DataContract]
    public class ValidationErrorInfo: ErrorInfo
    {
        public ValidationErrorInfo()
            : this(String.Empty, String.Empty)
        {
        }

        public ValidationErrorInfo(string message)
            : base(message)
        {
        }

        public ValidationErrorInfo(string key, string message)
            : base(key, message)
        {
        }
    }
}
