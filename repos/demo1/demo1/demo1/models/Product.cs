﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvManagement1.models
{
    public class Product
    {
        [Key] // Specifies this property as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specifies that the value is generated by the database
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        }

}



