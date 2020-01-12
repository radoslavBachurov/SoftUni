using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ").ToList();
            int numberCommands = int.Parse(Console.ReadLine());
           
            Article publication = new Article(input[0], input[1], input[2]);

            for (int i = 0; i < numberCommands; i++)
            {
                string[] commandArr = Console.ReadLine().Split(": ").ToArray();

                if (commandArr.Contains("Edit"))
                {
                    publication.Edit(commandArr[1]);
                }
                else if (commandArr.Contains("ChangeAuthor"))
                {
                    publication.ChangeAuthor(commandArr[1]);
                }
                else if (commandArr.Contains("Rename"))
                {
                    publication.Rename(commandArr[1]);
                }
            }

            Console.WriteLine(publication.ToString());
        }
    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            string toPrint = $"{Title} - {Content}: {Author}";
            return toPrint;
        }
    }
}
