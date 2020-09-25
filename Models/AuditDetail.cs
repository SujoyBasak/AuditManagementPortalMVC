using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalMVC.Models
{
    public class AuditDetail
    {
        [Required]
        [Display(Name ="Type(Internal/SOX)")]
        public string Type { get; set; }        //Change
        [Required]        
        public DateTime Date { get; set; }
        public Questions questions { get; set; }


        //public enum AuditType
        //{
        //    "Internal",
        //    "SOX"
        //};
    }
}
