﻿namespace BeGood.Core.Models.Entities
{
    public class User : BaseEntity
    {
        public int? ID { get; set; } = null;
        public string Phone { get; set; } = null;
        public string Name { get; set; } = null;
    }
}
