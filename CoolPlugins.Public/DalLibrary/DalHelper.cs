using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace CoolPlugins.Public.DalLibrary
{
    public abstract class DalHelper
    {
        #region 查询一个实体
        /// <summary>
        /// 以主键查询一个实体
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="keyVlaue">主键</param>
        /// <param name="sqlNote">sql注释</param>
        /// <returns>实体数据</returns>
        public static T SelectModel<T>(int keyVlaue, string sqlNote) where T : class, new()
        {
            var tempT = new T();
            var stbSql = new StringBuilder("select ");
            var props = typeof (T).GetProperties();
            foreach (var prop in props)
            {
                stbSql.Append(prop.Name + ",");
            }
            stbSql.Remove(stbSql.ToString().LastIndexOf(','), 1);
            stbSql.AppendFormat(" from [{0}]",GetTableName(tempT.ToString()));
            stbSql.Append(" with(nolock) where 1=1 and Id=@keyVlaue");
            stbSql.Append(sqlNote);
            var sqlParms = new SqlParameter("@keyVlaue", keyVlaue);
            try
            {
                using (IDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, stbSql.ToString(),sqlParms))
                {
                    //Dictionary<string, int> colName = GetColNameIndex(dr);
                    if (dr.Read())
                    {
                        tempT = BuildModel<T>(dr);
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //记日志
                //string errStr = "SelectModel<T>报错(" + (DateTime.Now - dNow).TotalMilliseconds + "ms):\r\n" + cmd.CommandText + "\r\n\r\n"; ;
                //DalAid.DalErr(errStr, ex.ToString(), "DalSelectModel");
                //throw new Exception(errStr, ex);
            }
            return tempT;
        }

        /// <summary>
        /// 以主键查询实体的指定字段
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="keyVlaue">主键</param>
        /// <param name="onlyField">只查询的字段</param>
        /// <param name="sqlNote">sql注释</param>
        /// <returns>实体数据</returns>
        public static T SelectModel<T>(int keyVlaue, List<string> onlyField, string sqlNote) where T : class, new()
        {
            var tempT = new T();
            var stbSql = new StringBuilder("select ");
            stbSql.Append(string.Join(",", onlyField.ToArray()));
            stbSql.Append(" from " + GetTableName(tempT.ToString()));
            stbSql.Append(" with(nolock) where 1=1 and Id=@keyVlaue");
            stbSql.Append(sqlNote);
            var sqlParms = new SqlParameter("@keyVlaue", keyVlaue);
            try
            {
                using (IDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, stbSql.ToString(), sqlParms))
                {
                    //Dictionary<string, int> colName = GetColNameIndex(dr);
                    if (dr.Read())
                    {
                        tempT = BuildModel<T>(dr);
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //记日志
                //string errStr = "SelectModel<T>报错(" + (DateTime.Now - dNow).TotalMilliseconds + "ms):\r\n" + cmd.CommandText + "\r\n\r\n"; ;
                //DalAid.DalErr(errStr, ex.ToString(), "DalSelectModel");
                //throw new Exception(errStr, ex);
            }
            return tempT;
        }

        /// <summary>
        /// 以指定字段查询一个实体
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="sqlNote">sql注释</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="filedValue">字段值</param>
        /// <returns>实体数据</returns>
        public static T SelectModel<T>(string fieldName, string filedValue, string sqlNote) where T : class, new()
        {
            var tempT = new T();
            var stbSql = new StringBuilder("select ");
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                stbSql.Append(prop.Name + ",");
            }
            stbSql.Remove(stbSql.ToString().LastIndexOf(','), 1);
            stbSql.Append(" from " + GetTableName(tempT.ToString()));
            stbSql.AppendFormat(" with(nolock) where 1=1 and {0}={1}", fieldName, "@" + filedValue);
            stbSql.Append(sqlNote);
            var sqlParms = new SqlParameter("@filedValue", filedValue);
            try
            {
                using (IDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, stbSql.ToString(), sqlParms))
                {
                    //Dictionary<string, int> colName = GetColNameIndex(dr);
                    if (dr.Read())
                    {
                        tempT = BuildModel<T>(dr);
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //记日志
                //string errStr = "SelectModel<T>报错(" + (DateTime.Now - dNow).TotalMilliseconds + "ms):\r\n" + cmd.CommandText + "\r\n\r\n"; ;
                //DalAid.DalErr(errStr, ex.ToString(), "DalSelectModel");
                //throw new Exception(errStr, ex);
            }
            return tempT;
        }

        /// <summary>
        /// 以指定字段查询一个实体的字段
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="onlyField">查询的字段</param>
        /// <param name="sqlNote">sql注释</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="filedValue">字段值</param>
        /// <returns>实体数据</returns>
        public static T SelectModel<T>(string fieldName, string filedValue, List<string> onlyField, string sqlNote) where T : class, new()
        {
            var tempT = new T();
            var stbSql = new StringBuilder("select ");
            stbSql.Append(string.Join(",", onlyField.ToArray()));
            stbSql.Append(" from " + GetTableName(tempT.ToString()));
            stbSql.AppendFormat(" with(nolock) where 1=1 and {0}={1}", fieldName, "@" + filedValue);
            stbSql.Append(sqlNote);
            var sqlParms = new SqlParameter("@filedValue", filedValue);
            try
            {
                using (IDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, stbSql.ToString(), sqlParms))
                {
                    //Dictionary<string, int> colName = GetColNameIndex(dr);
                    if (dr.Read())
                    {
                        tempT = BuildModel<T>(dr);
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //记日志
                //string errStr = "SelectModel<T>报错(" + (DateTime.Now - dNow).TotalMilliseconds + "ms):\r\n" + cmd.CommandText + "\r\n\r\n"; ;
                //DalAid.DalErr(errStr, ex.ToString(), "DalSelectModel");
                //throw new Exception(errStr, ex);
            }
            return tempT;
        }

        #endregion

        #region 查询list集合

        /// <summary>
        /// 以主键查询一个实体
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="nameValues">参数集合</param>
        /// <param name="sqlNote">sql注释</param>
        /// <param name="dp">分页</param>
        /// <returns>实体数据</returns>
        public static List<T> SelectList<T>(NameValueCollection nameValues, string sqlNote, DataPage dp = null) 
            where T : class, new()
        {
            var list = new List<T>();
            var whereSql = GetWhereSql(dp,nameValues);

            var selectSql = new StringBuilder(" select ");
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                selectSql.Append(prop.Name + ",");
            }
            selectSql.Remove(selectSql.ToString().LastIndexOf(','), 1);
            selectSql.AppendFormat(" from [{0}]", GetTableName(new T().ToString()));
            selectSql.AppendFormat(" with(nolock) where 1=1 {0}", whereSql.Item1);

            var pageSql = GetPageSql(dp,sqlNote);
            var allSql = pageSql.Item1.Replace("--filterSql",selectSql.ToString());
            var allParms = new SqlParameter[4];
            whereSql.Item2.CopyTo(allParms, 0);
            pageSql.Item2.CopyTo(allParms,2);
            try
            {
                using (IDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, allSql, allParms))
                {
                    //Dictionary<string, int> colName = GetColNameIndex(dr);
                    if (dr.Read())
                    {
                        if (dp != null && dp.PageSize > 0)
                        {
                            dp.RowCount = dr.GetInt32(0);
                        }
                        list.Add(BuildModel<T>(dr));
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //记日志
                //string errStr = "SelectModel<T>报错(" + (DateTime.Now - dNow).TotalMilliseconds + "ms):\r\n" + cmd.CommandText + "\r\n\r\n"; ;
                //DalAid.DalErr(errStr, ex.ToString(), "DalSelectModel");
                //throw new Exception(errStr, ex);
            }
            return list;
        }


        #endregion

        #region ORM框架辅助方法
        /// <summary>
        /// 获取列名
        /// </summary>
        /// <param name="dataRecord"></param>
        /// <returns>列名和索引</returns>
        public static Dictionary<string, int> GetColNameIndex(IDataRecord dataRecord)
        {
            Dictionary<string, int> colName = new Dictionary<string, int>();
            for (int i = 0; i < dataRecord.FieldCount; i++)
            {
                colName.Add(dataRecord.GetName(i), i);
            }
            return colName;
        }

        /// <summary>
        /// 获取datarow列名
        /// </summary>
        /// <param name="dr">datarow行</param>
        /// <returns>列名和索引</returns>
        public static Dictionary<string, int> GetColNameIndex(DataRow dr)
        {
            Dictionary<string, int> colName = new Dictionary<string, int>();
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                colName.Add(dr.Table.Columns[i].ColumnName, i);
            }
            return colName;
        }

        /// <summary>
        /// 将dataReader转换成model
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="idr">IDataReader 对象</param>
        /// <returns>实体</returns>
        public static T BuildModel<T>(IDataReader idr)
        {
            Type modelType = typeof(T);
            T model = Activator.CreateInstance<T>();

            for (int i=0;i<idr.FieldCount;i++)
            {
                if (string.IsNullOrWhiteSpace(idr[i].ToString()) || idr[i] is DBNull)
                    continue;
                PropertyInfo propertyInfo = modelType.GetProperty(idr.GetName(i), BindingFlags.GetProperty | BindingFlags.Public 
                    | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(model, CheckType(idr[i], propertyInfo.PropertyType), null);
                }
            }
            return model;
        }

        /// <summary>
        /// 对可空类型进行判断转换(*要不然会报错)
        /// </summary>
        /// <param name="value">DataReader字段的值</param>
        /// <param name="conversionType">该字段的类型</param>
        /// <returns></returns>
        private static object CheckType(object value, Type conversionType)
        {
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                    return null;
                System.ComponentModel.NullableConverter nullableConverter = new System.ComponentModel.NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, conversionType);
        }

        /// <summary>
        /// 根据带命名空间的表名获取表名称
        /// </summary>
        /// <param name="allName">全名</param>
        /// <returns>表名</returns>
        private static string GetTableName(string allName) 
        {
            return allName.Substring(allName.LastIndexOf('.')+1);
        }

        /// <summary>
        /// 获取where条件
        /// </summary>
        /// <param name="dp">分页</param>
        /// <param name="nameValues">where条件 + 参数集合</param>
        private static Tuple<string,SqlParameter[]> GetWhereSql(DataPage dp, NameValueCollection nameValues)
        {
            var whereSql = new StringBuilder();
            var parms = new SqlParameter[1];
            foreach (string key in nameValues.Keys)
            {
                if (string.IsNullOrWhiteSpace(key)) continue;

                var inValue = new StringBuilder();
                var keyValue = nameValues[key];
                if (keyValue.IndexOf(',')>0)
                {
                    foreach (var splitValue in keyValue.Split(','))
                    {
                        if (key.GetType() == typeof (string))
                        {
                            inValue.Append("'"+splitValue+"'");
                        }
                        if (key.GetType() == typeof (int))
                        {
                            inValue.Append(""+splitValue+"");
                        }
                    }
                }
                if (key.Contains("<>")||key.Contains("!="))  //!=
                {
                    whereSql.AppendFormat(" and {0} != {1}", key, nameValues[key]);
                }
                if (key.Contains("*"))  //in
                {
                    whereSql.AppendFormat(" and {0} in ({1})", key, inValue);                    
                }
                if (key.Contains("!*"))  //not in
                {
                    whereSql.AppendFormat(" and {0} not in ({1})", key, inValue);                    
                }
                if (key.IndexOf("%", StringComparison.Ordinal)==0)  //左like
                {
                    whereSql.AppendFormat(" and {0} like @{1}", key, key);
                    parms[0] = new SqlParameter("@" + key, nameValues[key]);
                }
                if (key.LastIndexOf(key, StringComparison.Ordinal) == key.Length - 1) //右like
                {
                    whereSql.AppendFormat(" and {0} like '{1}'%", key, inValue);
                    parms[parms.Length] = new SqlParameter("@" + key, nameValues[key]);
                }
                else
                {
                    whereSql.AppendFormat(" and {0} = @{1}", key, key);
                    parms[0] = new SqlParameter("@" + key, nameValues[key]);
                }
            }
            if (!string.IsNullOrWhiteSpace(dp.OrderField))
            {
                whereSql.AppendFormat(" order by {0}",dp.OrderField);
            }

            return new Tuple<string, SqlParameter[]>(whereSql.ToString(), parms);
        }

        /// <summary>
        /// 获取分页sql
        /// </summary>
        /// <param name="dp">分页</param>
        /// <param name="sqlNote">sql注释</param>
        /// <returns>sql</returns>
        private static Tuple<string,SqlParameter[]> GetPageSql(DataPage dp,string sqlNote)
        {
            var parms = new SqlParameter[2] ;
            var pageSql = new StringBuilder(@"
            declare @PageSize Int ='15';  
            declare @PageIndex Int ='1';   
            declare @RowCount int;         

            select @RowCount =COUNT(1) FROM
            (--filterSql) AS RCount ;
            select @RowCount AS RCount;  

            IF(@PageIndex *@PageSize> @RowCount)
            SET @PageIndex =@RowCount/ @PageSize+1 ;

            SELECT * FROM( SELECT ROW_NUMBER() OVER (ORDER BY ID DESC ) AS RowID,* FROM (
            --filterSql) as result) AS tempT
            WHERE RowID BETWEEN (@PageIndex - 1) * @PageSize+1 AND @PageIndex * @PageSize ");
            pageSql.Append(sqlNote);

            parms[0] = new SqlParameter("@PageSize",dp.PageSize);
            parms[1] = new SqlParameter("@PageIndex ", dp.PageIndex);

            return new Tuple<string, SqlParameter[]>(pageSql.ToString(), parms);
        }
        
        #endregion
    }
}
