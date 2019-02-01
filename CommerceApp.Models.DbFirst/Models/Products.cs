using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceApp.Models.DbFirst.Models
{
    [Table("Product")]
    public partial class Products
    {
        [Key]
        public int PKID { get; set; }
        [Column("ProductName",TypeName ="varchar(20)")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public string ImageUrl { get; set; }
        public int CID { get; set; }
        [ForeignKey("CID")]
        public Categories Category { get; set; }

        public int ProductAttributeId { get; set; }
        [ForeignKey("ProductAttributeId")]
        public ProductAttributes ProductAtrribute { get; set; }

        public List<ProductStock> Stores { get; set; }
             
    }
}
