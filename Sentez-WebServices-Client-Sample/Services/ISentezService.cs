using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentez_WebServices_Client_Sample.Services
{
    public interface ISentezService
    {
        Task<string> GetBoId(string loginToken, string BOName, int logicalModuleId,int type,int type2);
        Task<string> GetAll(string loginToken, string BOId);
        Task<string> GetById(string loginToken, string BOId, long RecId);
        Task<string> Login(string userCode, string password, string companyCode, string companyPassword, int userType);
        Task<string> ExecuteQuery(string loginToken, string Query);
        Task<string> PostBO(string loginToken, string boName, Dictionary<string, List<ExpandoObject>> data);
        Task<string> UpdateBO(string loginToken, string boName,long RecId, Dictionary<string, List<ExpandoObject>> data);

    }
}
