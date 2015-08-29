namespace EmployeeCRUD
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeesModel : DbContext
    {
        public EmployeesModel()
            : base("data source=.;initial catalog=EmployeesDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;")
        {
        }

        //name=EmployeesModel
        //data source=.;initial catalog=EmployeesDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Occupation)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.City)
                .IsUnicode(false);
        }
    }
}
