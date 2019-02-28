namespace BootcampAngular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCountryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Players", "Countries_Id", c => c.Int());
            CreateIndex("dbo.Players", "Countries_Id");
            AddForeignKey("dbo.Players", "Countries_Id", "dbo.Countries", "Id");
            DropColumn("dbo.Players", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Country", c => c.String());
            DropForeignKey("dbo.Players", "Countries_Id", "dbo.Countries");
            DropIndex("dbo.Players", new[] { "Countries_Id" });
            DropColumn("dbo.Players", "Countries_Id");
            DropTable("dbo.Countries");
        }
    }
}
