namespace RestPicswapper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Linkis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adres = c.String(),
                        folder = c.Boolean(nullable: false),
                        Uzytkownik_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uzytkowniks", t => t.Uzytkownik_Id)
                .Index(t => t.Uzytkownik_Id);
            
            CreateTable(
                "dbo.Uzytkowniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        imie = c.String(),
                        nazwisko = c.String(),
                        mail = c.String(),
                        haslo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Linkis", "Uzytkownik_Id", "dbo.Uzytkowniks");
            DropIndex("dbo.Linkis", new[] { "Uzytkownik_Id" });
            DropTable("dbo.Uzytkowniks");
            DropTable("dbo.Linkis");
        }
    }
}
