using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace testConsole
{
    public static class DescriptionHelper
    {
        /// <summary>
        /// 根据特性说明设置属性值
        /// </summary>
        public static string SetPropertyByDescription()
        {
            var ent = new JsonMovie();
            foreach (var item in ent.GetType().GetProperties())
            {
                var v = (DescriptionAttribute[])item.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var descriptionName = v[0].Description;

                item.SetValue(ent, descriptionName);
            }
            return JsonConvert.SerializeObject(ent);
        }

        /// <summary>
        /// 获取枚举值上的Description特性的说明
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="obj">枚举值</param>
        /// <returns>特性的说明</returns>
        public static string GetEnumDescription<T>(T obj)
        {
            var type = obj.GetType();
            //var name = Enum.GetName(type, obj);
            FieldInfo field = type.GetField(obj.ToString());
            
            DescriptionAttribute descAttr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (descAttr == null)
            {
                return string.Empty;
            }

            return descAttr.Description;
        }
    }
}
