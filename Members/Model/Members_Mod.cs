using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    class Members_Model
    {
        // My Connection String.
        static string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        // Getter and Setter Properties.
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Level { get; set; }

        public string Gender { get; set; }


        // Select Data From Database.
        public DataTable Select()
        {

            // Database Connection

            SqlConnection conn = new SqlConnection(connString);


            DataTable dt = new DataTable();

            try
            {

                // Writing SQL Query.

                string query = "SELECT * FROM members_db";

                SqlCommand sqlc = new SqlCommand(query, conn);


                SqlDataAdapter sad = new SqlDataAdapter(sqlc);

                conn.Open();
                sad.Fill(dt);

            }
            catch (Exception ex) { }

            finally
            {
                conn.Close();
            }

            return dt;

        }

        // Insert Data Into Database.
        public bool Insert(Members_Model c)
        {

            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(connString);


            try
            {

                // Create SQL query to insert Data.

                string sql = "INSERT INTO members_db(FirstName,LastName,Phone,Address,Level,Gender) VALUES(@FirstName,@LastName,@Phone,@Address,@Level,@Gender)";

                SqlCommand sqlc = new SqlCommand(sql, conn);


                sqlc.Parameters.AddWithValue("@FirstName", c.FirstName);
                sqlc.Parameters.AddWithValue("@LastName", c.LastName);
                sqlc.Parameters.AddWithValue("@Phone", c.Phone);
                sqlc.Parameters.AddWithValue("@Address", c.Address);
                sqlc.Parameters.AddWithValue("@Level", c.Level);
                sqlc.Parameters.AddWithValue("@Gender", c.Gender);


                // Connection Open.
                conn.Open();

                int rows = sqlc.ExecuteNonQuery();

                // Success
                if (rows > 0)
                {

                    isSuccess = true;
                }

                else
                {

                    isSuccess = false;
                }

            }
            catch (Exception ex) { }

            finally
            {
                conn.Close();
            }

            return isSuccess;



        }

        // Update  Data In Database.
        public bool Update(Members_Model c)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(connString);

            try
            {

                string sql = "UPDATE members_db SET FirstName=@FirstName,LastName=@LastName,Phone=@Phone,Address=@Address,Level=@Level,Gender=@Gender WHERE Id=@Id";


                SqlCommand sqlc = new SqlCommand(sql, conn);


                sqlc.Parameters.AddWithValue("@FirstName", c.FirstName);
                sqlc.Parameters.AddWithValue("@LastName", c.LastName);
                sqlc.Parameters.AddWithValue("@Phone", c.Phone);
                sqlc.Parameters.AddWithValue("@Address", c.Address);
                sqlc.Parameters.AddWithValue("@Level", c.Level);
                sqlc.Parameters.AddWithValue("@Gender", c.Gender);
                sqlc.Parameters.AddWithValue("@Id", c.ID);

                // Connection Open.
                conn.Open();

                int rows = sqlc.ExecuteNonQuery();

                // Success
                if (rows > 0)
                {

                    isSuccess = true;
                }

                else
                {

                    isSuccess = false;
                }


            }
            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        // Delete Data In Database.
        public bool Delete(Members_Model c)
        {

            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(connString);


            try
            {

                string sql = "DELETE FROM members_db WHERE Id=@Id";

                SqlCommand sqlc = new SqlCommand(sql, conn);

                sqlc.Parameters.AddWithValue("@Id", c.ID);


                conn.Open();

                int rows = sqlc.ExecuteNonQuery();

                // Success
                if (rows > 0)
                {
                    isSuccess = true;
                }

                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex) { }
            finally
            {

                conn.Close();
            }

            return isSuccess;
        }


    }

}