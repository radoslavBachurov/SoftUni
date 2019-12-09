using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private ICollection<T> Models;

        public Repository()
        {
            this.Models = new List<T>();
        }
        public void Add(T model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Models.ToList().AsReadOnly();
        }

        public T GetByName(string name)
        {
            foreach (var entity in this.Models)
            {
                foreach (var prop in entity.GetType().GetProperties())
                {
                    if (prop.Name == "Name")
                    {
                        var value = prop.GetValue(entity, null);
                        if (value.ToString() == name)
                        {
                            return entity;
                        }
                    }
                }
            }
            return default(T);
        }

        public bool Remove(T model)
        {
            T toRemove = this.Models.First(x => x.Equals(model));
            if (toRemove != null)
            {
                Models.Remove(model);
                return true;
            }
            return false;
        }
    }


}
