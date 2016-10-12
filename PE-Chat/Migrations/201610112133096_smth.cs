namespace PE_Chat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smth : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Messages", new[] { "Author_Id" });
            AlterColumn("dbo.Messages", "Author_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Messages", "Author_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Messages", new[] { "Author_Id" });
            AlterColumn("dbo.Messages", "Author_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "Author_Id");
        }
    }
}
