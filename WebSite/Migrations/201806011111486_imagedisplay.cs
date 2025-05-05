namespace WebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagedisplay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImagePosts", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImagePosts", "ImageUrl");
        }
    }
}
