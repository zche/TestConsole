using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace testConsole
{
    public class EnumHelper
    {

        /// <summary>
        /// 枚举类型转换为字符串
        /// </summary>
        /// <param name="direc"></param>
        /// <returns></returns>
        public string EnumConvertToString(Direction direc)
        {
            //方法一
            return direc.ToString();

            ////方法二
            //return Enum.GetName(direc.GetType(), direc);

        }
        /// <summary>
        /// 枚举类型转换为数字
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private int EnumConvertToInt(Direction color)
        {
            return (int)color;
        }
        /// <summary>
        /// 字符串转换为枚举类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private Direction StringConvertToEnum(string str)
        {
            Direction color = Direction.DOWN;

            color = (Direction)Enum.Parse(typeof(Direction), str);


            return color;
        }
        /// <summary>
        /// 数字转换为枚举类型
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private Direction IntConvertToEnumOther(int i)
        {
            return (Direction)i;
        }
    }

    public enum Direction
    {
        [Description("上")]
        UP = 1,
        [Description("右")]
        RIGHT = 2,
        [Description("下")]
        DOWN = 3,
        [Description("左")]
        LEFT = 4,
    }
}
