using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections;
using System.Data;

namespace TextToPDFConverter
{
    public static class data
    {
        public static string GenerateTextData()
        {
            string path = @"C://test/test.txt";
            StringBuilder sb = new StringBuilder();

            using (MySqlConnection cnn = new MySqlConnection(ConfigurationManager.ConnectionStrings["BirdDog"].ToString()))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "Select StationName, MeterType from station";
                    //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            if (i % 2 == 0)
                            {
                                sb.Append("Meter Name:" + dr.GetValue(i).ToString());
                            }
                            else
                            {
                                sb.AppendLine(";Meter Type:" + dr.GetValue(i).ToString());
                            }
                        }
                    }
                }
            }

            using (StreamWriter outfile = new StreamWriter(path, false))
            {
                outfile.Write(sb.ToString());
            }
            return path;
        }
    }
}
