using BAL.BalConstants;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Model
{
  public  class FilterModel
    {
        public EFilters Filters { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public List<string> Values { get; set; }
    }
}
