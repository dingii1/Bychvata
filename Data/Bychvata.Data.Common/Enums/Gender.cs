namespace Bychvata.Data.Common.Enums
{
    using System.Runtime.Serialization;

    public enum Gender
    {
        [EnumMember(Value = "Мъж")]
        Male = 1,

        [EnumMember(Value = "Жена")]
        Female = 2,

        [EnumMember(Value = "Друго")]
        Other = 3,
    }
}