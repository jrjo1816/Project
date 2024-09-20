using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BASEC
{
    public class FileControl
    {
        public void Write_SpecFile()
        {
            FileStream fsw = new FileStream("D:\\YURASEARCH\\SPEC.txt", FileMode.Create, FileAccess.Write);
            fsw.Seek(0, SeekOrigin.End);
            String strData = null;
            byte[] data = new byte[1000];
            short i = 0;
            for (i = 0; i < 22; i++)
            {
                switch (i)
                {
                    case 0: strData = Convert.ToString(BASEC.FORM.MyVariables.dBF_Grs_Min); break;
                    case 1: strData = Convert.ToString(BASEC.FORM.MyVariables.dBF_Grs_Max); break;
                    case 2: strData = Convert.ToString(BASEC.FORM.MyVariables.dAF_Grs_Min); break;
                    case 3: strData = Convert.ToString(BASEC.FORM.MyVariables.dAF_Grs_Max); break;
                    case 4: strData = Convert.ToString(BASEC.FORM.MyVariables.dGrsData_Min); break;
                    case 5: strData = Convert.ToString(BASEC.FORM.MyVariables.dGrsData_Max); break;
                    case 6: strData = Convert.ToString(BASEC.FORM.MyVariables.dCRing_Length_Min); break;
                    case 7: strData = Convert.ToString(BASEC.FORM.MyVariables.dCRing_Length_Max); break;
                    case 8: strData = Convert.ToString(BASEC.FORM.MyVariables.dCRing_Weight_Min); break;
                    case 9: strData = Convert.ToString(BASEC.FORM.MyVariables.dCRing_Weight_Max); break;
                    case 10: strData = Convert.ToString(BASEC.FORM.MyVariables.dCRing_Height_Min); break;
                    case 11: strData = Convert.ToString(BASEC.FORM.MyVariables.dCRing_Height_Max); break;
                    case 12: strData = Convert.ToString(BASEC.FORM.MyVariables.dInsulate_Resist_Min); break;
                    case 13: strData = Convert.ToString(BASEC.FORM.MyVariables.dInsulate_Resist_Max); break;
                    case 14: strData = Convert.ToString(BASEC.FORM.MyVariables.dRoomTemp_Resist_Min); break;
                    case 15: strData = Convert.ToString(BASEC.FORM.MyVariables.dRoomTemp_Resist_Max); break;
                    case 16: strData = Convert.ToString(BASEC.FORM.MyVariables.dHighTemp_Resist_Min); break;
                    case 17: strData = Convert.ToString(BASEC.FORM.MyVariables.dHighTemp_Resist_Max); break;
                    case 18: strData = Convert.ToString(BASEC.FORM.MyVariables.dGasket_Length_Min); break;
                    case 19: strData = Convert.ToString(BASEC.FORM.MyVariables.dGasket_Length_Max); break;
                    case 20: strData = Convert.ToString(BASEC.FORM.MyVariables.dGasket_Weight_Min); break;
                    case 21: strData = Convert.ToString(BASEC.FORM.MyVariables.dGasket_Weight_Max); break;
                    default: break;
                }
                data = Encoding.Default.GetBytes(strData + "\r\n");
                
                fsw.Write(data, 0, data.Length);
            }
                   
            fsw.Close();
        }

        public void Read_File()
        {
            FileStream fsr = new FileStream("D:\\YURASEARCH\\SPEC.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fsr);

            string[] setting = new string[22];

            while (sr.EndOfStream == false)
            {
                for (int i = 0; i < 22; i++)
                {
                    setting[i] = sr.ReadLine();

                    switch (i)
                    {
                        case 0: BASEC.FORM.MyVariables.dBF_Grs_Min = Convert.ToDouble(setting[i]); break;
                        case 1: BASEC.FORM.MyVariables.dBF_Grs_Max = Convert.ToDouble(setting[i]); break;
                        case 2: BASEC.FORM.MyVariables.dAF_Grs_Min = Convert.ToDouble(setting[i]); break;
                        case 3: BASEC.FORM.MyVariables.dAF_Grs_Max = Convert.ToDouble(setting[i]); break;
                        case 4: BASEC.FORM.MyVariables.dGrsData_Min = Convert.ToDouble(setting[i]); break;
                        case 5: BASEC.FORM.MyVariables.dGrsData_Max = Convert.ToDouble(setting[i]); break;
                        case 6: BASEC.FORM.MyVariables.dCRing_Length_Min = Convert.ToDouble(setting[i]); break;
                        case 7: BASEC.FORM.MyVariables.dCRing_Length_Max = Convert.ToDouble(setting[i]); break;
                        case 8: BASEC.FORM.MyVariables.dCRing_Weight_Min = Convert.ToDouble(setting[i]); break;
                        case 9: BASEC.FORM.MyVariables.dCRing_Weight_Max = Convert.ToDouble(setting[i]); break;
                        case 10: BASEC.FORM.MyVariables.dCRing_Height_Min = Convert.ToDouble(setting[i]); break;
                        case 11: BASEC.FORM.MyVariables.dCRing_Height_Max = Convert.ToDouble(setting[i]); break;
                        case 12: BASEC.FORM.MyVariables.dInsulate_Resist_Min = Convert.ToDouble(setting[i]); break;
                        case 13: BASEC.FORM.MyVariables.dInsulate_Resist_Max = Convert.ToDouble(setting[i]); break;
                        case 14: BASEC.FORM.MyVariables.dRoomTemp_Resist_Min = Convert.ToDouble(setting[i]); break;
                        case 15: BASEC.FORM.MyVariables.dRoomTemp_Resist_Max = Convert.ToDouble(setting[i]); break;
                        case 16: BASEC.FORM.MyVariables.dHighTemp_Resist_Min = Convert.ToDouble(setting[i]); break;
                        case 17: BASEC.FORM.MyVariables.dHighTemp_Resist_Max = Convert.ToDouble(setting[i]); break;
                        case 18: BASEC.FORM.MyVariables.dGasket_Length_Min = Convert.ToDouble(setting[i]); break;
                        case 19: BASEC.FORM.MyVariables.dGasket_Length_Max = Convert.ToDouble(setting[i]); break;
                        case 20: BASEC.FORM.MyVariables.dGasket_Weight_Min = Convert.ToDouble(setting[i]); break;
                        case 21: BASEC.FORM.MyVariables.dGasket_Weight_Max = Convert.ToDouble(setting[i]); break;
                        default: break;
                    }
                }
            }

            sr.Close();
            fsr.Close();
        }

        public void Write_CSV_File(TextWriter stream, String[] strArray)
        {
           // StreamWriter sw = new StreamWriter("D:\\DATA\\testcsv.csv");
            int i=0;
            
            foreach (String row in strArray)
            {
                stream.Write(strArray[i]);
                if (i < 13)
                {
                    stream.Write(',');
                } 
                i++;
            }
            stream.WriteLine("\r\n");
            stream.Flush();       
        }
    }
}
