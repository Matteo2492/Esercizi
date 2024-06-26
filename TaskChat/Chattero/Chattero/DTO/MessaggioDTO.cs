﻿using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Chattero.DTO
{
    public class MessaggioDTO
    {

        [StringLength(250)]
        public string? NomUte { get; set; }
        [StringLength(500)]
        public string? Con { get; set; }
        public string? Sta { get; set; }
        public DateTime Ora { get; set; }
        public byte[]? ImmagineData { get; set; }
    }
}
