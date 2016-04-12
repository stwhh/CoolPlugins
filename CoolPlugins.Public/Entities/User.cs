using System;
using System.Collections.Generic;
using System.Data;
using TCSmartFramework.DataAccess;
using Cool.DalLibrary;
namespace CoolPlugins.Public.Entities
{
	///<summary>用户表</summary>
	public partial class User : ITableBase<User>
	{
		#region  User表元信息
		public const string DbName = "BenqOA";//库名
		public const string TableName = "User";//表名
		public const string PkName = "ID";//主键名
		public const string InsertSql = @"insert Into " + DbName + ".dbo.User (UserCode,RealName,UserPwd,Sex,Age,Phone,QQ,Email,Address,EntryDate,PositionCode,DepartmentCode,CreateTime,CreateUserCode,ModifyTime,ModifyUserCode,Addtion1,Addtion2)values(@UserCode,@RealName,@UserPwd,@Sex,@Age,@Phone,@QQ,@Email,@Address,@EntryDate,@PositionCode,@DepartmentCode,@CreateTime,@CreateUserCode,@ModifyTime,@ModifyUserCode,@Addtion1,@Addtion2);";
		public const string SelectSql = @"select ID,UserCode,RealName,UserPwd,Sex,Age,Phone,QQ,Email,Address,EntryDate,PositionCode,DepartmentCode,CreateTime,CreateUserCode,ModifyTime,ModifyUserCode,Addtion1,Addtion2 from " + DbName + ".dbo.User with(nolock) where 1 = 1 ";
		public const string DeleteSql = @"delete from  " + DbName + ".dbo.User where ID = @ID;";
		public static readonly Dictionary<string,Type> FieldNames;//字段
		public static readonly Dictionary<string, string> FieldNotes;//字备注
		static User()
		{
		   FieldNames = new Dictionary<string,Type> {{ "ID", typeof(int) },{ "UserCode", typeof(string) },{ "RealName", typeof(string) },{ "UserPwd", typeof(string) },{ "Sex", typeof(string) },{ "Age", typeof(int) },{ "Phone", typeof(string) },{ "QQ", typeof(string) },{ "Email", typeof(string) },{ "Address", typeof(string) },{ "EntryDate", typeof(DateTime) },{ "PositionCode", typeof(string) },{ "DepartmentCode", typeof(string) },{ "CreateTime", typeof(DateTime) },{ "CreateUserCode", typeof(string) },{ "ModifyTime", typeof(DateTime) },{ "ModifyUserCode", typeof(string) },{ "Addtion1", typeof(string) },{ "Addtion2", typeof(string) }};
		   FieldNotes = new Dictionary<string,string> {{ "ID", ""},{ "UserCode", "请假用户编号"},{ "RealName", "真实姓名"},{ "UserPwd", "用户密码"},{ "Sex", "用户性别"},{ "Age", "用户年龄"},{ "Phone", "用户电话"},{ "QQ", "用户QQ"},{ "Email", "用户邮箱"},{ "Address", "用户地址"},{ "EntryDate", "用户入职时间"},{ "PositionCode", "职位编号"},{ "DepartmentCode", "部门编号"},{ "CreateTime", "创建时间"},{ "CreateUserCode", "创建者编号"},{ "ModifyTime", "修改时间"},{ "ModifyUserCode", "修改者编号"},{ "Addtion1", "预留1"},{ "Addtion2", "预留2"}};
		}
		/// <summary>库名</summary>
		public string GetDbName() { return DbName;}
		/// <summary>表名</summary>
		public string GetTableName() { return TableName;}
		/// <summary>主键名</summary>
		public string GetPkName() { return PkName;}
		/// <summary>插入Sql</summary>
		public string GetInsertSql(){return InsertSql;}
		/// <summary>查询Sql</summary>
		public string GetSelectSql(){return SelectSql;}
		/// <summary>删除Sql</summary>
		public string GetDeleteSql(){return DeleteSql;}
		/// <summary>字段类型集合</summary>
		public Dictionary<string,Type> GetFieldNames() { return FieldNames;}
		/// <summary>字段备注集合</summary>
		public Dictionary<string,string> GetFieldNotes() { return FieldNotes;}
		#endregion
		#region  User默认值
		public User()
		{
			SetDefaultValue();
		}
		public void SetDefaultValue()
		{
			if (UserCode == null)UserCode = "";
			if (RealName == null)RealName = "";
			if (UserPwd == null)UserPwd = "";
			if (Sex == null)Sex = "";
			if (Phone == null)Phone = "";
			if (QQ == null)QQ = "";
			if (Email == null)Email = "";
			if (Address == null)Address = "";
			if (PositionCode == null)PositionCode = "";
			if (DepartmentCode == null)DepartmentCode = "";
			if (CreateUserCode == null)CreateUserCode = "";
			if (ModifyUserCode == null)ModifyUserCode = "";
			if (Addtion1 == null)Addtion1 = "";
			if (Addtion2 == null)Addtion2 = "";
		}
		#endregion
		#region  User属性19
		///<summary>,int4</summary>
		public int ID{ get; set; }
		///<summary>用户名,string20</summary>
		public string UserCode{ get; set; }
		///<summary>真实姓名,string20</summary>
		public string RealName{ get; set; }
		///<summary>用户密码,string50</summary>
		public string UserPwd{ get; set; }
		///<summary>用户性别,string10</summary>
		public string Sex{ get; set; }
		///<summary>用户年龄,int4</summary>
		public int Age{ get; set; }
		///<summary>用户电话,string11</summary>
		public string Phone{ get; set; }
		///<summary>用户QQ,string20</summary>
		public string QQ{ get; set; }
		///<summary>用户邮箱,string50</summary>
		public string Email{ get; set; }
		///<summary>用户地址,string100</summary>
		public string Address{ get; set; }
		///<summary>用户入职时间,DateTime8</summary>
		public DateTime EntryDate{ get; set; }
		///<summary>职位编号,string20</summary>
		public string PositionCode{ get; set; }
		///<summary>部门编号,string20</summary>
		public string DepartmentCode{ get; set; }
		///<summary>创建时间,DateTime8</summary>
		public DateTime CreateTime{ get; set; }
		///<summary>创建者编号,string20</summary>
		public string CreateUserCode{ get; set; }
		///<summary>修改时间,DateTime8</summary>
		public DateTime ModifyTime{ get; set; }
		///<summary>修改者编号,string20</summary>
		public string ModifyUserCode{ get; set; }
		///<summary>预留1,string50</summary>
		public string Addtion1{ get; set; }
		///<summary>预留2,string50</summary>
		public string Addtion2{ get; set; }
		#endregion
		/// <summary>主键int</summary>
		public object PkValue { get { return ID; } set { if (value is int)ID = (int)value; } } 
		/// <summary>得到主键集合</summary>
		public Dictionary<string, object> GetPkValues()
		{
		    Dictionary<string, object> pkValues = new Dictionary<string, object>();
		    pkValues.Add("ID", ID);
		    return pkValues;
		}
		///<summary>实体到参数</summary>
		/// <param name="haveDentity">是否包含自增长列</param>
		public SqlParameterWrapperCollection ToSqlParameters(bool haveDentity=true)
		{
			SqlParameterWrapperCollection collection = new SqlParameterWrapperCollection();
			if (haveDentity) collection.Add(new SqlParameterWrapper("@ID", ID));
			collection.Add(new SqlParameterWrapper("@UserCode", UserCode));
			collection.Add(new SqlParameterWrapper("@RealName", RealName));
			collection.Add(new SqlParameterWrapper("@UserPwd", UserPwd));
			collection.Add(new SqlParameterWrapper("@Sex", Sex));
			collection.Add(new SqlParameterWrapper("@Age", Age));
			collection.Add(new SqlParameterWrapper("@Phone", Phone));
			collection.Add(new SqlParameterWrapper("@QQ", QQ));
			collection.Add(new SqlParameterWrapper("@Email", Email));
			collection.Add(new SqlParameterWrapper("@Address", Address));
			collection.Add(new SqlParameterWrapper("@EntryDate", EntryDate));
			collection.Add(new SqlParameterWrapper("@PositionCode", PositionCode));
			collection.Add(new SqlParameterWrapper("@DepartmentCode", DepartmentCode));
			collection.Add(new SqlParameterWrapper("@CreateTime", CreateTime));
			collection.Add(new SqlParameterWrapper("@CreateUserCode", CreateUserCode));
			collection.Add(new SqlParameterWrapper("@ModifyTime", ModifyTime));
			collection.Add(new SqlParameterWrapper("@ModifyUserCode", ModifyUserCode));
			collection.Add(new SqlParameterWrapper("@Addtion1", Addtion1));
			collection.Add(new SqlParameterWrapper("@Addtion2", Addtion2));
			return collection;
		}
		///<summary>分析sql添加参数</summary>
		/// <param name="sql">要添加参数的sql</param>
		public SqlParameterWrapperCollection ToSqlParameters(string sql)
		{
			SqlParameterWrapperCollection collection = new SqlParameterWrapperCollection();
			List<string> sqlHaveParameters =SqlAid.GetSqlParametersList(sql);
			if (sqlHaveParameters.Contains("ID")) collection.Add(new SqlParameterWrapper("@ID", ID));
			if (sqlHaveParameters.Contains("UserCode")) collection.Add(new SqlParameterWrapper("@UserCode", UserCode));
			if (sqlHaveParameters.Contains("RealName")) collection.Add(new SqlParameterWrapper("@RealName", RealName));
			if (sqlHaveParameters.Contains("UserPwd")) collection.Add(new SqlParameterWrapper("@UserPwd", UserPwd));
			if (sqlHaveParameters.Contains("Sex")) collection.Add(new SqlParameterWrapper("@Sex", Sex));
			if (sqlHaveParameters.Contains("Age")) collection.Add(new SqlParameterWrapper("@Age", Age));
			if (sqlHaveParameters.Contains("Phone")) collection.Add(new SqlParameterWrapper("@Phone", Phone));
			if (sqlHaveParameters.Contains("QQ")) collection.Add(new SqlParameterWrapper("@QQ", QQ));
			if (sqlHaveParameters.Contains("Email")) collection.Add(new SqlParameterWrapper("@Email", Email));
			if (sqlHaveParameters.Contains("Address")) collection.Add(new SqlParameterWrapper("@Address", Address));
			if (sqlHaveParameters.Contains("EntryDate")) collection.Add(new SqlParameterWrapper("@EntryDate", EntryDate));
			if (sqlHaveParameters.Contains("PositionCode")) collection.Add(new SqlParameterWrapper("@PositionCode", PositionCode));
			if (sqlHaveParameters.Contains("DepartmentCode")) collection.Add(new SqlParameterWrapper("@DepartmentCode", DepartmentCode));
			if (sqlHaveParameters.Contains("CreateTime")) collection.Add(new SqlParameterWrapper("@CreateTime", CreateTime));
			if (sqlHaveParameters.Contains("CreateUserCode")) collection.Add(new SqlParameterWrapper("@CreateUserCode", CreateUserCode));
			if (sqlHaveParameters.Contains("ModifyTime")) collection.Add(new SqlParameterWrapper("@ModifyTime", ModifyTime));
			if (sqlHaveParameters.Contains("ModifyUserCode")) collection.Add(new SqlParameterWrapper("@ModifyUserCode", ModifyUserCode));
			if (sqlHaveParameters.Contains("Addtion1")) collection.Add(new SqlParameterWrapper("@Addtion1", Addtion1));
			if (sqlHaveParameters.Contains("Addtion2")) collection.Add(new SqlParameterWrapper("@Addtion2", Addtion2));
			return collection;
		}
		///<summary>IDataRecord填充实体,返回自己</summary>
		///<param name="dataRecord">IDataRecord数据</param>
		///<param name="colName">列名的列次序，可调用GetColNameIndex获得</param>
		public User BuildEntity(IDataRecord dataRecord,Dictionary<string,int> colName)
		{
			if (colName.ContainsKey("ID"))ID =dataRecord.GetInt32(colName["ID"]);
			if (colName.ContainsKey("UserCode"))UserCode =dataRecord.GetString(colName["UserCode"]);
			if (colName.ContainsKey("RealName"))RealName =dataRecord.GetString(colName["RealName"]);
			if (colName.ContainsKey("UserPwd"))UserPwd =dataRecord.GetString(colName["UserPwd"]);
			if (colName.ContainsKey("Sex"))Sex =dataRecord.GetString(colName["Sex"]);
			if (colName.ContainsKey("Age"))Age =dataRecord.GetInt32(colName["Age"]);
			if (colName.ContainsKey("Phone"))Phone =dataRecord.GetString(colName["Phone"]);
			if (colName.ContainsKey("QQ")&&!dataRecord.IsDBNull(colName["QQ"]))QQ = dataRecord.GetString(colName["QQ"]);
			if (colName.ContainsKey("Email"))Email =dataRecord.GetString(colName["Email"]);
			if (colName.ContainsKey("Address")&&!dataRecord.IsDBNull(colName["Address"]))Address = dataRecord.GetString(colName["Address"]);
			if (colName.ContainsKey("EntryDate"))EntryDate =dataRecord.GetDateTime(colName["EntryDate"]);
			if (colName.ContainsKey("PositionCode"))PositionCode =dataRecord.GetString(colName["PositionCode"]);
			if (colName.ContainsKey("DepartmentCode"))DepartmentCode =dataRecord.GetString(colName["DepartmentCode"]);
			if (colName.ContainsKey("CreateTime")&&!dataRecord.IsDBNull(colName["CreateTime"]))CreateTime = dataRecord.GetDateTime(colName["CreateTime"]);
			if (colName.ContainsKey("CreateUserCode")&&!dataRecord.IsDBNull(colName["CreateUserCode"]))CreateUserCode = dataRecord.GetString(colName["CreateUserCode"]);
			if (colName.ContainsKey("ModifyTime")&&!dataRecord.IsDBNull(colName["ModifyTime"]))ModifyTime = dataRecord.GetDateTime(colName["ModifyTime"]);
			if (colName.ContainsKey("ModifyUserCode")&&!dataRecord.IsDBNull(colName["ModifyUserCode"]))ModifyUserCode = dataRecord.GetString(colName["ModifyUserCode"]);
			if (colName.ContainsKey("Addtion1")&&!dataRecord.IsDBNull(colName["Addtion1"]))Addtion1 = dataRecord.GetString(colName["Addtion1"]);
			if (colName.ContainsKey("Addtion2")&&!dataRecord.IsDBNull(colName["Addtion2"]))Addtion2 = dataRecord.GetString(colName["Addtion2"]);
			return this;
		}
		///<summary>DataRow填充实体,返回自己</summary>
		///<param name="dr">DataRow数据</param>
		///<param name="colName">列名的列次序，可调用GetColNameIndex获得</param>
		public User BuildEntity(DataRow dr, Dictionary<string, int> colName)
		{
			if (colName.ContainsKey("ID"))ID =(Int32)dr[colName["ID"]];
			if (colName.ContainsKey("UserCode"))UserCode =(String)dr[colName["UserCode"]];
			if (colName.ContainsKey("RealName"))RealName =(String)dr[colName["RealName"]];
			if (colName.ContainsKey("UserPwd"))UserPwd =(String)dr[colName["UserPwd"]];
			if (colName.ContainsKey("Sex"))Sex =(String)dr[colName["Sex"]];
			if (colName.ContainsKey("Age"))Age =(Int32)dr[colName["Age"]];
			if (colName.ContainsKey("Phone"))Phone =(String)dr[colName["Phone"]];
			if (colName.ContainsKey("QQ")&&!dr.IsNull(colName["QQ"]))QQ =  (string)dr[colName["QQ"]];
			if (colName.ContainsKey("Email"))Email =(String)dr[colName["Email"]];
			if (colName.ContainsKey("Address")&&!dr.IsNull(colName["Address"]))Address =  (string)dr[colName["Address"]];
			if (colName.ContainsKey("EntryDate"))EntryDate =(DateTime)dr[colName["EntryDate"]];
			if (colName.ContainsKey("PositionCode"))PositionCode =(String)dr[colName["PositionCode"]];
			if (colName.ContainsKey("DepartmentCode"))DepartmentCode =(String)dr[colName["DepartmentCode"]];
			if (colName.ContainsKey("CreateTime")&&!dr.IsNull(colName["CreateTime"]))CreateTime =  (DateTime)dr[colName["CreateTime"]];
			if (colName.ContainsKey("CreateUserCode")&&!dr.IsNull(colName["CreateUserCode"]))CreateUserCode =  (string)dr[colName["CreateUserCode"]];
			if (colName.ContainsKey("ModifyTime")&&!dr.IsNull(colName["ModifyTime"]))ModifyTime =  (DateTime)dr[colName["ModifyTime"]];
			if (colName.ContainsKey("ModifyUserCode")&&!dr.IsNull(colName["ModifyUserCode"]))ModifyUserCode =  (string)dr[colName["ModifyUserCode"]];
			if (colName.ContainsKey("Addtion1")&&!dr.IsNull(colName["Addtion1"]))Addtion1 =  (string)dr[colName["Addtion1"]];
			if (colName.ContainsKey("Addtion2")&&!dr.IsNull(colName["Addtion2"]))Addtion2 =  (string)dr[colName["Addtion2"]];
			return this;
		}
		///<summary>返回对象Josn字串</summary>
		public string ToJosn()
		{
			return "{\"TableName\":\"User\""
				+",\"ID\":\""+ID+"\""
				+",\"UserCode\":\""+UserCode+"\""
				+",\"RealName\":\""+RealName+"\""
				+",\"UserPwd\":\""+UserPwd+"\""
				+",\"Sex\":\""+Sex+"\""
				+",\"Age\":\""+Age+"\""
				+",\"Phone\":\""+Phone+"\""
				+",\"QQ\":\""+QQ+"\""
				+",\"Email\":\""+Email+"\""
				+",\"Address\":\""+Address+"\""
				+",\"EntryDate\":\""+EntryDate+"\""
				+",\"PositionCode\":\""+PositionCode+"\""
				+",\"DepartmentCode\":\""+DepartmentCode+"\""
				+",\"CreateTime\":\""+CreateTime+"\""
				+",\"CreateUserCode\":\""+CreateUserCode+"\""
				+",\"ModifyTime\":\""+ModifyTime+"\""
				+",\"ModifyUserCode\":\""+ModifyUserCode+"\""
				+",\"Addtion1\":\""+Addtion1+"\""
				+",\"Addtion2\":\""+Addtion2+"\""
				+"}";
		}
	}
}


