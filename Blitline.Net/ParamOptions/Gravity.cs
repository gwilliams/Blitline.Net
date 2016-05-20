using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

﻿namespace Blitline.Net.ParamOptions
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gravity
    {
        NorthGravity,
        NorthWestGravity,
        NorthEastGravity,
        SouthGravity,
        SouthWestGravity,
        SouthEastGravity,
        CenterGrativty
    }
}
