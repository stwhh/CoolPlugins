using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolPlugins.Public
{
    public class SqlNote
    {
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// sql注释
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 用于的项目
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// 重载函数
        /// </summary>
        /// <param name="author">作者</param>
        /// <param name="note">sql备注</param>
        /// <param name="project">用于的项目</param>
        /// <returns>sql注释</returns>
        public SqlNote(string author, string note, string project = "炫酷插件网")
        {
            this.Author = author;
            this.Note = note;
            this.Project = project;
        }

        /// <summary>
        /// 添加sql注释
        /// </summary>
        /// <returns>sql注释</returns>
        public string AddSqlNote()
        {
            return "/*项目:" + Project + ";作者:" + Author + ";备注:" + Note + "*/\r\n";
        }

    }
}
