using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssickFinalProject5.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            :base(options)
        { }

        public DbSet<Post> Posts { get; set; } 
        public DbSet<Main> MainComments { get; set; }
        public DbSet<Response2Reponse> Response2Reponses { get; set; }
        
    }
}
