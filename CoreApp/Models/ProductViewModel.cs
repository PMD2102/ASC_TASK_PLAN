using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class ProductViewModel
    {
        public int ProductID
        {
            get;
            set;
        }

        [DataType(DataType.Currency)]
        public decimal? Price
        {
            get;
            set;
        }

        public bool Discontinued
        {
            get;
            set;
        }

        [Display(Name = "ProductName")]
        public string ProductName
        {
            get;
            set;
        }

        [Display(Name = "Units In Stock")]
        public int UnitsInStock
        {
            get;
            set;
        }
    }
}
