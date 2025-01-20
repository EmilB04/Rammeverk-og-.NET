using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.BeerApp.Beers
{
    internal struct MyStruct
    {
        public int MyProperty { get; }

        public MyStruct(int myProperty)
        {
            MyProperty = myProperty;
        }
    }
}