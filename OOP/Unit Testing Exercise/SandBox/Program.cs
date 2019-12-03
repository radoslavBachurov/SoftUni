using System;
using System.Net.Sockets;
using CarManager;


namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCar = new Car("Ferrari", "Spyder", 6.4, 100);
            try
            {
                typeof(Car).GetProperty("FuelAmount").SetValue(testCar, -100);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
        }
    }
}
