namespace CinemaWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedMovieAnnotaions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
        }
    }
}
