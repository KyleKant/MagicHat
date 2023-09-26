using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

[Serializable]
public class GameData
{
    [JsonConverter(typeof(StringEnumConverter))]
    public GameState State { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public GameLevel Level { get; set; }
}
