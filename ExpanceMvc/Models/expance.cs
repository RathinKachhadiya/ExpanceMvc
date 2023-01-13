using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpanceMvc.Models
{
    public class expance
    {
        [DisplayName("Id")]
        public int expid { get; set; }
        [Required(ErrorMessage = "Please Enter Expance Title"),DisplayName("Title")]
        public string exptitle { get; set; }
        [Required(ErrorMessage = "Please Enter Expance Description"),DisplayName("Description")]
        public string expdescription { get; set; }
        [Required(ErrorMessage = "Please Enter Expance Category"),DisplayName("Description")]
        public string expcategory { get; set; }
        [Required(ErrorMessage = "Please Enter Expance Amount"), DisplayName("Amount")]
        public int expamount { get; set; }
        [Required(ErrorMessage = "Please Enter Category Id"), DisplayName("Category Id")]
        public int catid { get; set; }
       
        private DateTimeOffset dt = DateTimeOffset.Now;
        [Required(ErrorMessage = "Please Enter Date Time"), DisplayName("Date Time Added")]
        public DateTimeOffset expdatetime { get { return dt; } set { dt = value; } }

        public virtual category category { get; set; }
    }
}