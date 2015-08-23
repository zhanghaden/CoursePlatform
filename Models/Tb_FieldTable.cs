namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tb_FieldTable
    {
        [Key]
        public int FieldID { get; set; }
        [Display(Name = "字段名称")]
        public string FieldName { get; set; }
        [Required]
        [Display(Name = "字段显示名称")]
        public string DisplayName { get; set; }
        [Display(Name = "是否使用")]
        public Nullable<int> IsUse { get; set; }
    }
}