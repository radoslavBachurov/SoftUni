using _1._Chronometer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._Chronometer
{
    public class Chronometer : IChronometer
    {

        private long miliseconds;

        private bool isRunning;
        public Chronometer()
        {
            Reset();
        }
        public string GetTime => $"{miliseconds / 6000:d2}:{miliseconds / 1000:d2}:{miliseconds % 1000:d4}";

        public List<string> Laps { get; private set; }

        public string Lap()
        {
            string newLap = this.GetTime;
            this.Laps.Add(newLap);
            return newLap;
        }

        public void Reset()
        {
            this.miliseconds = 0;
            this.Laps = new List<string>();
            this.isRunning = false;
        }

        public void Start()
        {
            this.isRunning = true;

            Task.Run(() =>
            {
                while (isRunning)
                {
                    Thread.Sleep(1);
                    this.miliseconds++;
                }
            });
        }

        public void Stop()
        {
            this.isRunning = false;
        }
    }
}
