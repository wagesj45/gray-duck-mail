using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.IO;
using System.Reflection;

namespace EasyMailDiscussion.Common.Database
{
    /// <summary>
    /// The SQLite database is defined and managed by this class. This uses
    /// <see cref="https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application">Entity
    /// Framework Code First</see> method for defining a database and uses
    /// <see cref="https://sqlite.org/index.html">SQLite</see> to store data in a local database file,
    /// without the need for any external database system.
    /// </summary>
    /// <seealso cref="DbContext"/>
    /// <seealso cref="DbSet{TEntity}"/>
    public class SqliteDatabase : DbContext
    {
        #region Members

        /// <summary> The logging conduit. </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Properties

        /// <summary> Gets or sets the full pathname of the database file. </summary>
        /// <value> The database fileath. </value>
        public Uri DatabaseFilePath { get; private set; }

        /// <summary> Gets or sets the <see cref="DiscussionList"/> table. </summary>
        /// <value> The <see cref="DiscussionList"/> table. </value>
        public DbSet<DiscussionList> DiscussionLists { get; set; }

        /// <summary> Gets or sets the <see cref="Contact"/> table. </summary>
        /// <value> The <see cref="Contact"/> table. </value>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary> Gets or sets the <see cref="ContactSubscription"/> table. </summary>
        /// <value> The <see cref="ContactSubscription"/> table. </value>
        public DbSet<ContactSubscription> ContactSubscriptions {get; set;}

        /// <summary> Gets or sets the <see cref="Message"/> table. </summary>
        /// <value> The <see cref="Message"/> table. </value>
        public DbSet<Message> Messages { get; set; }

        /// <summary> Gets or sets the <see cref="RelayIdentifier"/> table. </summary>
        /// <value> The <see cref="RelayIdentifier"/> table. </value>
        public DbSet<RelayIdentifier> RelayIdentifiers { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that prevents a default instance of this class from being created.
        /// </summary>
        /// <remarks>
        /// This constructor is only used internally in the <see cref="EnsureDatabaseFile(Uri)"/> method.
        /// </remarks>
        private SqliteDatabase()
        {
            //
        }

        /// <summary> Constructor. </summary>
        /// <param name="databaseFilePath"> Full pathname of the database file. </param>
        public SqliteDatabase(string databaseFilePath)
        {
            this.DatabaseFilePath = new Uri(databaseFilePath);
            EnsureDatabaseFile(this.DatabaseFilePath);
        }

        #endregion

        #region Methods

        /// <summary> Ensures that the database file exists and is initialized. </summary>
        /// <exception cref="FileNotFoundException">
        ///     Thrown when the requested file is not present.
        /// </exception>
        /// <param name="databaseFilePath"> Full pathname of the database file. </param>
        private void EnsureDatabaseFile(Uri databaseFilePath)
        {
            if (!File.Exists(this.DatabaseFilePath.AbsolutePath))
            {
                logger.Debug("Creating db file at {0}.", databaseFilePath.AbsolutePath);
                using (var _db = new SqliteDatabase())
                {
                    _db.DatabaseFilePath = databaseFilePath;
                    _db.Database.EnsureCreated();
                    _db.SaveChanges();
                }
                if (File.Exists(databaseFilePath.AbsolutePath))
                {
                    logger.Info("Database file created at {0}.", databaseFilePath.AbsolutePath);
                }
                else
                {
                    logger.Error("Could not create database file at {0}.", databaseFilePath.AbsolutePath);
                    throw new FileNotFoundException("Could not create database file.", databaseFilePath.AbsolutePath);
                }
            }
        }

        #endregion

        #region Overrides

        /// <summary> Executing when configuring the model. </summary>
        /// <param name="optionsBuilder">
        ///     A builder used to create or modify options for this context. Databases (and other
        ///     extensions)
        ///     typically define extension methods on this object that allow you to configure the context.
        /// </param>
        /// <seealso cref="DbContext.OnConfiguring(DbContextOptionsBuilder)"/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databaseFileNameFormat = string.Format("Filename={0}", this.DatabaseFilePath.AbsolutePath);
            optionsBuilder.UseSqlite(databaseFileNameFormat, options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary> Executed when creating the model. </summary>
        /// <param name="modelBuilder">
        ///     The builder being used to construct the model for this context. Databases (and other
        ///     extensions) typically define extension methods on this object that allow you to configure
        ///     aspects of the model that are specific to a given database.
        /// </param>
        /// <seealso cref="DbContext.OnModelCreating(ModelBuilder)"/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Describe the Contacts table.
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasIndex(e => e.Email)
                .IsUnique();
                entity.HasMany(e => e.ContactSubscriptions)
                .WithOne(e => e.Contact)
                .HasForeignKey(e => e.ContactID);
            });

            //Describe the Contact Subscriptions table.
            modelBuilder.Entity<ContactSubscription>().ToTable("ContactSubscription");
            modelBuilder.Entity<ContactSubscription>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasOne(e => e.Contact)
                .WithMany(e => e.ContactSubscriptions)
                .HasForeignKey(e => e.ContactID)
                .IsRequired();
                entity.HasOne(e => e.DiscussionList)
                .WithMany(e => e.Subscriptions)
                .HasForeignKey(e => e.DiscussionListID)
                .IsRequired();
            });

            //Describe the DiscussionList table.
            modelBuilder.Entity<DiscussionList>().ToTable("DiscussionList");
            modelBuilder.Entity<DiscussionList>(entity => 
            {
                entity.HasKey(e => e.ID);
                entity.HasMany(e => e.Subscriptions)
                .WithOne(e => e.DiscussionList)
                .HasForeignKey(e => e.DiscussionListID);
                entity.HasMany(e => e.Messages)
                .WithOne(e => e.DiscussionList)
                .HasForeignKey(e => e.DiscussionListID);
            });

            //Describe the Messages table.
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasOne(e => e.Parent)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentID)
                .IsRequired(false);
                entity.HasOne(e => e.OriginatorContact)
                .WithMany(e => e.Messages)
                .HasForeignKey(e => e.OriginatorContactID);
                entity.HasOne(e => e.DiscussionList)
                .WithMany(e => e.Messages)
                .HasForeignKey(e => e.DiscussionListID);
            });

            //Describe the RelayIdentifier table.
            modelBuilder.Entity<RelayIdentifier>().ToTable("RelayIdentifier");
            modelBuilder.Entity<RelayIdentifier>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasOne(e => e.Message)
                .WithMany(e => e.RelayIdentifiers)
                .HasForeignKey(e => e.MessageID);
                entity.HasIndex(e => e.RelayEmailID)
                .IsUnique(true);
            });

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
