using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers.Bases;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using LouACH;
using net.authorize.sample;

namespace LouACH.DataBaseTransactions
{
    public class DataBase
    {
        //public static string EmployerID = "2";
        public static string connectionString = Constants.CONNECTION_STRING;
        public static bankAccountType ReadBankData()
        {
            string queryString = "select A.*,B.BANKNAME from EMPLOYER A join ROUTINGNOS B on A.TRANSITNO=B.BANKROUTINGNUMBER where EMPLOYERID=" + LouACH.Main.EmployerID;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand(queryString, connection);
                connection.Open();
                OracleDataReader reader;
                reader = command.ExecuteReader();

                // Always call Read before accessing data.
                //while (reader.Read())
                //{
                //    theOutput = theOutput + "<p/>" + reader.GetString(7);
                //    //Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetString(1));
                reader.Read();
                var bankAccount = new bankAccountType
                {
                    routingNumber = Convert.ToString(reader.GetInt32(4)),
                    accountNumber = Convert.ToString(reader.GetValue(6)),
                    echeckType = echeckTypeEnum.WEB,   // change based on how you take the payment (web, telephone, etc)
                    nameOnAccount = reader.GetString(7),
                    bankName=reader.GetString(8)
                };
                reader.Close();
                return bankAccount;
                //}
                //reader.Read();
                //return reader;
                // Always call Close when done reading.
                //reader.Close();
            };
        }

