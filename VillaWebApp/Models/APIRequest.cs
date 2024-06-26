﻿using static Villa_Utilities.SD;

namespace VillaWebApp.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public Object Data { get; set; }
        public string Token { get; set; }
    }
}
