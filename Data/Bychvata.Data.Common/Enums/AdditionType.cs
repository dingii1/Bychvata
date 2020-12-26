using System.Runtime.Serialization;

namespace Bychvata.Data.Common.Enums
{
    public enum AdditionType
    {
        [EnumMember(Value = "Такса домашен любимец")]
        PetTax = 1,

        [EnumMember(Value = "Пералня")]
        WashingMachine = 2,

        [EnumMember(Value = "Палатка /двуместна/")]
        TwoPersonTent = 3,

        [EnumMember(Value = "Плажен чадър")]
        BeachUmbrella = 4,

        [EnumMember(Value = "Хавлия за баня")]
        Towel = 5,

        [EnumMember(Value = "Допълнителен комплект бельо")]
        AdditionalSheets = 6,
    }
}