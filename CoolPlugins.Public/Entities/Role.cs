
//-------------------------------------------------------------------
// <auto-generated>
// 此代码由T4模板自动生成
// 生成时间 2016-04-10 21:30:42 by stwhh
// 对此文件的更改可能会导致不正确的行为，如果
// 重新生成代码，这些更改将会丢失。
// </auto-generated>
//-------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CoolPlugins.Public.Entities
{    
    public class Role : ITableBase<Role>
    {
		public string TableName="Role"; //表名
		/// <summary>
        /// 获取表名
        /// </summary>     
		public string GetTableName()
		{
			return TableName ;
		}
        
         
		public string PrimaryKey="ID"; //主键
		/// <summary>
        /// 获取主键
        /// </summary>     
		public string GetPrimaryKey()
		{
			return PrimaryKey ;
		} 
		/// <summary>
        /// 
        /// </summary>        
        public int ID { get; set; }
        
         
		/// <summary>
        /// 角色组编号
        /// </summary>        
        public string RoleCode { get; set; }
        
         
		/// <summary>
        /// 角色组名称
        /// </summary>        
        public string RoleName { get; set; }
        
         
		/// <summary>
        /// 角色组描述
        /// </summary>        
        public string RoleContent { get; set; }
        
         
		/// <summary>
        /// 创建时间
        /// </summary>        
        public DateTime? CreateTime { get; set; }
        
         
		/// <summary>
        /// 创建者编号
        /// </summary>        
        public string CreateUserCode { get; set; }
        
         
		/// <summary>
        /// 修改时间
        /// </summary>        
        public DateTime? ModifyTime { get; set; }
        
         
		/// <summary>
        /// 修改者编号
        /// </summary>        
        public string ModifyUserCode { get; set; }
        
         
		/// <summary>
        /// 预留1
        /// </summary>        
        public string Addtion1 { get; set; }
        
         
		/// <summary>
        /// 预留2
        /// </summary>        
        public string Addtion2 { get; set; }
         
    }
}

