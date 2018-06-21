using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.Models
{
    public class ImagePost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        //[NotMapped]
        //public HttpPostedFileBase Image { get; set; }
        public string ImageUrl { get; set; }
    }
}