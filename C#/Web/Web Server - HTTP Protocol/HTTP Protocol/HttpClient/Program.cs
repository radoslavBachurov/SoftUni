using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace HttpClientDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "http://localhost:3334/";
            HttpClient client = new HttpClient();
            var tasks = new List<Task<string>>();

            Parallel.For(0, 1000, i =>
              {
                  async Task<string> func()
                  {
                      var result = await client.GetStringAsync(url);
                      return result;
                  }

                  tasks.Add(func());
              });


            await Task.WhenAll(tasks);

            var postResponses = new List<string>();

            foreach (var t in tasks)
            {
                var postResponse = await t; //t.Result would be okay too.
                postResponses.Add(postResponse);
                Console.WriteLine(postResponse);
            }
        }
    }
}
