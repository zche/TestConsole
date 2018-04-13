using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace testConsole
{
    public class JsonMovie
    {
        [JsonProperty(Order = 4)]
        public string Name { get; set; }

        [JsonProperty(Order = 0)]
        public string Director { get; set; }

        public int ReleaseYear { get; set; }

        [JsonProperty(Order = -3)]
        public string ChiefActor { get; set; }

        [JsonProperty(Order = 2)]
        public string ChiefActress { get; set; }
    }
}
