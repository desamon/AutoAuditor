using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuditorFM.Impl.Models
{
    public class Result
    {
        public string Categorie { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public double ImportQuestion { get; set; }
        public double ImportAnswer { get; set; }
        public string Comment { get; set; }
    }
}
