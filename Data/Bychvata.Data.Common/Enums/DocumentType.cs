namespace Bychvata.Data.Common.Enums
{
    using System.Runtime.Serialization;

    public enum DocumentType
    {
        [EnumMember(Value = "Лична карта")]
        IdCard = 1,

        [EnumMember(Value = "Паспорт")]
        Passport = 2,

        [EnumMember(Value = "Шофьорска книжка")]
        DrivingLicense = 3,
    }
}