using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProjectPart1.Models
{
    public class Item
    {
       
            public int ItemId { get; set; }
            public int Quantity { get; set; }
            public DateTime ItemCreated { get; set; }
            public Movies Movies { get; set; }
        
    }
}
