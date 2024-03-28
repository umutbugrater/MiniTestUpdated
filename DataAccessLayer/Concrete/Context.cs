using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JCPO54A\\SQLEXPRESS; database=MiniTestDB; integrated security=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<Question>()
                .HasMany(x => x.QuestionOptions)
                .WithOne(x => x.Question)
                .HasForeignKey(x => x.Question_ID)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<AnswerLine>()
                .HasOne(x => x.Question)
                .WithMany(x => x.AnswerLines)
                .HasForeignKey(x => x.Question_ID)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Question>()
                .HasOne(x => x.QuestionType)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.QuestionTypeID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AnswerLine>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.AnswerLines)
                .HasForeignKey(x => x.AppUserID)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerLine> AnswerLines { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }

    }
}
