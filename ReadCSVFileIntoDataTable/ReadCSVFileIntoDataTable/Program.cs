using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadCSVFileIntoDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            // CSV Read
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            using (var reader = new StreamReader(@"D:\\Dir\\DIGNOS\\test.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listA.Add(values[0]);
                    listB.Add(values[1]);

                    
                }

            }

            // CSV WRITE
            string sPath = "D:\\Dir\\DIGNOS\\res.csv";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);

            for (int i = 0; i < listA.Count; i++)
            {
                SaveFile.WriteLine(listA[i] + "," + listB[i]);
            }

            SaveFile.Close();
            
        }
    }
}
