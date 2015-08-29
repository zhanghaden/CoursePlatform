namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tb_Resource
    {
        [Key]
        public int ResourceID { get; set; }
        public string ResourceName { get; set; }
        public Nullable<int> ResourceTypeID { get; set; }
        public string ResourcePath { get; set; }
        public bool IsConvertFinish { get; set; }
        public string PDFPath { get; set; }
        public string swfPath { get; set; }
        public System.Guid UpUserID { get; set; }
        public string UserType { get; set; }
        public System.DateTime RecordTime { get; set; }
    }
}