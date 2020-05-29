using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace community.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Dataset> Dataset { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<Mlmodel> Mlmodel { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Reply> Reply { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySql("server=localhost;user id=root;password=3103Diaozuida;database=mlab", x => x.ServerVersion("8.0.18-mysql"));
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("COMMENT");

                entity.HasIndex(e => e.PostId)
                    .HasName("fk_COMMENT");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_COMMENT_1");

                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("varchar(1023)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("fk_COMMENT");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fk_COMMENT_1");
            });

            modelBuilder.Entity<Dataset>(entity =>
            {
                entity.ToTable("DATASET");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_DATASET");

                entity.Property(e => e.DatasetId)
                    .HasColumnName("dataset_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatasetName)
                    .HasColumnName("dataset_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Format)
                    .HasColumnName("format")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Dataset)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fk_DATASET");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasKey(e => e.TrainId)
                    .HasName("PRIMARY");

                entity.ToTable("HISTORY");

                entity.HasIndex(e => e.ModelId)
                    .HasName("fk_HISTORY_2");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_HISTORY");

                entity.Property(e => e.TrainId)
                    .HasColumnName("train_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModelId)
                    .HasColumnName("model_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("fk_HISTORY_2");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fk_HISTORY");
            });

            modelBuilder.Entity<Likes>(entity =>
            {
                entity.HasKey(e => e.LikeId)
                    .HasName("PRIMARY");

                entity.ToTable("LIKES");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_LIKE");

                entity.Property(e => e.LikeId)
                    .HasColumnName("like_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(1)");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fk_LIKE");
            });

            modelBuilder.Entity<Mlmodel>(entity =>
            {
                entity.HasKey(e => e.ModelId)
                    .HasName("PRIMARY");

                entity.ToTable("MLMODEL");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_MODEL");

                entity.Property(e => e.ModelId)
                    .HasColumnName("model_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Detail)
                    .HasColumnName("detail")
                    .HasColumnType("blob");

                entity.Property(e => e.ModelName)
                    .HasColumnName("model_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Mlmodel)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fk_MODEL");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("POST");

                entity.HasIndex(e => e.ModelId)
                    .HasName("fk_POST_1");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_POST");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CommentNum)
                    .HasColumnName("comment_num")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("varchar(1023)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.LikeNum)
                    .HasColumnName("like_num")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModelId)
                    .HasColumnName("model_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReplyNum)
                    .HasColumnName("reply_num")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("fk_POST_1");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fk_POST");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("REPLY");

                entity.HasIndex(e => e.CommentId)
                    .HasName("fk_REPLY_1");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_REPLY");

                entity.Property(e => e.ReplyId)
                    .HasColumnName("reply_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("varchar(1023)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Reply)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("fk_REPLY_1");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Reply)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fk_REPLY");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PRIMARY");

                entity.ToTable("USER");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
