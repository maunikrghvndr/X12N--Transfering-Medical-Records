using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X12N.Repository
{
    class ClaimRepository
    {

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["X12N"].ToString();
        private readonly SqlConnection _sqlConnection;
        private string instanceName = string.Empty;
        

        /// <summary>
        /// Construct the connection pool to the SQL server machine.
        /// </summary>
        public ClaimRepository()
        {
            if (_sqlConnection == null)
                _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();

        }


        /// <summary>
        /// The following function is used to get the eligibility details from the database, 
        /// these are the records that are supposed to be processed
        /// </summary>
        /// <param name="rowCount">RowCount</param>
        /// <param name="InputSP">Name of the SP to call.</param>
        /// <returns></returns>
        public DataSet GetClaimDetails( string procName, int rowCount = 1)
        {
            // "GetClaimDetails"
            DataSet ds = new DataSet("NCPDP");
            try
            {
            
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(procName, connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@RowCount", rowCount));
                        using (SqlDataAdapter sqldatAdapter = new SqlDataAdapter())
                        {
                            sqldatAdapter.SelectCommand = command;
                            sqldatAdapter.Fill(ds);
                        }
                    }
                    return ds;
                }
            }
            catch (Exception ex)
            {
                //LogWriter.LogWrite(string.Format("{0} , Message : {1}", "GetInputclaimDetails", ex.Message));
                return null;
            }
           
        }


        public bool UpdateClaimStatus(string id, bool status)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "[dbo].[UpdateClaimStatus]"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.Parameters.Add(new SqlParameter("@ProcessStatus",status));
                command.Connection = connection;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                    command.Dispose();
                }
            }

        }
    }
}
