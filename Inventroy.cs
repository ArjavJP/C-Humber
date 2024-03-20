using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10
{
    public class Inventroy
    {
        public int ItemNo { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
       
        public override string ToString()
        {
            return $"{ItemNo}, {Description}, {Price}";
        }
    }

}
