﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Condai.DAL.Modelo
{
    using Condai.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Condai.Entity.Contacto;
    
    public partial class CondaiContacto : DbContext
    {
        public CondaiContacto()
            : base("name=CondaiContacto")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Contacto_Inquietud> Contacto_Inquietud { get; set; }
    }
}
