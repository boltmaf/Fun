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
        /*public Loads(string Discipline, string Teachers, int Group, int Lections, int Practice, int LR )
        {
            this.Discipline = Discipline;
            this.Teachers = Teachers;
            this.Group = Group;
            this.Lections = Lections;
            this.Practice = Practice;
            this.LR = LR;
        }*/
    }
}
