﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            this.EmployeesTasks = new HashSet<EmployeeTask>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(3), MaxLength(40), Required, RegularExpression(@"^[A-Za-z0-9]+$")]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, RegularExpression(@"^\(?([0-9]{3})\)?[-. ]([0-9]{3})[-. ]([0-9]{4})$")]
        public string Phone { get; set; }


        public ICollection<EmployeeTask> EmployeesTasks { get; set; }
    }

}