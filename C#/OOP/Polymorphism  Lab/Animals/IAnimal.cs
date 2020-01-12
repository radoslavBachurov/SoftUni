using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    interface IAnimal
    {
        string Name { get; }
        string FavouriteFood { get; }
        string ExplainSelf();
    }
}
