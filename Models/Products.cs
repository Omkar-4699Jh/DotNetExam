using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetExam.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Product Name")]
        public string ProductName { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please Enter Rate")]
        public int Rate { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Write Some Description about product")]
        [StringLength(250, ErrorMessage = "The {0} many Characters of Description you entered it exceeds the limit{1} characters" )]
        public string Description { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please Enter Category Name")]
        public string CategoryName { get; set; }
    }
}