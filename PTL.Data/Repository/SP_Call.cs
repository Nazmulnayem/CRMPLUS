using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using PTL.Data.Repository.IRepository;
using PTL.Entity;

namespace PTL.Data.Repository
{
    public class SP_Call : ISP_Call
    {
        private static string ConnectionString = "";
        private static string AddLogRecordConnectionString = "";
        private Hashtable m_Erroobj;
        public SP_Call(IConfiguration db)
        {
            ConnectionString = db.GetConnectionString("DefaultConnection") ?? "";
            AddLogRecordConnectionString = db.GetConnectionString("AddLogRecordConnection") ?? "";
            m_Erroobj = new Hashtable();
        }


        public Hashtable ErrorObject
        {
            get
            {
                return this.m_Erroobj;
            }
        }

        public ServiceResponse<DataSet> GetDataSet(SqlCommand Cmd)
        {
            ServiceResponse<DataSet> response = new ServiceResponse<DataSet>
            {
                Data = new DataSet()
            };
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = Cmd;
                Cmd.CommandTimeout = 0;
                Cmd.Connection = new SqlConnection(ConnectionString);


                adp.Fill(response.Data);

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                response.ExceptionMessage = ex.Message;
            }
            return response;
        }

        public ServiceResponse<DataSet> TableListServiceResponse(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<DataSet>();
            try
            {
                SqlCommand param = new SqlCommand();
                param.CommandText = parm.StoredProcedure;
                param.CommandType = CommandType.StoredProcedure;
                param.Parameters.Add(new SqlParameter("@Comp1", parm.Comp1));
                param.Parameters.Add(new SqlParameter("@CallType", parm.Calltype));
                //param.Parameters.Add("@Dxml01", SqlDbType.Xml).Value = (parm.Dxml01 == null ? null : (parm.Dxml01.GetXml()));
                //param.Parameters.Add("@Dxml02", SqlDbType.Xml).Value = ((parm.Dxml02 == null ? null : parm.Dxml02.GetXml()));               
                param.Parameters.Add(new SqlParameter("@Desc1", parm.Desc01 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc2", parm.Desc02 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc3", parm.Desc03 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc4", parm.Desc04 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc5", parm.Desc05 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc6", parm.Desc06 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc7", parm.Desc07 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc8", parm.Desc08 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc9", parm.Desc09 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc10", parm.Desc10 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc11", parm.Desc11 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc12", parm.Desc12 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc13", parm.Desc13 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc14", parm.Desc14 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc15", parm.Desc15 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc16", parm.Desc16 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc17", parm.Desc17 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc18", parm.Desc18 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc19", parm.Desc19 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc20", parm.Desc20 ?? ""));
                param.Parameters.Add(new SqlParameter("@UserID", parm.UserID ?? ""));


                ServiceResponse<DataSet> result = GetDataSet(param);
                if (!result.IsSuccess || result.Data == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.IsSuccess = false;
                    serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                    serviceResponse.ExceptionMessage = result.ExceptionMessage;
                    return serviceResponse;
                }
                serviceResponse.Data = result.Data;

            }
            catch (Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;

        }

        public ServiceResponse<DataSet> TableList(ClassProAccessParams parm)
        {
            ServiceResponse<DataSet> serviceResponse = new ServiceResponse<DataSet>
            {
                Data = new DataSet()
            };
            try
            {

                SqlCommand param = new SqlCommand();
                param.CommandText = parm.StoredProcedure;
                param.CommandType = CommandType.StoredProcedure;
                param.Parameters.Add(new SqlParameter("@Comp1", parm.Comp1));
                param.Parameters.Add(new SqlParameter("@CallType", parm.Calltype));
                //param.Parameters.Add("@Dxml01", SqlDbType.Xml).Value = (parm.Dxml01 == null ? null : (parm.Dxml01.GetXml()));
                //param.Parameters.Add("@Dxml02", SqlDbType.Xml).Value = ((parm.Dxml02 == null ? null : parm.Dxml02.GetXml()));               
                param.Parameters.Add(new SqlParameter("@Desc1", parm.Desc01 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc2", parm.Desc02 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc3", parm.Desc03 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc4", parm.Desc04 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc5", parm.Desc05 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc6", parm.Desc06 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc7", parm.Desc07 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc8", parm.Desc08 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc9", parm.Desc09 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc10", parm.Desc10 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc11", parm.Desc11 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc12", parm.Desc12 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc13", parm.Desc13 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc14", parm.Desc14 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc15", parm.Desc15 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc16", parm.Desc16 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc17", parm.Desc17 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc18", parm.Desc18 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc19", parm.Desc19 ?? ""));
                param.Parameters.Add(new SqlParameter("@Desc20", parm.Desc20 ?? ""));
                param.Parameters.Add(new SqlParameter("@UserID", parm.UserID ?? ""));


                ServiceResponse<DataSet> result = GetDataSet(param);
                if (!result.IsSuccess || result.Data == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.IsSuccess = false;
                    serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                    serviceResponse.ExceptionMessage = result.ExceptionMessage;
                    return serviceResponse;
                }
                serviceResponse.Data = result.Data;
            }
            catch (Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<bool> Execute22ServiceResponse(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<bool>();
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlCon.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Dxml01", (parm.Dxml01 == null) ? null : parm.Dxml01.GetXml());
                    param.Add("@Dxml02", (parm.Dxml02 == null) ? null : parm.Dxml02.GetXml());
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Execute(parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 240);
                    serviceResponse.Data = true;
                }
                catch (Exception ex)
                {
                    serviceResponse.Data = false;
                    serviceResponse.IsSuccess = false;
                    serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                    serviceResponse.ExceptionMessage = ex.Message;
                }
                return serviceResponse;
            }
        }

        public ServiceResponse<bool> Execute22ServiceResponse2(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<bool>();
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlCon.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Dxml01", (parm.Dxml01 == null) ? null : parm.Dxml01.GetXml());
                    param.Add("@Dxml02", (parm.Dxml02 == null) ? null : parm.Dxml02.GetXml());
                    param.Add("@Dxml02", (parm.Dxml02 == null) ? null : parm.Dxml02.GetXml());
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Execute(parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 240);
                    serviceResponse.Data = true;
                }
                catch (Exception ex)
                {
                    serviceResponse.Data = false;
                    serviceResponse.IsSuccess = false;
                    serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                    serviceResponse.ExceptionMessage = ex.Message;
                }
                return serviceResponse;
            }
        }

        public ServiceResponse<bool> Execute18ServiceResponse(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<bool>();
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlCon.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Execute(parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 240);
                    serviceResponse.Data = true;
                }
                catch (Exception ex)
                {
                    serviceResponse.Data = false;
                    serviceResponse.IsSuccess = false;
                    serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                    serviceResponse.ExceptionMessage = ex.Message;
                }
                return serviceResponse;
            }
        }

        public ServiceResponse<bool> Execute14ServiceResponse(ClassProAccessParams parm, string conn = "")
        {
            var serviceResponse = new ServiceResponse<bool>();
            using (SqlConnection sqlCon = new SqlConnection(conn == "" ? ConnectionString : AddLogRecordConnectionString))
            {
                try
                {
                    sqlCon.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Execute(parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 240);
                    serviceResponse.Data = true;
                }
                catch (Exception ex)
                {
                    serviceResponse.Data = false;
                    serviceResponse.IsSuccess = false;
                    serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                    serviceResponse.ExceptionMessage = ex.Message;
                }
                return serviceResponse;
            }
        }

        public ServiceResponse<bool> Execute25ServiceResponse(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<bool>();

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlCon.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@Desc23", parm.Desc23 ?? "");
                    param.Add("@Desc24", parm.Desc24 ?? "");
                    param.Add("@Desc25", parm.Desc25 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Execute(parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 240);
                    serviceResponse.Data = true;
                }
                catch (Exception ex)
                {
                    serviceResponse.Data = false;
                    serviceResponse.IsSuccess = false;
                    serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                    serviceResponse.ExceptionMessage = ex.Message;
                }

            }
            return serviceResponse;
        }

        public ServiceResponse<bool> Execute40ServiceResponse(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<bool>();
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {

                    sqlCon.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@Desc23", parm.Desc23 ?? "");
                    param.Add("@Desc24", parm.Desc24 ?? "");
                    param.Add("@Desc25", parm.Desc25 ?? "");
                    param.Add("@Desc26", parm.Desc26 ?? "");
                    param.Add("@Desc27", parm.Desc27 ?? "");
                    param.Add("@Desc28", parm.Desc28 ?? "");
                    param.Add("@Desc29", parm.Desc29 ?? "");
                    param.Add("@Desc30", parm.Desc30 ?? "");
                    param.Add("@Desc31", parm.Desc31 ?? "");
                    param.Add("@Desc32", parm.Desc32 ?? "");
                    param.Add("@Desc33", parm.Desc33 ?? "");
                    param.Add("@Desc34", parm.Desc34 ?? "");
                    param.Add("@Desc35", parm.Desc35 ?? "");
                    param.Add("@Desc36", parm.Desc36 ?? "");
                    param.Add("@Desc37", parm.Desc37 ?? "");
                    param.Add("@Desc38", parm.Desc38 ?? "");
                    param.Add("@Desc39", parm.Desc39 ?? "");
                    param.Add("@Desc40", parm.Desc40 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Execute(parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 240);
                    serviceResponse.Data = true;
                }
                catch (Exception ex)
                {
                    serviceResponse.Data = false;
                    serviceResponse.IsSuccess = false;
                    serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                    serviceResponse.ExceptionMessage = ex.Message;
                }
                return serviceResponse;
            }
        }

        public ServiceResponse<IEnumerable<T>> ListServiceResponse<T>(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<T>>();
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1 ?? "");
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Dxml01", (parm.Dxml01 == null) ? null : parm.Dxml01.GetXml());
                    param.Add("@Dxml02", (parm.Dxml02 == null) ? null : parm.Dxml02.GetXml());
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    serviceResponse.Data = sqlCon.Query<T>(parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                serviceResponse.Data = Enumerable.Empty<T>();
                serviceResponse.IsSuccess = false;
                serviceResponse.ExceptionMessage = ex.Message;
                serviceResponse.UIMessage = "Some Problem Occurred. Please contact Developer Team for support.";
            }
            return serviceResponse;

        }

        public ServiceResponse<IEnumerable<T>> ListDataServiceResponse<T>(ClassProAccessParams parm)
        {
            ServiceResponse<IEnumerable<T>> serviceResponse = new ServiceResponse<IEnumerable<T>>();
            try
            {
                IEnumerable<T>? dataResponse = Enumerable.Empty<T>();
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1 ?? "");
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    dataResponse = sqlCon.Query<T>(parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    serviceResponse.Data = dataResponse;
                    return serviceResponse;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Data = Enumerable.Empty<T>();
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;


        }

        public ServiceResponse<IEnumerable<T>> ListDataServiceResponseFr20<T>(ClassProAccessParams parm)
        {
            ServiceResponse<IEnumerable<T>> serviceResponse = new ServiceResponse<IEnumerable<T>>();
            try
            {
                IEnumerable<T>? dataResponse = Enumerable.Empty<T>();
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1 ?? "");
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc14 ?? "");
                    param.Add("@Desc16", parm.Desc14 ?? "");
                    param.Add("@Desc17", parm.Desc14 ?? "");
                    param.Add("@Desc18", parm.Desc14 ?? "");
                    param.Add("@Desc19", parm.Desc14 ?? "");
                    param.Add("@Desc20", parm.Desc14 ?? "");
                    sqlCon.Open();
                    dataResponse = sqlCon.Query<T>(parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    serviceResponse.Data = dataResponse;
                    return serviceResponse;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Data = Enumerable.Empty<T>();
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;


        }

        public ServiceResponse<IEnumerable<T>> ListDataServiceResponseFr14<T>(ClassProAccessParams parm)
        {
            ServiceResponse<IEnumerable<T>> serviceResponse = new ServiceResponse<IEnumerable<T>>();
            try
            {
                IEnumerable<T>? dataResponse = Enumerable.Empty<T>();
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1 ?? "");
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    dataResponse = sqlCon.Query<T>(parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    serviceResponse.Data = dataResponse;
                    return serviceResponse;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Data = Enumerable.Empty<T>();
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;


        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>>> ListServiceResponse<T1, T2>(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>>>();

            Tuple<IEnumerable<T1>, IEnumerable<T2>>? dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>>
                    (new List<T1>(), new List<T2>());

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Dxml01", (parm.Dxml01 == null) ? null : parm.Dxml01.GetXml());
                    param.Add("@Dxml02", (parm.Dxml02 == null) ? null : parm.Dxml02.GetXml());
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();

                    if (item1 != null && item2 != null)
                    {
                        serviceResponse.Data = new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                        return serviceResponse;
                    }
                }
                serviceResponse.Data = dataResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Data = dataResponse;
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> ListServiceResponse<T1, T2, T3>(ClassProAccessParams parm)
        {
            ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>>();
            Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>? dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>
                    (new List<T1>(), new List<T2>(), new List<T3>());
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Dxml01", (parm.Dxml01 == null) ? null : parm.Dxml01.GetXml());
                    param.Add("@Dxml02", (parm.Dxml02 == null) ? null : parm.Dxml02.GetXml());
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    if (item1 != null && item2 != null && item3 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(item1, item2, item3);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                serviceResponse.Data = dataResponse;

            }
            catch (Exception ex)
            {
                serviceResponse.Data = dataResponse;
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;

        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>> ListServiceResponse<T1, T2, T3, T4>(ClassProAccessParams parm)
        {
            ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>> serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>>();
            Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>> dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>(new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>());
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Dxml01", (parm.Dxml01 == null) ? null : parm.Dxml01.GetXml());
                    param.Add("@Dxml02", (parm.Dxml02 == null) ? null : parm.Dxml02.GetXml());
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    var item4 = result.Read<T4>().ToList();
                    if (item1 != null && item2 != null && item3 != null && item4 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>(item1, item2, item3, item4);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                serviceResponse.Data = dataResponse;

            }
            catch (Exception ex)
            {
                serviceResponse.Data = dataResponse;
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;

        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>> ListServiceResponse<T1, T2, T3, T4, T5>(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>>();
            Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>? dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>(), new List<T5>());
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Dxml01", (parm.Dxml01 == null) ? null : parm.Dxml01.GetXml());
                    param.Add("@Dxml02", (parm.Dxml02 == null) ? null : parm.Dxml02.GetXml());
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    var item4 = result.Read<T4>().ToList();
                    var item5 = result.Read<T5>().ToList();
                    if (item1 != null && item2 != null && item3 != null && item4 != null && item5 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>(item1, item2, item3, item4, item5);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                serviceResponse.Data = dataResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Data = dataResponse;
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;


        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>> ListServiceResponse<T1, T2, T3, T4, T5, T6>(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>>();
            Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>? dataResponse = dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
                   (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>(), new List<T5>(), new List<T6>());
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Dxml01", (parm.Dxml01 == null) ? null : parm.Dxml01.GetXml());
                    param.Add("@Dxml02", (parm.Dxml02 == null) ? null : parm.Dxml02.GetXml());
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    var item4 = result.Read<T4>().ToList();
                    var item5 = result.Read<T5>().ToList();
                    var item6 = result.Read<T6>().ToList();
                    if (item1 != null && item2 != null && item3 != null && item4 != null && item5 != null && item6 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>(item1, item2, item3, item4, item5, item6);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                serviceResponse.Data = dataResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Data = dataResponse;
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;


        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>> ListServiceResponse<T1, T2, T3, T4, T5, T6, T7>(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>>();
            Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>> dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>(), new List<T5>(), new List<T6>(), new List<T7>());

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Dxml01", (parm.Dxml01 == null) ? null : parm.Dxml01.GetXml());
                    param.Add("@Dxml02", (parm.Dxml02 == null) ? null : parm.Dxml02.GetXml());
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    var item4 = result.Read<T4>().ToList();
                    var item5 = result.Read<T5>().ToList();
                    var item6 = result.Read<T6>().ToList();
                    var item7 = result.Read<T7>().ToList();
                    if (item1 != null && item2 != null && item3 != null && item4 != null && item5 != null && item6 != null && item7 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>(item1, item2, item3, item4, item5, item6, item7);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                serviceResponse.Data = dataResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Data = dataResponse;
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;


        }

        public ServiceResponse<T> OneRecordServiceResponse<T>(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<T>();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Dxml01", (parm.Dxml01 == null) ? null : parm.Dxml01.GetXml());
                    param.Add("@Dxml02", (parm.Dxml02 == null) ? null : parm.Dxml02.GetXml());
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var value = sqlCon.Query<T>(parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (value != null)
                    {
                        serviceResponse.Data = value.FirstOrDefault();
                    }
                    else 
                    {
                        serviceResponse.Data = Enumerable.Empty<T>().FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Data = Enumerable.Empty<T>().FirstOrDefault();
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>>> ListExecuteServiceResponse<T1, T2>(ClassProAccessParams parm)
        {
            ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>>> serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>>>();
            Tuple<IEnumerable<T1>, IEnumerable<T2>>? dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>>
                    (new List<T1>(), new List<T2>());

            try
            {

                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();

                    if (item1 != null && item2 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                serviceResponse.Data = dataResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Data = dataResponse;
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>>> ListExecuteServiceResponseFr14<T1, T2>(ClassProAccessParams parm)
        {
            ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>>> serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>>>();
            Tuple<IEnumerable<T1>, IEnumerable<T2>>? dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>>
                    (new List<T1>(), new List<T2>());
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();

                    if (item1 != null && item2 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                serviceResponse.Data = dataResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Data = dataResponse;
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> ListExecuteServiceResponse<T1, T2, T3>(ClassProAccessParams parm)
        {
            ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>>();
            try
            {
                Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>? dataResponse = null;
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    if (item1 != null && item2 != null && item3 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(item1, item2, item3);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>
                    (new List<T1>(), new List<T2>(), new List<T3>());

                serviceResponse.Data = dataResponse;

            }
            catch (Exception ex)
            {
                serviceResponse.Data = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>
                   (new List<T1>(), new List<T2>(), new List<T3>());
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;

        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> ListExecuteServiceResponseFr20<T1, T2, T3>(ClassProAccessParams parm)
        {
            ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>>();
            try
            {
                Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>? dataResponse = null;
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    if (item1 != null && item2 != null && item3 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(item1, item2, item3);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>
                    (new List<T1>(), new List<T2>(), new List<T3>());

                serviceResponse.Data = dataResponse;

            }
            catch (Exception ex)
            {
                serviceResponse.Data = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>
                  (new List<T1>(), new List<T2>(), new List<T3>());
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;

        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>> ListExecuteServiceResponse<T1, T2, T3, T4>(ClassProAccessParams parm)
        {
            ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>> serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>>();
            try
            {
                Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>? dataResponse = null;
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    var item4 = result.Read<T4>().ToList();
                    if (item1 != null && item2 != null && item3 != null && item4 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>(item1, item2, item3, item4);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>());

                serviceResponse.Data = dataResponse;

            }
            catch (Exception ex)
            {
                serviceResponse.Data = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>());
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;

        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>> ListExecuteServiceResponse<T1, T2, T3, T4, T5>(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>>();
            try
            {
                Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>? dataResponse = null;

                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    var item4 = result.Read<T4>().ToList();
                    var item5 = result.Read<T5>().ToList();
                    if (item1 != null && item2 != null && item3 != null && item4 != null && item5 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>(item1, item2, item3, item4, item5);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>(), new List<T5>());
                serviceResponse.Data = dataResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;


        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>> ListExecuteServiceResponse<T1, T2, T3, T4, T5, T6>(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>>();
            try
            {
                Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>? dataResponse = null;

                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    var item4 = result.Read<T4>().ToList();
                    var item5 = result.Read<T5>().ToList();
                    var item6 = result.Read<T6>().ToList();
                    if (item1 != null && item2 != null && item3 != null && item4 != null && item5 != null && item6 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>(item1, item2, item3, item4, item5, item6);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>(), new List<T5>(), new List<T6>());
                serviceResponse.Data = dataResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>> ListExecuteServiceResponseFr14<T1, T2, T3, T4, T5, T6>(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>>();
            try
            {
                Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>? dataResponse = null;

                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    var item4 = result.Read<T4>().ToList();
                    var item5 = result.Read<T5>().ToList();
                    var item6 = result.Read<T6>().ToList();
                    if (item1 != null && item2 != null && item3 != null && item4 != null && item5 != null && item6 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>(item1, item2, item3, item4, item5, item6);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>(), new List<T5>(), new List<T6>());
                serviceResponse.Data = dataResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Data = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>(), new List<T5>(), new List<T6>());
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>> ListExecuteServiceResponse<T1, T2, T3, T4, T5, T6, T7>(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>>();
            try
            {
                Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>? dataResponse = null;

                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    var item4 = result.Read<T4>().ToList();
                    var item5 = result.Read<T5>().ToList();
                    var item6 = result.Read<T6>().ToList();
                    var item7 = result.Read<T7>().ToList();
                    if (item1 != null && item2 != null && item3 != null && item4 != null && item5 != null && item6 != null && item7 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>(item1, item2, item3, item4, item5, item6, item7);
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>(), new List<T5>(), new List<T6>(), new List<T7>());
                serviceResponse.Data = dataResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Data = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>(), new List<T5>(), new List<T6>(), new List<T7>());
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>>>> ListExecuteServiceResponseFr9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>>>>();

            try
            {
                Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>>>? dataResponse = null;

                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    var item4 = result.Read<T4>().ToList();
                    var item5 = result.Read<T5>().ToList();
                    var item6 = result.Read<T6>().ToList();
                    var item7 = result.Read<T7>().ToList();
                    var item8 = result.Read<T8>().ToList();
                    var item9 = result.Read<T9>().ToList();

                    if (item1 != null && item2 != null && item3 != null && item4 != null && item5 != null && item6 != null && item7 != null && item8 != null && item9 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>>>(item1, item2, item3, item4, item5, item6, item7, new Tuple<IEnumerable<T8>, IEnumerable<T9>>(item8, item9));
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>(), new List<T5>(), new List<T6>(), new List<T7>(), new Tuple<IEnumerable<T8>, IEnumerable<T9>>(new List<T8>(), new List<T9>()));
                serviceResponse.Data = dataResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Data = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>(), new List<T5>(), new List<T6>(), new List<T7>(), new Tuple<IEnumerable<T8>, IEnumerable<T9>>(new List<T8>(), new List<T9>()));
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>>>> ListExecuteServiceResponseFr11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ClassProAccessParams parm)
        {
            var serviceResponse = new ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>>>>();

            try
            {
                Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>>>? dataResponse = null;

                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Comp1", parm.Comp1);
                    param.Add("@CallType", parm.Calltype);
                    param.Add("@Desc1", parm.Desc01 ?? "");
                    param.Add("@Desc2", parm.Desc02 ?? "");
                    param.Add("@Desc3", parm.Desc03 ?? "");
                    param.Add("@Desc4", parm.Desc04 ?? "");
                    param.Add("@Desc5", parm.Desc05 ?? "");
                    param.Add("@Desc6", parm.Desc06 ?? "");
                    param.Add("@Desc7", parm.Desc07 ?? "");
                    param.Add("@Desc8", parm.Desc08 ?? "");
                    param.Add("@Desc9", parm.Desc09 ?? "");
                    param.Add("@Desc10", parm.Desc10 ?? "");
                    param.Add("@Desc11", parm.Desc11 ?? "");
                    param.Add("@Desc12", parm.Desc12 ?? "");
                    param.Add("@Desc13", parm.Desc13 ?? "");
                    param.Add("@Desc14", parm.Desc14 ?? "");
                    param.Add("@Desc15", parm.Desc15 ?? "");
                    param.Add("@Desc16", parm.Desc16 ?? "");
                    param.Add("@Desc17", parm.Desc17 ?? "");
                    param.Add("@Desc18", parm.Desc18 ?? "");
                    param.Add("@Desc19", parm.Desc19 ?? "");
                    param.Add("@Desc20", parm.Desc20 ?? "");
                    param.Add("@Desc21", parm.Desc21 ?? "");
                    param.Add("@Desc22", parm.Desc22 ?? "");
                    param.Add("@UserID", parm.UserID ?? "");
                    sqlCon.Open();
                    var result = SqlMapper.QueryMultiple(sqlCon, parm.StoredProcedure, param, commandType: System.Data.CommandType.StoredProcedure);
                    var item1 = result.Read<T1>().ToList();
                    var item2 = result.Read<T2>().ToList();
                    var item3 = result.Read<T3>().ToList();
                    var item4 = result.Read<T4>().ToList();
                    var item5 = result.Read<T5>().ToList();
                    var item6 = result.Read<T6>().ToList();
                    var item7 = result.Read<T7>().ToList();
                    var item8 = result.Read<T8>().ToList();
                    var item9 = result.Read<T9>().ToList();
                    var item10 = result.Read<T10>().ToList();
                    var item11 = result.Read<T11>().ToList();
                    if (item1 != null && item2 != null && item3 != null && item4 != null && item5 != null && item6 != null && item7 != null && item8 != null && item9 != null && item10 != null && item11 != null)
                    {
                        dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>>>(item1, item2, item3, item4, item5, item6, item7, new Tuple<IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>>(item8, item9, item10, item11));
                        serviceResponse.Data = dataResponse;
                        return serviceResponse;
                    }
                }
                dataResponse = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>(), new List<T5>(), new List<T6>(), new List<T7>(), new Tuple<IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>>(new List<T8>(), new List<T9>(), new List<T10>(), new List<T11>()));
                serviceResponse.Data = dataResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Data = new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>>>
                    (new List<T1>(), new List<T2>(), new List<T3>(), new List<T4>(), new List<T5>(), new List<T6>(), new List<T7>(), new Tuple<IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>>(new List<T8>(), new List<T9>(), new List<T10>(), new List<T11>()));
                serviceResponse.IsSuccess = false;
                serviceResponse.UIMessage = "Some Error Occured. Please contact PTL Service Team.";
                serviceResponse.ExceptionMessage = ex.Message;
            }
            return serviceResponse;
        }
    }
}