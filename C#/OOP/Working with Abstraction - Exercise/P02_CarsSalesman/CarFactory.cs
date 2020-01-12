using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    public class CarFactory
    {
        public CarFactory()
        {
            cars = new List<Car>();
        }
        public List<Car> cars { get; private set; }

        public void Add(string[] parameters, EngineFactory newEngineFactory)
        {
            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = newEngineFactory.engines.FirstOrDefault(x => x.model == engineModel);

            int weight = -1;

            if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
            {
                cars.Add(new Car(model, engine, weight));
            }
            else if (parameters.Length == 3)
            {
                string color = parameters[2];
                cars.Add(new Car(model, engine, color));
            }
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                cars.Add(new Car(model, engine, int.Parse(parameters[2]), color));
            }
            else
            {
                cars.Add(new Car(model, engine));
            }
        }
    }
}
