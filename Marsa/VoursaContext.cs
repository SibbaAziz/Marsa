using Marsa.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Marsa
{
    public class VoursaContext : DbContext
    {
        public VoursaContext() : base("AnnonceContext")
        {

        }
        public virtual DbSet<Annonce> Annonces { get; set; }
    }
}