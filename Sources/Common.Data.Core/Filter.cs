using System.Collections.Generic;

namespace Common.Data.Core
{
    public class Filter
    {
        public string GroupOp { get; set; }
        public IEnumerable<Rule> Rules { get; set; }
    }
}
