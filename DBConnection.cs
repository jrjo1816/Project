using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BASEC
{
    class DBConnection
    {
        public string DBConnString()
        {
            ///ini파일에 저장된 FMS 서버 접속 정보 추출
            FileStream fs = new FileStream(Application.StartupPath + @"\Config\Ipconfig.ini", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string[] setting = new string[5];

            while (sr.EndOfStream == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    setting[i] = sr.ReadLine();
                }
            }
            sr.Close();

            ///접속 필수 정보 저장
            string Host = setting[0];
            string Port = setting[1];
            string Service_Name = setting[2];
            string User_ID = setting[3];
            string Password = setting[4];

            ///접속 정보 통합
            //string strConnOld = "Data Source = (DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + Host + ")(PORT=" + Port + "))(CONNECT_DATA=(SERVICE_NAME=" + Service_Name + ")));User Id=" + User_ID + ";Password=" + Password + ";";
           // string strConn = "server = 10.10.2.51,1433; uid = YURA; pwd = 0515; database = EGRCOOLER;";
            string strConn = "server = " + Host + "," + Port + "; uid = " + User_ID + "; pwd = " + Password + "; database = " + Service_Name + ";";
            
            
            return strConn;
        }
    }
}
