﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TT_WebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ToolTrackerEntities : DbContext
    {
        public ToolTrackerEntities()
            : base("name=ToolTrackerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Borrower> Borrowers { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanTool> LoanTools { get; set; }
        public virtual DbSet<Tool> Tools { get; set; }
        public virtual DbSet<Workspace> Workspaces { get; set; }
    }
}
