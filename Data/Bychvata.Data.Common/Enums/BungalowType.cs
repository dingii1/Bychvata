namespace Bychvata.Data.Common.Enums
{
    using System.Runtime.Serialization;

    public enum BungalowType
    {
        [EnumMember(Value = "Студио")]
        Studio = 1,

        [EnumMember(Value = "Гледка към парка")]
        ParkView = 2,

        [EnumMember(Value = "Две стаи")]
        TwoRooms = 3,

        [EnumMember(Value = "Морска гледка")]
        SeaView = 4,
    }
}