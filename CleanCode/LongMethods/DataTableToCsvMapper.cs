using System;
using System.Data;
using System.IO;

namespace CleanCode.LongMethods
{
    public class DataTableToCsvMapper
    {
        public System.IO.MemoryStream CreateMemoryFile(DataTable dataTable)
        {
            var ReturnStream = new MemoryStream();

            StreamWriter sw = new StreamWriter(ReturnStream);
            WriteColumnNames(dataTable, sw);
            WriteRows(dataTable, sw);
            sw.Flush();
            sw.Close();

            return ReturnStream;
        }

        private static void WriteRows(DataTable dt, StreamWriter sw)
        {
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string str = String.Format("\"{0:c}\"", dr[i].ToString()).Replace("\r\n", " ");
                        sw.Write(str);
                    }
                    else
                    {
                        sw.Write("");
                    }

                    if (i < dt.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.WriteLine();
            }
        }

        private static void WriteColumnNames(DataTable dt, StreamWriter sw)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < dt.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.WriteLine();
        }
    }
}