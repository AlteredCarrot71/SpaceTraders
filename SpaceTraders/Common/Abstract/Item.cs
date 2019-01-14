using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTraders.Abstract
{
    public abstract class Item
    {
        // name of the gadget
        public String Name { get; set; }

        // price of the gadget
        public int Price { get; set; }
    }
}
