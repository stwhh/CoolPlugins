using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Web.Mvc;

namespace CoolPlugins.Public.Tools
{
    public class EnumItem
    {
        public string ItemText { get; set; }
        public string ItemValue { get; set; }
        public string ItemDes { get; set; }
        public const string ItemValueField = "ItemValue";
        public const string ItemTextField = "ItemText";
        public const string ItemDesField = "ItemDes";
    }

    /// <summary>
    /// 枚举的扩展@孙涛
    /// </summary>
    public static class EnumExt
    {
        private static readonly ConcurrentDictionary<Type, Dictionary<string, EnumItem>> EnumAbout
            = new ConcurrentDictionary<Type, Dictionary<string, EnumItem>>();

        /// <summary>
        /// 根据枚举值获取枚举备注
        /// </summary>
        public static string GetDes(this Enum value)
        {
            if (value == null) return "";
            FieldInfo field = value.GetType().GetField(value.ToString());
            return ((DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))).Description;
        }

        /// <summary>
        /// 根据多个枚举值获取枚举备注
        /// </summary>
        public static string GetDes(this Enum value, string eunmValue)
        {
            Dictionary<string, EnumItem> eItem = value.GetItemList();
            string desStr = "";
            foreach (var item in eunmValue.Split(','))
            {
                desStr += "," + (eItem.ContainsKey(item) ? eItem[item].ItemDes : "");
            }
            return desStr.TrimStart(',');
        }

        /// <summary>
        /// 根据特定的枚举值名称获得枚举值的Description特性的值
        /// </summary>
        /// <param name="value">枚举类型</param>
        /// <param name="name">枚举值的名称</param>
        /// <returns>返回查找到的Description特性的值，如果没有，就返回.ToString()</returns>
        public static string GetDesByName(System.Type value, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                FieldInfo fi = value.GetField(name);
                DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : name;
            }
            return "";
        }

        /// <summary>得到备注,圆角显示</summary>
        public static MvcHtmlString GetDesCorner(this Enum value, string eunmValue)
        {
            Dictionary<string, EnumItem> eItem = value.GetItemList();
            string desStr = "";
            foreach (var item in eunmValue.Split(','))
            {
                desStr += (eItem.ContainsKey(item) ? "<span class='Corner " + value.GetType().Name + item + "'>"
                    + eItem[item].ItemDes + "</span>" : "");
            }
            return new MvcHtmlString(desStr);
        }

        /// <summary>
        /// 根据枚举或者枚举值列表
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Dictionary<string, EnumItem> GetItemList(this Enum value)
        {
            Type eType = value.GetType();
            if (!EnumAbout.ContainsKey(eType))
            {
                Type valueType = Enum.GetUnderlyingType(eType);
                var enums = Enum.GetValues(eType);
                Dictionary<string, EnumItem> tmpList = new Dictionary<string, EnumItem>();
                foreach (Enum e in enums)
                    tmpList.Add(Convert.ChangeType(e, valueType).ToString(), new EnumItem
                    {
                        ItemText = e.ToString(),
                        ItemValue = Convert.ChangeType(e, valueType).ToString(),
                        ItemDes = e.GetDes()
                    });
                EnumAbout.TryAdd(eType, tmpList);
            }
            return EnumAbout[eType];
        }

      

        #region 根据备注信息获取枚举值
        /// <summary>
        /// 根据备注信息获取枚举值
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        public static Enum GetEnumByDesc(System.Type enumType, string enumValue)
        {
            Enum result = null;
            foreach (object enumObject in Enum.GetValues(enumType))
            {
                Enum e = (Enum)enumObject;
                if (GetDes(e) == enumValue)
                {
                    result = e;
                    break;
                }
            }
            return result;
        }
        #endregion

        #region 根据枚举值得到枚举
        /// <summary>
        /// 根据枚举值得到枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strEnum"></param>
        /// <returns></returns>
        public static T ToEnum<T>(int strEnum)
        {
            return (T)Enum.Parse(typeof(T), strEnum.ToString());
        }

        public static T ToEnum<T>(string strEnum)
        {
            return (T)Enum.Parse(typeof(T), strEnum);
        }
        #endregion

        #region 根据枚举和备注信息得到枚举的Value值
        /// <summary>
        /// 根据枚举和备注信息得到枚举的Value值
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static int GetEnumValueByDesc(System.Type enumType, string description)
        {
            DataTable dt = GetEnumTable(enumType);
            int txtenumValue = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Text"].ToString() == description)
                {
                    txtenumValue = Convert.ToInt32(dt.Rows[i]["Value"].ToString());
                }
            }
            return txtenumValue;
        }
        #endregion

        #region 将含有描述信息的枚举组装datatable
        /// <summary>
        /// 将含有描述信息的枚举组装datatable(Table两个字段，text是描述，value是值(默认是int的值))
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static DataTable GetEnumTable(System.Type enumType)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            foreach (object enumValue in Enum.GetValues(enumType))
            {
                dr = dt.NewRow();
                Enum e = (Enum)enumValue;
                dr["Text"] = GetDes(e);
                dr["Value"] = Convert.ToInt32(enumValue).ToString();
                dt.Rows.Add(dr);

            }
            return dt;
        }
        #endregion

        #region 获取枚举的值字符串信息，根据传入的枚举值
        /// <summary>
        /// 获取枚举的值字符串信息，根据传入的枚举值
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static int GetEnumInt(Enum e)
        {
            return Convert.ToInt32(e);

        }
        #endregion

    }
}
