using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpanceMvc.Models
{
    public class category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public category()
        {
            this.expances = new HashSet<expance>();
        }
        [DisplayName("Category Id")]
        public int catid { get; set; }
        [Required(ErrorMessage = "Please Enter Category Name"), DisplayName("Category Name")]
       
        public string catname { get; set; }
        [Required(ErrorMessage = "Please Enter Categroy Expance Limit"), DisplayName("Category Expance Limite")]
        public int catexplim { get; set; }
        public virtual ICollection<expance> expances { get; set; }

    }

   
}