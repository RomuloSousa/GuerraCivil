using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GuerraCivil.Models;

namespace GuerraCivil.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Personagem> Personagens { get; set; }
        
    }
}
