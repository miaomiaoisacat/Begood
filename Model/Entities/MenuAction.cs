﻿namespace Model.Entities
{
    public class MenuAction
    {
        public int? ID { get; set; } = null;
        public int? MenuID { get; set; } = null;
        public string Name { get; set; } = null;
        public string Code { get; set; } = null;
        public string Path { get; set; } = null;
    }
}