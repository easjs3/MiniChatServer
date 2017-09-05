using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoClient
{
    class Client
    {
        private string SendStr;
        public void start()
        {
            //vi laver en string til senere brug.
            //string SendStr = "String jer vil sende";

            //opretter en client og siger at den client - localhost er altså ip og 7 er porten.
            using (TcpClient client = new TcpClient("localhost", 7070))

            //sætter vores client til at get herefter kan vi bruge read og write via den stream
            using (NetworkStream ns = client.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                //her bruger vi streamwriter til at sende vores string
                while (SendStr != "stop")
                {
                    SendStr = Console.ReadLine();
                    sw.WriteLine(SendStr);

                    //ryder buffer
                    sw.Flush();

                    //sætter vores streamreader til at læse og printer den derefter ud
                    string incomingStr = sr.ReadLine();



                    Console.WriteLine(incomingStr);
                }

            }
        }






    }
}
