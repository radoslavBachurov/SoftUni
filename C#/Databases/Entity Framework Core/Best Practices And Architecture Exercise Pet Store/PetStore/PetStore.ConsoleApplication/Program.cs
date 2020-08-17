using Microsoft.EntityFrameworkCore;
using PetStore.Data;
using PetStore.Models;
using PetStore.Services;
using PetStore.Services.Interfaces;
using System;
using System.Linq;
using System.Text;

namespace PetStore.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var db = new PetStoreDbContext();
            
            //db.Database.Migrate();

            IPetStoreService propertiesService = new PetStoreService(db);

        }
    }
}
