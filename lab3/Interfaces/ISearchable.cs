using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    interface ISearchable
    {
        public List<int> SearchForSpecificCharacterIndex(string str, char character);
    }
}
