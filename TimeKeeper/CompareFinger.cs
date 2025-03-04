using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Primitives;
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
    public partial class CompareFinger: Form
    {
        public CompareFinger()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CZKEM zkemNew = new CZKEM();

            string IPaddress = txtIP.Text;
            string enrollnumber1 = txtNumber1.Text;
            string enrollnumber2 = txtNumber2.Text;

           

            bool connected = zkemNew.Connect_Net(IPaddress, 4370);
            if (connected)
            {
                string tempData1 = "";
                string tempdata2 = "";
                int idwFingerIndex = 0;
                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    if (zkemNew.GetUserTmpExStr(1, enrollnumber1, idwFingerIndex
                                          , out int iFlag
                                          , out string sTmpData
                                          , out int iTmpLength))
                    {
                       tempData1 = sTmpData;
                    }
                }

                idwFingerIndex = 0;
                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    if (zkemNew.GetUserTmpExStr(1, enrollnumber2, idwFingerIndex
                                          , out int iFlag
                                          , out string sTmpData
                                          , out int iTmpLength))
                    {
                        tempdata2 = sTmpData;
                    }
                }



            }
        }
    }
}
