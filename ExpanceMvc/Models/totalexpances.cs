using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpanceMvc.Models
{
    public class totalexpances
    {
        [DisplayName("Total Expance Id")]
        public int totexpid { get; set; }
       
        [Required,DisplayName("Total Expance")]
        public int totexp { get; set; }
    }
}