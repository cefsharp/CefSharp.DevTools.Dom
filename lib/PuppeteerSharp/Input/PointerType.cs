﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CefSharp.Dom.Input
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum PointerType
    {
        [EnumMember(Value = "mouse")]
        Mouse,
        [EnumMember(Value = "pen")]
        Pen,
    }
}
