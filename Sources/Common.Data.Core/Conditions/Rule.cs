namespace Common.Data.Core.Conditions
{
    public class Rule
    {
        public enum Operations
        {
            Eq,
            Like,
        }

        public string PropertyName { get; set; }
        public Operations Operation { get; set; }
        public string Value { get; set; }

        public Rule() { }

        public Rule(string propertyName, Operations operation, string value)
        {
            PropertyName = propertyName;
            Operation = operation;
            Value = value;
        }
    }
}
