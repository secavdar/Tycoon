using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Model.MultiLanguage
{
    using Base;
    public class CountryName : Unit
    {
        public virtual Country Entity { get; set; }
    }
}