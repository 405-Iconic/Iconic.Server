using Iconic.Domain.Entities.Quizes;
using Iconic.Domain.Entitites.Courses;
using Iconic.Domain.Entitites.Discussions;
using Iconic.Domain.Entitites.Forums;
using Iconic.Domain.Entitites.News;
using Iconic.Domain.Entitites.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Submission> Submissions { get; set; }
        public virtual DbSet<LessonTask> Tasks { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<ForumAnswer> ForumAnswers { get; set; }
        public virtual DbSet<ForumQuestion> ForumQuestions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<QuizResult> QuizResults { get; set; }
        public virtual DbSet<SolvedQuestion> SolvedQuestions { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<New> News { get; set; }
        public virtual DbSet<Gallery> Galleries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique(true);
        }

    }
}
