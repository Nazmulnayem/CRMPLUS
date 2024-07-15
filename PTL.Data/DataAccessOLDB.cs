using Dapper;
using Microsoft.AspNetCore.Hosting;
using PTL.Entity;
using PTL.Entity.Auth;
using System.Data;
using System.Data.OleDb;

namespace PTL.Data
{
    public interface IDataAccessOLDB
    {
        public Task<ServiceResponse<IEnumerable<EClassCompany>>> GetData(string sqlQuery);
        public ServiceResponse<DataSet> GetDataSet(string sqlQuery);
        public Task<ServiceResponse<EClassCompany>> GetCompanyInfo(string sqlQuery, string comcod);
        public Task<ServiceResponse<string>> UpdateCompInfo(string sqlQuery, EClassCompany obj, string comcod);
    }

    public class DataAccessOLDB : IDataAccessOLDB
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string? _connectionString;

        public DataAccessOLDB(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            var _comPath = _webHostEnvironment.WebRootPath + "\\COMPDB\\ASITCOMPDB.accdb";
            _connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _comPath + ";Jet OLEDB:Database Password=@*asit*%#";
        }


        public async Task<ServiceResponse<IEnumerable<EClassCompany>>> GetData(string sqlQuery)
        {
            ServiceResponse<IEnumerable<EClassCompany>> response = new ServiceResponse<IEnumerable<EClassCompany>>();
            try
            {
                using (var connection = new OleDbConnection(_connectionString))
                {                    
                    await connection.OpenAsync();
                    string query = string.Format(sqlQuery);
                    var result = await connection.QueryAsync<EClassCompany>(query);
                   
                    if (result != null && result.Any())
                    {
                        response.Data = result.ToList();
                    }
                    else
                    {
                        response.Data = null;
                        response.IsSuccess = false;                       
                    }
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;                
                response.ExceptionMessage = ex.Message;
            }
            return response;
        }

        public ServiceResponse<DataSet> GetDataSet(string sqlQuery)
        {
            ServiceResponse<DataSet> response = new ServiceResponse<DataSet>
            {
                Data = new DataSet()
            };
            try
            {
                using (var connection = new OleDbConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new OleDbCommand(sqlQuery, connection))
                    {
                        using (var adapter = new OleDbDataAdapter(command))
                        {
                            if (adapter != null) 
                            {
                                adapter.Fill(response.Data);
                            }
                            else
                            {
                                response.Data = null;
                                response.IsSuccess = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.ExceptionMessage = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<EClassCompany>> GetCompanyInfo(string sqlQuery, string comcod)
        {
            ServiceResponse<EClassCompany> response = new ServiceResponse<EClassCompany>();
            try
            {
                using (var connection = new OleDbConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query = string.Format(sqlQuery);
                    var result = await connection.QueryAsync<EClassCompany>(query, new {comcod = comcod });

                    if (result != null && result.Any())
                    {
                        response.Data = result.FirstOrDefault();
                    }
                    else
                    {
                        response.Data = null;
                        response.IsSuccess = false;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.ExceptionMessage = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> UpdateCompInfo(string sqlQuery, EClassCompany obj, string comcod)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();

            try
            {
                using (var connection = new OleDbConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (OleDbCommand cmd = new OleDbCommand(sqlQuery, connection))
                    {

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            response.Data = null;
                            response.IsSuccess = true;
                        }
                        else
                        {
                            response.Data = null;
                            response.IsSuccess = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.ExceptionMessage = ex.Message;
            }
            return response;
        }
    }
}
