using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace testConsole
{
    public class JsonMovie
    {
        [Description("电影名字")]
        [JsonProperty("movieName",Order = 4)]
        public string Name { get; set; }

        [Description("导演")]
        [JsonProperty(Order = 0)]
        public string Director { get; set; }

        [Description("发行年份")]
        public string ReleaseYear { get; set; }

        [Description("男猪脚")]
        [JsonProperty(Order = -3)]
        public string ChiefActor { get; set; }

        [Description("女猪脚")]
        [JsonProperty(Order = 2)]
        public string ChiefActress { get; set; }
    }
}
