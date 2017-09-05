using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    class Server
    {
        private string inlinje;

        public Server()
        {

        }
        //en start metode til vores tcp kanal
        public void start()
        {
            //vi bruger loopback fordi vi ønsker at det vores igen pc. 7070 er altså porten.
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 7070);

            //vi starter vores server
            tcpListener.Start();


            // vi bruger using fordi vi ønsker at lukke forbindelsen når den ikke bliver brugt længere det gør using.

            //her siger vi at vi godkender en tcp client
            using (TcpClient server = tcpListener.AcceptTcpClient())
                //den data vej kalder vi ns
            using (NetworkStream ns = server.GetStream())
                //ns kan vi så læse og skrive til 
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                //for at beholde forbindelsen bruger vi et while loop - hvis vores linje er stop lukker vi ned da den er false
                while (inlinje != "stop")
                {
                    //venter på vi modtaget en linje når vi gør sætter vi den til inlinje
                    inlinje = sr.ReadLine();
                    //siger vores streamwriter skal sende inlinje" altså den linje dne lige har modtaget
                    sw.WriteLine(inlinje);
                    //ryder buffer
                    sw.Flush();
                }



            }

        }



    }
}
