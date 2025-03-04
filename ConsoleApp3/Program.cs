// See https://aka.ms/new-console-template for more information
using System.Reflection.PortableExecutable;
using zkemkeeper;

Console.WriteLine("Hello, World!");
CZKEM objZkeeper = new CZKEM();
//objZkeeper.SetDeviceCommPwd(24105466, 0);
//objZkeeper
bool connect = objZkeeper.Connect_Net("172.16.103.28", 5005);
if (connect)
{
    Console.WriteLine("Connected");
}