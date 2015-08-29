namespace EmployeeCRUD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Occupation { get; set; }

        public int? Salary { get; set; }

        [StringLength(50)]
        public string City { get; set; }
    }
}
