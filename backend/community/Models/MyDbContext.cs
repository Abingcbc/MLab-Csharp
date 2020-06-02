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
        public virtual DbSet<Container> Container { get; set; }
        public virtual DbSet<Dataset> Dataset { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<Mlmodel> Mlmodel { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Reply> Reply { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=3103Diaozuida;database=mlab", x => x.ServerVersion("5.7.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.HasIndex(e => e.PostId)
                    .HasName("fk_COMMENT");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_COMMENT_1");

                entity.Property(e => e.CommentId)
                    .HasColumnName("commentId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("varchar(1023)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.PostId)
                    .HasColumnName("postId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("fk_COMMENT");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fk_COMMENT_1");
            });

            modelBuilder.Entity<Container>(entity =>
            {
                entity.ToTable("container");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_Container");

                entity.Property(e => e.ContainerId)
                    .HasColumnName("containerId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvalidTime)
                    .HasColumnName("invalidTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Container)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fk_Container");
            });

            modelBuilder.Entity<Dataset>(entity =>
            {
                entity.ToTable("dataset");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_DATASET");

                entity.Property(e => e.DatasetId)
                    .HasColumnName("datasetId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatasetName)
                    .HasColumnName("datasetName")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Format)
                    .HasColumnName("format")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Dataset)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fk_DATASET");
            });

            modelBuilder.Entity<Likes>(entity =>
            {
                entity.HasKey(e => e.LikeId)
                    .HasName("PRIMARY");

                entity.ToTable("likes");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_LIKE");

                entity.Property(e => e.LikeId)
                    .HasColumnName("likeId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(1)");

                entity.Property(e => e.TypeId)
                    .HasColumnName("typeId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fk_LIKE");
            });

            modelBuilder.Entity<Mlmodel>(entity =>
            {
                entity.HasKey(e => e.ModelId)
                    .HasName("PRIMARY");

                entity.ToTable("mlmodel");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_MODEL");

                entity.Property(e => e.ModelId)
                    .HasColumnName("modelId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ModelName)
                    .HasColumnName("modelName")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Mlmodel)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fk_MODEL");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.HasIndex(e => e.ModelId)
                    .HasName("fk_POST_1");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_POST");

                entity.Property(e => e.PostId)
                    .HasColumnName("postId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CommentNum)
                    .HasColumnName("commentNum")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("varchar(1023)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.LikeNum)
                    .HasColumnName("likeNum")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModelId)
                    .HasColumnName("modelId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReplyNum)
                    .HasColumnName("replyNum")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

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
                entity.ToTable("reply");

                entity.HasIndex(e => e.CommentId)
                    .HasName("fk_REPLY_1");

                entity.HasIndex(e => e.Username)
                    .HasName("fk_REPLY");

                entity.Property(e => e.ReplyId)
                    .HasColumnName("replyId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CommentId)
                    .HasColumnName("commentId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("varchar(1023)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

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

                entity.ToTable("user");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
