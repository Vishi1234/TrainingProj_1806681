namespace MoviesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMoviesModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "DirectorName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DirectorName", c => c.String());
        }
    }
}
