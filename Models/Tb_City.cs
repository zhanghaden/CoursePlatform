namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tb_City
    {
        [Key]
        public double CityID { get; set; }
        public string CityName { get; set; }
        public Nullable<double> ParentID { get; set; }
        public Nullable<double> CityLevel { get; set; }
        public string Upid { get; set; }
        public string ParentPath { get; set; }
        public string Note { get; set; }
        public Nullable<double> Area { get; set; }
    }
}