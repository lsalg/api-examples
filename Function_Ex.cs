public List<TempObj> GetProps(int id = 0, string PROP_DATE = null, string PROP_DATE2 = null)
{
    //creates list of type object
            List<TempObj> ls = new List<TempObj>();
            //using connection
            using (SqlConnection con = new SqlConnection(conPROJECT_SQL))
            {
                //using sql cmd of 
                using (SqlCommand cmd = new SqlCommand("uspPROJECT_SearchProps", con))
                {
                    //sets cmd type to SP
                    cmd.CommandType = CommandType.StoredProcedure;
                    //parameters of SP
                    if (id != 0)
                        cmd.Parameters.AddWithValue("@id", id);
                    if (!String.IsNullOrEmpty(FrmDate))
                        cmd.Parameters.AddWithValue("@PROP_DATE", PROP_DATE2);
                    if (!String.IsNullOrEmpty(ToDate))
                        cmd.Parameters.AddWithValue("@PROP_DATE2", PROP_DATE2);

                    //opens connection
                    con.Open();
                    //exec sql command
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    //reades cmd
                    while (reader.Read())
                    {
                        TempObj item = new TempObj();
                        item.id = Convert.ToInt32(reader["id"]);
                        item.PROP1 = reader["PROP1"] is DBNull ? "" : (string)reader["PROP1"];
                        item.PROP2 = reader["PROP2"] is DBNull ? "" : (string)reader["PROP2"];
                        item.PROP3 = reader["PROP3"] is DBNull ? "" : (string)reader["PROP3"];
                        item.PROP4 = Convert.ToBoolean(reader["PROP4"]);
                        ls.Add(item);
                    }
                    //closes connection
                    con.Close();
                }
            }
            return ls;
}