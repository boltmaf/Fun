using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUN
{
    public partial class Loads
    {
        public string Discipline { get; set; }
        public string Teachers { get; set; }
        public int Group { get; set; }
        public Nullable<int> Lections { get; set; }
        public Nullable<int> Practice { get; set; }
        public Nullable<int> LR { get; set; }
    }

    public partial class LoadsGroup
    {
        public int Group { get; set; }
        public string Discipline { get; set; }
        public Nullable<int> Lections { get; set; }
        public Nullable<int> Practice { get; set; }
        public Nullable<int> LR { get; set; }
    }

}