        public static string WriteTransactionData(string TransID, decimal Amount,bankAccountType bankAccount)
        {
            string queryString = "insert into ACHITEM (TRANSITNO,BANKACCT,AMOUNT,ACCTNAME,TRANSDATETIME,TRANSID) values(:TS_NO,:BK_ACC,:amount,:AC_NAM,CURRENT_TIMESTAMP,:TS_ID)";
            //string queryString = "insert into ACHITEM (TRANSITNO,BANKACCT,AMOUNT,ACCTNAME) values(:TS_NO,:BK_ACC,:amount,:AC_NAM)";
            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand(queryString, connection))
            {
                command.Parameters.Add("TS_NO", bankAccount.routingNumber);
                command.Parameters.Add("BK_ACC", bankAccount.accountNumber);
                command.Parameters.Add("amount", Amount);
                command.Parameters.Add("AC_NAM", bankAccount.nameOnAccount);
                command.Parameters.Add("TS_ID", TransID);
                //command.Parameters.Add("TS_TIM", DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss"));
                //command.Parameters.Add("TS_TIM", DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss"));
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            return "Success";
        }
        public static Decimal AmountDue()
        {
            string queryString = "select * from ACCOUNTS_DUE where EMPLOYERID=" + LouACH.Main.EmployerID;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand(queryString, connection);
                connection.Open();
                OracleDataReader reader;
                reader = command.ExecuteReader();

                // Always call Read before accessing data.
                //while (reader.Read())
                //{
                //    theOutput = theOutput + "<p/>" + reader.GetString(7);
                //    //Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetString(1));
                reader.Read();
                return reader.GetDecimal(2);
            };
        }

        //public static void getEmployersDropDowndataX()
        //{
        //    string queryString = "select A.* from EMPLOYER A  where EMPLOYERID=" + EmployerID;
        //    using (OracleConnection connection = new OracleConnection(connectionString))
        //    {
        //        OracleCommand command = new OracleCommand(queryString, connection);
        //        connection.Open();
        //        OracleDataReader EmployerData;
        //        EmployerData = command.ExecuteReader();
        //        if (EmployerData.HasRows)
        //        {
        //            LouACH.Main.ddlEmployers.DataSource = EmployerData;
        //            LouACH.Main.ddlEmployers.DataValueField = "EMPLOYERID";
        //            LouACH.Main.ddlEmployers.DataTextField = "ACCTNAME";
        //            LouACH.Main.ddlEmployers.DataBind();
        //        }
        //        else
        //        {
        //            //MessageBox.Show("No is found");
        //            //CloseConnection = new connection();
        //            //CloseConnection.closeConnection(); // close the connection 
        //        }
        //    }
        //}

        public static DataTable getEmployersDropDowndata()
        {
            string cmdstr = "select A.* from EMPLOYER A order by EMPLOYERID";
            
            using (OracleConnection constr = new OracleConnection(connectionString))
            {
                OracleDataAdapter adapter = new OracleDataAdapter(cmdstr, constr);
                // Create the builder for the adapter to automatically generate
                // the Command when needed
                //OracleCommandBuilder builder = new OracleCommandBuilder(adapter);

                // Create and fill the DataSet using the EMP
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "EMP");

                // Get the EMP table from the dataset
               DataTable table = dataset.Tables["EMP"];
               return table;
                //LouACH.Main.ddlEmployers.DataValueField = "EMPLOYERID";
                //LouACH.Main.ddlEmployers.DataTextField = "ACCTNAME";
                //LouACH.Main.ddlEmployers.DataSource = table;

                //LouACH.Main.ddlEmployers.DataBind();
                
                
                
                //OracleCommand command = new OracleCommand(queryString, connection);
                //connection.Open();
                //OracleDataReader EmployerData;
                //EmployerData = command.ExecuteReader();
                //if (EmployerData.HasRows)
                //{
                //    LouACH.Main.ddlEmployers.DataSource = EmployerData;
                //    LouACH.Main.ddlEmployers.DataValueField = "EMPLOYERID";
                //    LouACH.Main.ddlEmployers.DataTextField = "ACCTNAME";
                //    LouACH.Main.ddlEmployers.DataBind();
                //}
                //else
                //{
                //    //MessageBox.Show("No is found");
                //    //CloseConnection = new connection();
                //    //CloseConnection.closeConnection(); // close the connection 
                //}
            }
        }
   
        
        
        
        
        
        //        //OracleConnection conn = new OracleConnection();conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnetionString"].ConnectionString;
                //    OracleConnection conn = new OracleConnection(connectionString)    
                //    OracleCommand cmd = new OracleCommand("SELECT EMPLOYEE_ID ID, EMPLOYEE_NAME VALUE FROM EMPLOYEE MASTER",conn);
                //        OracleDataAdapter oda = new OracleDataAdapter(cmd);
                //        DataSet ds = new DataSet();
                //        oda.Fill(ds);
                //        Dropdown.DataSource = ds;
                //        Dropdown.DataTextField = "VALUE";
                //        Dropdown.DataValueField = "ID";
                //        Dropdown.DataBind();
        
                //}
               
                //public DataTable DataTableQuery(string sql)
                //{
                //    DataTable table = new DataTable();
                //    try
                //    {
                //        using (OracleConnection connection = new OracleConnection(_connectString))
                //        {
                //            connection.Open();
                //            using (OracleCommand oracleCommand = new OracleCommand())
                //            {
                //                oracleCommand.CommandText = Regex.Replace(sql, @"\s+", " ");
                //                oracleCommand.Connection = connection;
                //                using (
                //                    OracleDataReader dataReader = oracleCommand.ExecuteReader(CommandBehavior.CloseConnection))
                //                {
                //                    table.Load(dataReader);
                //                }
                //            }
                //        }
                //    }
                //    catch (Exception e)
                //    {
                //        Console.WriteLine(e);
                //    }
                //    return table;
                //}
                //protected virtual DataTable ConnectAndQuery()
                //{
                //    OracleConnection conn = new OracleConnection();
                //    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                //    conn.Open();
                //    OracleCommand command = conn.CreateCommand();
                //    string sql = "SELECT EMPLOYEE_ID ID, EMPLOYEE_NAME VALUE FROM EMPLOYEE MASTER";
                //    command.CommandText = sql;
                //    OracleDataReader reader = command.ExecuteReader();
                //    DataTable dtusertables = new DataTable();
                //    dtusertables.Load(reader);
                //    if (null != reader && !reader.IsClosed)
                //    {
                //        reader.Close();
                //    }
                //    return dtusertables;
                //}
   
    }
}