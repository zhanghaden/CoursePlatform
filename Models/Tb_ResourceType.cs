namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tb_ResourceType
    {
        [Key]
        public int ResourceTypeID { get; set; }
        public string ResourceType { get; set; }
        public bool ResourceIsDisplay { get; set; }
    }
}