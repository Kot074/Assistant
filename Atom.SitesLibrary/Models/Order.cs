using System;
using System.ComponentModel.DataAnnotations;

namespace Atom.VectorSiteLibrary.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        [Key]
        public DateTime Date { get; set; }
        [Required]
        public string Label { get; set; }
    }
}
