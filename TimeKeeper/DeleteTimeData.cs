using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using zkemkeeper;
using System.Net;

namespace TimeKeeper
{
    public partial class DeleteTimeData : Form
    {
        public DeleteTimeData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CZKEM axCZKEM = new CZKEM();
            string IPAddress = "172.16.103.215";
            string Port = "4370";
            int machineNumber = 1;
            int.TryParse(Port, out int iPort);
            ICollection<UserInfo> lstFPTemplates = new List<UserInfo>();

            if (axCZKEM.Connect_Net(IPAddress, iPort))
            {
                Console.WriteLine("Kết nối thành công!");

                axCZKEM.EnableDevice(machineNumber, false); // Vô hiệu hóa máy khi thao tác

                bool result = axCZKEM.SSR_DeleteEnrollData(machineNumber, "All", 12);

                if (result)
                {
                    Console.WriteLine("Đã xóa toàn bộ dữ liệu người dùng trên máy chấm công.");
                }
                else
                {
                    int errorCode = 0;
                    axCZKEM.GetLastError(ref errorCode);
                    Console.WriteLine($"Lỗi khi xóa: {errorCode} - Mã lỗi: {errorCode}");
                }

                axCZKEM.EnableDevice(machineNumber, true); // Kích hoạt lại máy
                axCZKEM.Disconnect();
            }
            else
            {
                Console.WriteLine("Kết nối thất bại!");
            }

        }
    }
}
