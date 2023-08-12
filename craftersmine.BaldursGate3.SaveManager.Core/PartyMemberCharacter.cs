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
        public CharacterClass[] Classes { get; private set; }
        public int CurrentLevelExperience { get; private set; }
        public int TotalExperience { get; private set; }
        public int Level { get; private set; }
        public string Origin { get; private set; }
        // TODO: convert array to vector
        public Vector3 Position { get; private set; }
        public string Race { get; private set; }
        public string SubRegion { get; private set; }

    }

    public class CharacterClass
    {
        [JsonPropertyName("Main")]
        public string MainClass { get; private set; }
        [JsonPropertyName("Sub")]
        public string SubClass { get; private set; }
    }
}
