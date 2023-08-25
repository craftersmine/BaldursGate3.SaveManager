using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace craftersmine.BaldursGate3.SaveManager.Core
{
    public class PartyMemberCharacter
    {
        [JsonPropertyName("Classes")]
        public CharacterClass[] Classes { get; init; }
        [JsonPropertyName("Experience Points (Current level)")]
        public int CurrentLevelExperience { get; init; }
        [JsonPropertyName("Experience Points (Total)")]
        public int TotalExperience { get; init; }
        [JsonPropertyName("Level")]
        public int Level { get; init; }
        [JsonPropertyName("Origin")]
        public string Origin { get; init; }
        [JsonPropertyName("Race")]
        public string Race { get; init; }
        [JsonPropertyName("Subregion")]
        public string Subregion { get; init; }

    }

    public class CharacterClass
    {
        [JsonPropertyName("Main")]
        public string MainClass { get; init; }
        [JsonPropertyName("Sub")]
        public string SubClass { get; init; }
    }
}
