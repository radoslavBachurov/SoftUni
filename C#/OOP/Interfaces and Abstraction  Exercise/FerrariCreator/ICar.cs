using System;
using System.Collections.Generic;
using System.Text;

namespace FerrariCreator
{
    public interface ICar
    {
        string Model { get; set; }
        string Driver { get; set; }
        string Break();
        string Gas();
    }
}
