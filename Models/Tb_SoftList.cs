namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;

    public class Tb_SoftList
    {
        [Key]
        [Display(Name = "软件ID")]
        public int  SoftID { get; set; }
        [Display(Name = "软件名称")]
        public string SoftName { get; set; }
        [Display(Name = "软件简介")]
        [StringLength(10)]
        public string SoftIntro { get; set; }
        [Display(Name = "软件类型")]
        public string SoftType { get; set; }
        [Display(Name = "大赛")]
        public string Contest { get; set; }
        [Display(Name = "下载链接")]
        public string DownLink { get; set; }
    }
}