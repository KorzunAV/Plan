using System.Collections.Generic;

namespace Common.Data.Core.Conditions
{
    public class Filter
    {
        public Filter()
        {
            Rules = new List<Rule>();
        }

        public string GroupOp { get; set; }
        public List<Rule> Rules { get; set; }
    }
}
