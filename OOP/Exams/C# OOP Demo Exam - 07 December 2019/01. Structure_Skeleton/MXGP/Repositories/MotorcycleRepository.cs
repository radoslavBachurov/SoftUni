using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories
{
    public class MotorcycleRepository<IMotorcycle> : Repository<IMotorcycle>, IRepository<IMotorcycle>
    {
    }
}
