using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.BaldursGate3.SaveManager.Core
{
    public class SaveInformation
    {
        public string Name { get; private set; }
        public string Platform { get; private set; }
        public Version GameVersion { get; private set; }
        public string[] Difficulty { get; private set; }
        public string CurrentLevel { get; private set; }
        public SaveActiveParty ActiveParty { get; private set; }
    }

    public class SaveActiveParty
    {
        public PartyMemberCharacter[] Characters { get; private set; }
    }
}
