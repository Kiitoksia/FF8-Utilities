using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;

namespace FF8Utilities.Extensions
{
    public class EnumExtension : MarkupExtension
    {
        private Type _enumType;


        public EnumExtension(Type enumType)
        {
            if (enumType == null) throw new ArgumentNullException(nameof(enumType));

            EnumType = enumType;
        }

        public Type EnumType
        {
            get { return _enumType; }
            private set
            {
                if (_enumType == value)
                    return;

                var enumType = Nullable.GetUnderlyingType(value) ?? value;

                if (enumType.IsEnum == false)
                    throw new ArgumentException("Type must be an Enum.");

                _enumType = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var enumValues = Enum.GetValues(EnumType);
            return enumValues.Cast<object>().Select(t => new EnumerationMember { Value = t, Description = ((Enum)t).GetDescription()});
        }

        public class EnumerationMember
        {
            public string Description { get; set; }
            public object Value { get; set; }
        }        
    }
}
