using System.Runtime.Serialization;

namespace Bychvata.Data.Common.Enums
{
    public enum AdditionType
    {
        [EnumMember(Value = "Такса домашен любимец")]
        PetTax = 1,

        [EnumMember(Value = "Избор на бунгало")]
        BungalowSelection = 2,

        [EnumMember(Value = "Допълнително легло")]
        AdditionalBed = 3,

        [EnumMember(Value = "Пералня")]
        WashingMachine = 4,

        [EnumMember(Value = "Палатка /двуместна/")]
        TwoPersonTent = 5,

        [EnumMember(Value = "Плажен чадър")]
        BeachUmbrella = 6,

        [EnumMember(Value = "Хавлия за баня")]
        Towel = 7,

        [EnumMember(Value = "Допълнителен комплект бельо")]
        AdditionalSheets = 8,
    }
}