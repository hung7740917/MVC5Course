namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using ValidationAttribute;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }
    
    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        [DisplayName("產品名稱")]
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        [NoAAAString]
        public string ProductName { get; set; }

        [Required]
        [Range(1, 9999999999, ErrorMessage = "{0}輸入錯誤")]
        [DisplayFormat(DataFormatString = "NT$ {0:N0}")]
        public Nullable<decimal> Price { get; set; }

        [Required]
        public Nullable<bool> Active { get; set; }

        [Required]
        [Range(0,99999)]
        public Nullable<decimal> Stock { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
