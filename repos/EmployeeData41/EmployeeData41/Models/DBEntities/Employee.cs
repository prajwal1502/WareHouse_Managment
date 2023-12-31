﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeData.Models.DBEntities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }
        [Column(TypeName = "varchar[50]")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar[50]")]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "varchar[50]")]
        public int Salary { get; set; }
    }
}
