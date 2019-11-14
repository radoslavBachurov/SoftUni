using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<IPrivate> ListOfPrivates { get; }
        decimal Salary { get; }
    }
}
