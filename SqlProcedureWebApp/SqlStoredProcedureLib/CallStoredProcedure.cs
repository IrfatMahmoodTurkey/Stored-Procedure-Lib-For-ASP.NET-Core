using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SqlStoredProcedureLib
{
    public class CallStoredProcedure
    {
        // call and get data
        // data will returned by json string list
        public static List<string> CallAndGet(string connectionString, string procedureName, List<ProcedureParams> paramList)
        {
            // run procedure
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(procedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            if (paramList != null)
            {
                if (paramList.Count > 0)
                {
                    foreach (ProcedureParams param in paramList)
                    {
                        cmd.Parameters.AddWithValue("@" + param.ParamName, param.Param);
                    }
                }
            }

            SqlDataReader reader = cmd.ExecuteReader();
            List<string> columnList = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();

            List<string> objects = new List<string>();

            while (reader.Read())
            {
                string jsonString = "";

                foreach (string columnName in columnList)
                {
                    if (string.IsNullOrEmpty(jsonString))
                    {
                        jsonString = "'" + columnName + "':'" + reader[columnName] + "'";
                    }
                    else
                    {
                        jsonString = jsonString + ",'" + columnName + "':'" + reader[columnName] + "'";
                    }
                }

                objects.Add("{" + jsonString + "}");
            }

            con.Close();
            return objects;
        }
    }
}
