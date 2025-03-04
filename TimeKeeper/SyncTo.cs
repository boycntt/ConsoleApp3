using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zkemkeeper;

namespace TimeKeeper
{
    public partial class SyncTo : Form
    {
        public SyncTo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fromIPAddress = textBox1.Text;
            string fromPort = textBox2.Text;
            string toIPaddress = textBox4.Text;
            string toPort = textBox3.Text;

            const string connectionUri = "mongodb+srv://root:rhtUmQhJHRY26azQ@mycluster.rxma3.mongodb.net/?retryWrites=true&w=majority&appName=myCluster";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            var client = new MongoClient(settings);

            var timekeeper = client.GetDatabase("timekeeper");
            var timedata = timekeeper.GetCollection<UserInfo_2>("timedata");

            var filterBuilder = Builders<UserInfo_2>.Filter;

            var filter = filterBuilder.And(filterBuilder.Eq("IPAddress", fromIPAddress), filterBuilder.Eq("Port", fromPort));

            var results = timedata.Find(filter).ToList();

            CZKEM zkemNew = new CZKEM();

            int.TryParse(toPort, out int toPortInt);

            bool connected = zkemNew.Connect_Net(toIPaddress, toPortInt);

            if (connected)
            {
                foreach (var objUser in results)
                {
                    bool success = zkemNew.SSR_SetUserInfo(objUser.MachineNumber, objUser.EnrollNumber, objUser.Name, objUser.Password, objUser.Privelage, true);
                    if (success)
                    {
                        bool updataok = zkemNew.SetUserTmpExStr(objUser.MachineNumber, objUser.EnrollNumber, objUser.FingerIndex, int.Parse(objUser.iFlag), objUser.TmpData);
                        if (updataok)
                        {
                            Console.WriteLine(string.Format("Completed for user: {0}", objUser.Name));
                        }
                        else
                        {
                            MessageBox.Show("Error while updating fingerprint data.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error while updating user data.");
                    }
                }
                Console.WriteLine("Transfer Completed.");
                MessageBox.Show("Transfer Completed.");
            }
            else
            {
                MessageBox.Show("Error while updating user data.");
            }
        }
    }
}
