namespace RaceTrackMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp6 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.VehicleTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehicleTypeId = c.Int(nullable: false, identity: true),
                        VehicleTypeName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleTypeId);
            
        }
    }
}
