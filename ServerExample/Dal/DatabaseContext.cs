using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace ServerExample.Dal
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }


        public DatabaseContext() : base("name=DatabaseContext")
        {
        }
    }

    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
