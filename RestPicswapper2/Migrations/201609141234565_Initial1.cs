namespace RestPicswapper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Linkis", "Uzytkownik_Id", "dbo.Uzytkowniks");
            DropIndex("dbo.Linkis", new[] { "Uzytkownik_Id" });
            DropColumn("dbo.Linkis", "Uzytkownik_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Linkis", "Uzytkownik_Id", c => c.Int());
            CreateIndex("dbo.Linkis", "Uzytkownik_Id");
            AddForeignKey("dbo.Linkis", "Uzytkownik_Id", "dbo.Uzytkowniks", "Id");
        }
    }
}
