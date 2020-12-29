namespace Bychvata.Common.Extensions
{
    using System;

    public static class EnumExtension
    {
        public static string GetName<T>(this Enum enumVal)
            where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ?
                ((System.Runtime.Serialization.EnumMemberAttribute)attributes[0]).Value :
                enumVal.ToString();
        }
    }
}