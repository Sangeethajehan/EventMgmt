using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

public class SQLDAL : IDisposable
{
    private MySqlConnection mobjConn;
    private MySqlTransaction mobjTran;
    string strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    public SQLDAL()
    {
        try
        {
            mobjConn = CreateConnection(strConn);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Dispose()
    {
        try
        {
            TerminateConnection();
            GC.SuppressFinalize(this);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void TerminateConnection()
    {
        try
        {
            if (!(mobjConn == null))
            {
                if (mobjConn.State == ConnectionState.Open)
                {
                    mobjConn.Close();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            mobjConn = null;
        }
    }

    public MySqlConnection CreateConnection(string strConnection)
    {
        MySqlConnection objCon;
        try
        {
            objCon = new MySqlConnection(strConnection);
            objCon.Open();
            return objCon;
        }
        catch (Exception ex)
        {
            return null;
            throw ex;
        }
    }

    public MySqlCommand AddParameter(MySqlCommand Command, String ParamName, MySqlDbType PrmType,
                                ParameterDirection PrmDirection, int intSize, Object Value)
    {
        try
        {
            Command.Parameters.Add(new MySqlParameter(ParamName, PrmType, intSize, PrmDirection, false, Byte.MinValue, Byte.MinValue, null, DataRowVersion.Current, Value));
            return Command;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public MySqlCommand AddParameter(MySqlCommand Command, String ParamName, Object Value)
    {
        try
        {
            Command.Parameters.Add(new MySqlParameter(ParamName, Value));
            return Command;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public MySqlCommand AddParameter(MySqlCommand Command, String ParamName, SqlDbType PrmType)
    {
        try
        {
            Command.Parameters.Add(new MySqlParameter(ParamName, PrmType));
            return Command;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public MySqlCommand AddParameter(MySqlCommand Command, String ParamName, MySqlDbType PrmType, int Size)
    {
        try
        {
            Command.Parameters.Add(new MySqlParameter(ParamName, PrmType, Size, null));
            return Command;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet CreateDataset(string strTblName, MySqlCommand Command)
    {
        MySqlDataAdapter objDA = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {

            objDA.SelectCommand = Command;
            objDA.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDA = null;
        }
    }

    public DataTable CreateDataTable(MySqlCommand Command)
    {
        MySqlDataAdapter objDA = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        try
        {

            objDA.SelectCommand = Command;
            objDA.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDA = null;
        }
    }

    public void AppendDataset(string TableName, ref MySqlCommand Command, ref DataSet objSqlDS)
    {

        MySqlDataAdapter objSqlDA = new MySqlDataAdapter();

        try
        {
            objSqlDA.SelectCommand = Command;

            if (objSqlDS == null == false)
            {
                if (string.Compare(TableName, string.Empty) != 0)
                {
                    objSqlDA.Fill(objSqlDS, TableName);
                }
                else
                {
                    objSqlDA.Fill(objSqlDS);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSqlDA = null;
        }

    }

    public MySqlCommand CreateCommand(MySqlCommand Command, CommandType CmdType, string CmdText)
    {
        try
        {
            Command = new MySqlCommand();
            {
                Command.Connection = mobjConn;
                Command.CommandType = CmdType;
                Command.CommandText = CmdText;
            }
            return Command;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void SetCmdText(ref MySqlCommand Command, string CmdText)
    {

        try
        {
            Command.CommandText = CmdText;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void BeginTransaction()
    {

        try
        {
            if (mobjConn == null == false)
            {
                if (mobjConn.State == ConnectionState.Open)
                {
                    mobjTran = mobjConn.BeginTransaction(IsolationLevel.ReadCommitted);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public MySqlTransaction GetTransaction()
    {
        MySqlTransaction functionReturnValue = default(MySqlTransaction);

        try
        {
            functionReturnValue = mobjConn.BeginTransaction();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return functionReturnValue;

    }

    public Int64 ExecuteQuery(MySqlCommand Command)
    {
        Int64 functionReturnValue = default(Int64);

        try
        {
            Command.Transaction = mobjTran;
            functionReturnValue = Command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return functionReturnValue;
    }
    public void EndTransaction(bool TranSuccess)
    {

        try
        {
            if ((mobjTran != null))
            {
                if (TranSuccess == true)
                {
                    mobjTran.Commit();
                }
                else
                {
                    mobjTran.Rollback();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            mobjTran = null;
        }

    }

    public void RemoveParameters(ref MySqlCommand Command)
    {

        try
        {
            {
                while (!(Command.Parameters.Count == 0))
                {
                    Command.Parameters.RemoveAt(0);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }



    public DataTable ReturnUpdatedTable(ref MySqlDataAdapter objDA, ref DataSet objDS, ref MySqlCommand objCommand)
    {
        DataTable functionReturnValue = default(DataTable);

        DataViewRowState objDVRS = default(DataViewRowState);

        DataTable objTbl = objDS.Tables[0];
        int intStatus = 0;

        try
        {
            objDVRS = DataViewRowState.Added | DataViewRowState.ModifiedCurrent;
            foreach (DataRow objRow1 in objTbl.Select("", "", objDVRS))
            {
                switch (objRow1.RowState)
                {
                    case DataRowState.Added:
                        objDA.InsertCommand = objCommand;
                        break;
                    case DataRowState.Modified:
                        objDA.UpdateCommand = objCommand;
                        break;
                    case DataRowState.Deleted:
                        objDA.DeleteCommand = objCommand;
                        break;
                }
            }
            intStatus = objDA.Update(objDS, "T1");
            objDS.Clear();
            objDA.Fill(objTbl);
            functionReturnValue = objTbl;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objTbl = null;

        }
        return functionReturnValue;
    }
}