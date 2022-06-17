using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_Back.Models
{
    public class Datas
    {
        public int Id { get; set; }
        public string DataName { get; set; }
        public List<Product> Products { get; set; }
    }
}
