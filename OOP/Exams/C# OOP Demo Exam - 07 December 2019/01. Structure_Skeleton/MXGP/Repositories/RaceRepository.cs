using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository<IRace> : Repository<IRace>,IRepository<IRace>
    {
    }
}
