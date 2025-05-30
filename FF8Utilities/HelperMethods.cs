using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using CarawayCode.Entities;
using FF8Utilities.Models;

namespace FF8Utilities
{
    public static class HelperMethods
    {
        /// <summary>
        /// Converts PoleModels into PoleCount entities for interacting with CarawayCode project
        /// </summary>
        public static PoleCount[] ConvertTo(List<PoleModel> poles)
        {
            return poles.Where(p => p.Count != null).Select(p => new PoleCount(p.Count.Value)).ToArray();
        }

        /// <summary>
        /// Gets the description if the enum has a description attribute, otherwise returns the enum.
        /// </summary>
        public static string GetDescription(this Enum enumeration)
        {
            return ((DescriptionAttribute)GetAttribute(enumeration, typeof(DescriptionAttribute)))?.Description ?? enumeration.ToString();
        }

        public static object GetAttribute(Enum enumeration, Type attributeType)
        {
            Type type = enumeration.GetType();

            MemberInfo[] memInfo = type.GetMember(enumeration.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(attributeType, false);

                if (attrs != null && attrs.Length > 0)

                    return attrs[0];

            }

            return null;
        }
    }
}
