using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zkemkeeper;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CZKEM objZkeeper = new CZKEM();

            //bool connect = objZkeeper.Connect_Net("172.16.103.28", 5005);
            //if (connect)                                                                                            
            //{

            //    objZkeeper.SSR_GetAllUserInfo(1, out string strEnrollNumber, out string strName, out string strPassword, out int intPrivilege, out bool bEnabled);
            //    Console.WriteLine("Connected");
            //    objZkeeper.Disconnect();
            //    Console.WriteLine("Disconnected");
            //}

            CZKEM axCZKEM = new CZKEM();
            int machineNumber = 1;
            string dwEnrollNumber;
            string name;
            string password;
            int privilege;
            bool enabled;

            if (axCZKEM.Connect_Net("172.16.102.3", 4370))
            {
                Console.WriteLine("Kết nối thành công!");

                ICollection<dynamic> ltsUsers = GetAllUserInfo(axCZKEM, 1);


                foreach (var user in ltsUsers)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(user));
                    Console.WriteLine();
                }

                //axCZKEM.EnableDevice(machineNumber, false); // Tắt thiết bị để tránh lỗi khi đọc dữ liệu

                //axCZKEM.ReadAllUserID(machineNumber);  // Đọc tất cả UserID vào bộ nhớ đệm
                //axCZKEM.ReadAllTemplate(machineNumber);  // Đọc tất cả vân tay (nếu cần)

                //while (axCZKEM.SSR_GetAllUserInfo(machineNumber, out dwEnrollNumber, out name, out password, out privilege, out enabled))
                //{



                //    Console.WriteLine("Mã NV: {0}, Tên: {1}, Mật khẩu: {2}, Quyền: {3}, Kích hoạt: {4}",
                //        dwEnrollNumber, name, password, privilege, enabled);
                //}

                //axCZKEM.EnableDevice(machineNumber, true); // Bật lại thiết bị
                axCZKEM.Disconnect();
            }
            else
            {
                Console.WriteLine("Kết nối thất bại!");
            }

        }

        public static ICollection<dynamic> GetAllUserInfo(CZKEM objZkeeper, int machineNumber)
        {
            int idwFingerIndex;
            ICollection<dynamic> lstFPTemplates = new List<dynamic>();
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
                        var fpInfo = new
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
                            iFlag = iFlag.ToString()
                        };

                        lstFPTemplates.Add(fpInfo);
                    }
                }
            }
            return lstFPTemplates;
        }
    }
}
