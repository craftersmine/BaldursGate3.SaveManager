using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace craftersmine.BaldursGate3.SaveManager.Core
{
    public class SaveInformation
    {
        [JsonPropertyName("Save Name")]
        public string Name { get; init; }
        [JsonPropertyName("Platform")]
        public string Platform { get; init; }
        [JsonPropertyName("Game Version")]
        public Version GameVersion { get; init; }
        [JsonPropertyName("Difficulty")]
        public string[] Difficulty { get; init; }
        [JsonPropertyName("Current Level")]
        public string CurrentLevel { get; init; }
        [JsonPropertyName("Active Party")]
        public SaveActiveParty ActiveParty { get; init; }
    }

    public class SaveActiveParty
    {
        [JsonPropertyName("Characters")]
        public PartyMemberCharacter[] Characters { get; init; }
    }
}
