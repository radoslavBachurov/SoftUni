﻿using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories
{
    public class RiderRepository : Repository<IRider>,IRepository<IRider>
    {
    }
}
