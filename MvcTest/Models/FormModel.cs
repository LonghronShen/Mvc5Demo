using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTest.Models
{

    public class FormModel
    {

        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Description = "Name")]
        public string Name { get; set; }

        public byte[] FileContent { get; set; }

    }

}