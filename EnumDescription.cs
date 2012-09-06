using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace weather
{
    /// <summary>
    /// Extension class
    /// </summary>
    public static class EnumDescriptionAttribute
    {
        /// <summary>
        /// Enum extension method to get description specified by EnumDescription attribute
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum e)
        {
            Type type = e.GetType();
            MemberInfo[] memInfo = type.GetMember(e.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] att = memInfo[0].GetCustomAttributes(typeof(EnumDescription), false);
                if (att != null && att.Length > 0)
                    return ((EnumDescription)att[0]).Text;
            }

            return e.ToString();
        }
    }

    /// <summary>
    /// EnumDescription is an attribute class for the enums that allows to attach description to enum value
    /// </summary>
    public class EnumDescription : Attribute
    {
        /// <summary>
        /// Description
        /// </summary>
        public string Text;

        /// <summary>
        /// EnumDescription constructor
        /// </summary>
        /// <param name="text">Enum item description</param>
        public EnumDescription(string text)
        {
            Text = text;
        }
    }

}
