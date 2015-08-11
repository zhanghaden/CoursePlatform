namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tb_FieldTable
    {
        [Key]
        public int FieldID { get; set; }
        public string FieldName { get; set; }
        public string DisplayName { get; set; }
        public Nullable<int> IsUse { get; set; }
    }
}