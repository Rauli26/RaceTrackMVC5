namespace RaceTrackMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp4 : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.VehicleTypes");
        }
    }
}
