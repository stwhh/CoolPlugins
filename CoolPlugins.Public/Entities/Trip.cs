
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
    public class Trip : ITableBase<Trip>
    {
		public string TableName="Trip"; //表名
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
        /// 
        /// </summary>        
        public string TripCode { get; set; }
        
         
		/// <summary>
        /// 出差内容，描述
        /// </summary>        
        public string TripContent { get; set; }
        
         
		/// <summary>
        /// 申请日期
        /// </summary>        
        public DateTime ApplyDate { get; set; }
        
         
		/// <summary>
        /// 出差开始日期
        /// </summary>        
        public DateTime BeginDate { get; set; }
        
         
		/// <summary>
        /// 出差结束日期
        /// </summary>        
        public DateTime EndDate { get; set; }
        
         
		/// <summary>
        /// 
        /// </summary>        
        public string Destination { get; set; }
        
         
		/// <summary>
        /// 出差申请状态：待审批，审批通过，审批不通过
        /// </summary>        
        public string Status { get; set; }
        
         
		/// <summary>
        /// 
        /// </summary>        
        public string UserCode { get; set; }
        
         
		/// <summary>
        /// 是否申请报销
        /// </summary>        
        public string IsReim { get; set; }
        
         
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

