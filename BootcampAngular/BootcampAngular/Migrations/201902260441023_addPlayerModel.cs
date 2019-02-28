namespace BootcampAngular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPlayerModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Club = c.String(),
                        Country = c.String(),
                        Age = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Players");
        }
    }
}
