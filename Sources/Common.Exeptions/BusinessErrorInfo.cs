using System;
using System.Runtime.Serialization;

namespace Common.Exeptions
{
    [DataContract]
    public class BusinessErrorInfo : ErrorInfo
    {
        public BusinessErrorInfo()
            : this(String.Empty, String.Empty)
        {
        }

        public BusinessErrorInfo(string message)
            : base(message)
        {
        }

        public BusinessErrorInfo(string key, string message)
            : base(key, message)
        {
        }
    }
}
