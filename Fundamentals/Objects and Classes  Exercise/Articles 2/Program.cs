using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCommands = int.Parse(Console.ReadLine());
            ArticleList ListOne = new ArticleList();

            for (int i = 0; i < numberCommands; i++)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();
                Article publication = new Article(input[0], input[1], input[2]);
                ListOne.newList.Add(publication);
            }

            string command = Console.ReadLine();
            PrintCommand(command, ListOne);
        }

        private static void PrintCommand(string command, ArticleList listOne)
        {
            if (command == "title")
            {
                foreach (var item in listOne.newList.OrderBy(c => c.Title))
                {
                    Console.WriteLine($"{item.ToString()}");
                }
            }

            else if (command == "content")
            {
                foreach (var item in listOne.newList.OrderBy(c => c.Content))
                {
                    Console.WriteLine($"{item.ToString()}");
                }
            }

            else if (command == "author")
            {
                foreach (var item in listOne.newList.OrderBy(c => c.Author))
                {
                    Console.WriteLine($"{item.ToString()}");
                }
             
            }
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
    class ArticleList
    {
        public ArticleList()
        {
            newList = new List<Article>();
        }
        public List<Article> newList { get; set; }

        
    }
}
