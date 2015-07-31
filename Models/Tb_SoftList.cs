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
        public int  SoftID { get; set; }
        public string SoftName { get; set; }
        public string SoftIntro { get; set; }
        public string SoftType { get; set; }
        public string Contest { get; set; }
        public string DownLink { get; set; }
    }
}