using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_Back.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
        public int ProductImageId { get; set; }
        public ProductImage ProductImage { get; set; }
        public int DatasId { get; set; }
        public Datas Datas { get; set; }
    }
}
