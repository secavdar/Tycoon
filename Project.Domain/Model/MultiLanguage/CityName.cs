using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Model.MultiLanguage
{
    using Base;
    public class CityName : Unit
    {
        public virtual City Entity { get; set; }
    }
}