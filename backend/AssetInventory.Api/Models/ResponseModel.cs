using System;

namespace AssetInventory.Api.Models
{
    public class ResponseModel
    {
        public bool status { get; set; }
        public string? message { get; set; }
        public int? id { get; set; }
    }

}