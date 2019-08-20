using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataTableTests
{
    class Program
    {
        static void Main(string[] args)
        {

           
            // Create DataTable
            DataTable dt = new DataTable("PlantData");

            // DataTable Columns
            DataColumn tagID = new DataColumn("TagID");
            tagID.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(tagID);

            DataColumn Value = new DataColumn("Value");
            Value.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(Value);

            DataColumn Quality = new DataColumn("Quality");
            Quality.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(Quality);

            DataColumn Timestamp = new DataColumn("Timestamp");
            Timestamp.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(Timestamp);

            DataColumn Processed = new DataColumn("Processed");
            Processed.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(Processed);


            // DataTable Rows
            DataRow newRow = dt.NewRow();

            // Add Record 1
            newRow["TagID"] = 1;
            newRow["Value"] = "Value";
            newRow["Quality"] = 192;
            newRow["Timestamp"] = "20120212";
            newRow["Processed"] = 0;
            dt.Rows.Add(newRow);

            // Add a New Row Otherwise an Argument Error will be thrown
            newRow = dt.NewRow();

            // Add Record 2
            newRow["TagID"] = 2;
            newRow["Value"] = "Value2";
            newRow["Quality"] = 192;
            newRow["Timestamp"] = "20120212";
            newRow["Processed"] = 0;
            dt.Rows.Add(newRow);

            //TODO. Figure out how to Access data from the DataTable

            // Pause Console Application
            Console.ReadLine();

        }
    }
}
