using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Engine
    {
        public Engine(int engineSpeed,int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }
        public int engineSpeed { get; private set; }
        public int enginePower { get; private set; }
    }
}
