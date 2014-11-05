using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Model.MultiLanguage
{
    using Base;
    public class CurrencyName : Unit
    {
        public virtual Currency Entity { get; set; }
    }
}