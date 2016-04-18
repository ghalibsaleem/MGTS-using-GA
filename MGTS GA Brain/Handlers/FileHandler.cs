using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGTS_GA_Brain.Handlers
{
    public class FileHandler
    {
        

        public  static List<double> getResult(String filePath)
        {
            List<double> list = null;
            
                    if (filePath == null)
                        throw new FileNameException("File path is not specified. Please specify a path.");
                    string line;
                    StreamReader streamReader = null;
                    try
                    {

                        list = new List<double>();

                        FileInfo info = new FileInfo(filePath);

                        streamReader = new StreamReader(info.OpenRead());
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            double temp;
                            bool val = double.TryParse(line, out temp);
                            if (val)
                            {
                                list.Add(temp);
                            }
                        }
                    }
                    finally
                    {
                        if (streamReader != null)
                        {
                            streamReader.Dispose();
                        }
                    }

                
            return list;
        }


        public static bool WriteToFile(double[] input,string name)
        {
            //StreamWriter streamWriter = null;
            using (StreamWriter streamWriter = new StreamWriter(@"D:\Extra\" + name+ ".txt", false))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    streamWriter.WriteLine(input[i].ToString());
                }
            }
                return true;
        }
        public static bool WriteToFile(double[] input,double[] initial,double[] output)
        {
            //StreamWriter streamWriter = null;
            using (StreamWriter streamWriter = new StreamWriter(@"D:\Extra\output.txt", false))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    streamWriter.WriteLine(i.ToString() + "\t" + input[i].ToString() + "\t" + initial[i].ToString() + "\t" + output[i].ToString());
                }
            }
            return true;
        }
    }
}
