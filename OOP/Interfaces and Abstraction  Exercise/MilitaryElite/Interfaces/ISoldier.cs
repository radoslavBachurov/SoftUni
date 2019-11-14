using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Soldiers;

namespace MilitaryElite.Interfaces
{
    public interface ISoldier
    {
        string Id { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}
