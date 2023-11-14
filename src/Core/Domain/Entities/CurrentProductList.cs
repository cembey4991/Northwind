using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
     public partial class CurrentProductList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}