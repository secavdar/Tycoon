using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Model
{
    public class ProductType
    {
        public ProductType()
        {
            this.Products = new List<Product>();
        }

        [Key]
        public int ID { get; set; }
        public int ProcessID { get; set; }

        public virtual UserProcess UserProcess { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}