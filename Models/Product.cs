//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KisanMitraWebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Carts = new HashSet<Cart>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int productId { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public int qty { get; set; }
        public double volume { get; set; }
        public string brand { get; set; }
        public Nullable<int> userId { get; set; }
        public int prodSubCatId { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string col1 { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
        public string col4 { get; set; }
        public Nullable<double> col5 { get; set; }
        public Nullable<double> col6 { get; set; }
        public Nullable<int> col7 { get; set; }
        public Nullable<int> col8 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ProductSubCategory ProductSubCategory { get; set; }
        public virtual User User { get; set; }
    }
}
