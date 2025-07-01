using System;
using System.Collections.Generic;

namespace Project.Data.MenuData
{
    [Serializable]
    public class PlayerProgressData
    {
        public HashSet<string> CompletedStages { get; set; }
    }
}

