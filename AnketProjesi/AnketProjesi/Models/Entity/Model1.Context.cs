//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnketProjesi.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AnketProjesiDBEntities : DbContext
    {
        public AnketProjesiDBEntities()
            : base("name=AnketProjesiDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ANKT_Anketler> ANKT_Anketler { get; set; }
        public virtual DbSet<ANKT_Calisanlar> ANKT_Calisanlar { get; set; }
        public virtual DbSet<ANKT_Cevaplar> ANKT_Cevaplar { get; set; }
        public virtual DbSet<ANKT_Secenekler> ANKT_Secenekler { get; set; }
        public virtual DbSet<ANKT_Sorular> ANKT_Sorular { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
