using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolPlugins.Public.DalLibrary
{
    public class DalExt
    {
        /// <summary>
        /// 参数转换成sql变量申明,主要是调试和记录日志用
        /// </summary>
        /// <param name="pars">参数集合</param>
        /// <returns>string</returns>
        public static string SqlParameterWrapperToString(SqlParameter[] pars)
        {
            StringBuilder declare = new StringBuilder();
            if (pars == null) return declare.ToString();
            foreach (var par in pars)
            {
                string suffix = "";
                if (par.SqlDbType == SqlDbType.NVarChar || par.SqlDbType == SqlDbType.VarChar)
                    suffix = "(" + (par.Size + 1) + ")";
                declare.AppendLine("declare @" + par.ParameterName.TrimStart('@') + " " +
                                   par.SqlDbType + suffix + " ='" + par.Value + "';");
            }
            return declare.ToString();
        }

    }
}
