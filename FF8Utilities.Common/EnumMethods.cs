using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace FF8Utilities.Common
{
    public static class EnumMethods
    {
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

    public class EnumerationMember : BaseModel
    {
        public string Description { get; set; }
        public object Value { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected == value)
                    return;
                _isSelected = value;
                OnPropertyChanged();
            }
        }
    }
}
