using System;
using System.Runtime.Serialization;

namespace Common.Exeptions
{
    [DataContract]
    public abstract class ErrorInfo
    {
        private const string Format = "{0}. Key: '{1}', ErrorMessage: '{2}'";
        private string _key;
        private string _errorMessage;

        [DataMember]
        public virtual string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        [DataMember]
        public virtual string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        protected ErrorInfo()
            : this(String.Empty, String.Empty)
        {
        }

        protected ErrorInfo(string errorMessage)
            : this(string.Empty, errorMessage)
        {
        }

        protected ErrorInfo(string key, string errorMessage)
        {
            _key = key;
            _errorMessage = errorMessage;
        }

        public override string ToString()
        {
            return String.Format(Format, base.ToString(), Key, ErrorMessage);
        }
    }
}
