using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zkemkeeper;

namespace TimeKeeper
{
    public partial class ExportTimeData : Form
    {
        public ExportTimeData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CZKEM axCZKEM = new CZKEM();
            string IPAddress = textBox1.Text;
            string Port = textBox2.Text;
            int.TryParse(Port, out int iPort);

            if (axCZKEM.Connect_Net(IPAddress, iPort))
            {
                Console.WriteLine("Kết nối thành công!");

                ICollection<UserInfo> ltsUsers = GetAllUserInfo(axCZKEM, 1, IPAddress, iPort);

                SaveMongoData(ltsUsers);
                axCZKEM.Disconnect();
            }
            else
            {
                Console.WriteLine("Kết nối thất bại!");
            }
        }

        public static ICollection<UserInfo> GetAllUserInfo(CZKEM objZkeeper, int machineNumber, string IPAddress, int Port)
        {
            int idwFingerIndex;
            ICollection<UserInfo> lstFPTemplates = new List<UserInfo>();
            objZkeeper.ReadAllUserID(machineNumber);
            objZkeeper.ReadAllTemplate(machineNumber);

            while (objZkeeper.SSR_GetAllUserInfo(machineNumber
                                            , out string sdwEnrollNumber
                                            , out string sName
                                            , out string sPassword
                                            , out int iPrivilege
                                            , out bool bEnabled))
            {
                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    if (objZkeeper.GetUserTmpExStr(machineNumber, sdwEnrollNumber, idwFingerIndex
                                            , out int iFlag
                                            , out string sTmpData
                                            , out int iTmpLength))
                    {
                        var fpInfo = new UserInfo
                        {
                            MachineNumber = machineNumber,
                            EnrollNumber = sdwEnrollNumber,
                            Name = sName,
                            FingerIndex = idwFingerIndex,
                            TmpData = sTmpData,
                            TmpLength = iTmpLength,
                            Privelage = iPrivilege,
                            Password = sPassword,
                            Enabled = bEnabled,
                            iFlag = iFlag.ToString(),
                            IPAddress = IPAddress,
                            Port = Port
                        };

                        lstFPTemplates.Add(fpInfo);
                    }
                }
            }
            return lstFPTemplates;
        }

        public static void SaveMongoData(ICollection<UserInfo> userData)
        {
            const string connectionUri = "mongodb+srv://root:rhtUmQhJHRY26azQ@mycluster.rxma3.mongodb.net/?retryWrites=true&w=majority&appName=myCluster";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            var client = new MongoClient(settings);
            // Send a ping to confirm a successful connection
            try
            {
                string IPAddress = userData.FirstOrDefault().IPAddress;
                string Port = userData.FirstOrDefault().Port.ToString();

                var timekeeper = client.GetDatabase("timekeeper");
                var timedata = timekeeper.GetCollection<UserInfo>("timedata");

                var filterBuilder = Builders<UserInfo>.Filter;

                var filter = filterBuilder.And(filterBuilder.Eq("IPAddress", IPAddress)
                      , filterBuilder.Eq("Port", Port)
                    );

                timedata.DeleteMany(filter);
                timedata.InsertMany(userData);
                MessageBox.Show("Data Exported!");


                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class UserInfo
    {

        public string IPAddress { get; set; }
        public int Port { get; set; }
        public int MachineNumber { get; set; }
        public string EnrollNumber { get; set; }

        public string Name { get; set; }

        public int FingerIndex { get; set; }

        public string TmpData { get; set; }

        public int TmpLength { get; set; }

        public int Privelage { get; set; }

        public string Password { get; set; }

        public bool Enabled { get; set; }

        public string iFlag { get; set; }


    }

    public class UserInfo_2
    {
        public ObjectId Id { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public int MachineNumber { get; set; }
        public string EnrollNumber { get; set; }

        public string Name { get; set; }

        public int FingerIndex { get; set; }

        public string TmpData { get; set; }

        public int TmpLength { get; set; }

        public int Privelage { get; set; }

        public string Password { get; set; }

        public bool Enabled { get; set; }

        public string iFlag { get; set; }


    }
}
