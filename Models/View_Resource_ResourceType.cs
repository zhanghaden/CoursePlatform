namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class View_Resource_ResourceType
    {
        [Key]
        public int ResourceID { get; set; }
        public string ResourceName { get; set; }
        public int ResourceTypeID { get; set; }
        public string ResourcePath { get; set; }
        public bool IsConvertFinish { get; set; }
        public string PDFPath { get; set; }
        public string swfPath { get; set; }
        public Nullable<System.Guid> UpUserID { get; set; }
        public string UserType { get; set; }
        public System.DateTime RecordTime { get; set; }
        public string ResourceType { get; set; }
        public bool ResourceIsDisplay { get; set; }
    }
}