﻿using Newtonsoft.Json;

namespace CustomActivity.Model
{
    public class TemperatureModel
    {
        [JsonProperty("day")]
        public float Day { get; set; }

        [JsonProperty("min")]
        public float Min { get; set; }

        [JsonProperty("max")]
        public float Max { get; set; }

        [JsonProperty("night")]
        public float Night { get; set; }

        [JsonProperty("eve")]
        public float Evening { get; set; }

        [JsonProperty("morn")]
        public float Morning { get; set; }
    }
}
