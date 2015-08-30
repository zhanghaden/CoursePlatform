namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tb_ManageUser
    {
        [Key]
        public System.Guid ManageUserID { get; set; }
        public string DeName { get; set; }
        public Nullable<int> Age { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public Nullable<int> CityID { get; set; }
        public string DetailAddress { get; set; }
        public System.DateTime RecordTime { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IDCard { get; set; }
        public string CompanyName { get; set; }
        public string PostCode { get; set; }
        public int UserType { get; set; }
        public Nullable<int> ProvinceID { get; set; }
    }
}