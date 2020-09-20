using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string newLine = "\r\n";
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 3334);
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                using (NetworkStream networkStream = client.GetStream())
                {
                    byte[] inputBytes = new byte[1000000];
                    int bytesRead = networkStream.Read(inputBytes, 0, inputBytes.Length);
                    string request = Encoding.UTF8.GetString(inputBytes, 0, bytesRead);


                    Console.WriteLine(request);
                    Console.WriteLine(new string('-', 60));

                    if (request.Contains("GET /style.css HTTP/1.1"))
                    {
                        string responceCss = File.ReadAllText("style.css");
                        string responce = "HTTP/1.0 200 OK" + newLine +
                            "Server: RadoServer v1.0" + newLine +
                            "Content-Type: text/css" + newLine +
                            "Content-Length: " + responceCss.Length + newLine
                            + newLine +
                             responceCss + newLine;
                        byte[] responceBytes = Encoding.UTF8.GetBytes(responce);
                        networkStream.Write(responceBytes, 0, responceBytes.Length);
                    }
                    else if (request.Contains("GET / HTTP/1.1"))
                    {
                        string responceHtml = File.ReadAllText("Index.html");
                        string responce = "HTTP/1.0 200 OK" + newLine +
                            "Server: RadoServer v1.0" + newLine +
                            "Content-Type: text/html" + newLine +
                            "Content-Length: " + responceHtml.Length + newLine
                            + newLine +
                             responceHtml + newLine;
                        byte[] responceBytes = Encoding.UTF8.GetBytes(responce);
                        networkStream.Write(responceBytes, 0, responceBytes.Length);
                    }
                    else
                    {
                        byte[] file_content = File.ReadAllBytes("peak.jpg");

                        string responceHead = "HTTP/1.0 200 OK" + newLine +
                            "Server: RadoServer v1.0" + newLine +
                            "Content-Type: image/avif" + newLine +
                            "Content-Length: " + file_content.Length + newLine + newLine;

                        byte[] responceHeadBytes = Encoding.UTF8.GetBytes(responceHead);

                        var responce = new byte[file_content.Length + responceHeadBytes.Length];
                        responceHeadBytes.CopyTo(responce, 0);
                        file_content.CopyTo(responce, responceHeadBytes.Length);

                        networkStream.Write(responce, 0, responce.Length);
                        
                    }

                }
            }
        }
    }
}
