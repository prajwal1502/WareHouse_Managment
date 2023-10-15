
using System;
using System.ComponentModel.DataAnnotations;

namespace InvManagement1.models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
