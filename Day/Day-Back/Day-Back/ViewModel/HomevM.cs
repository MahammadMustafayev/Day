using Day_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_Back.ViewModel
{
    public class HomevM
    {
        public List<Product> Products { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Datas> Datas { get; set; }

    }
}
