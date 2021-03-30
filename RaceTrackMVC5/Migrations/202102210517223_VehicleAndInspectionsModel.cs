namespace RaceTrackMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleAndInspectionsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarInspections",
                c => new
                    {
                        CarInspectionId = c.Int(nullable: false, identity: true),
                        AcceptableTireWear = c.Int(nullable: false),
                        HasTowStrap = c.Boolean(nullable: false),
                        vehicles_VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.CarInspectionId)
                .ForeignKey("dbo.Vehicles", t => t.vehicles_VehicleId)
                .Index(t => t.vehicles_VehicleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        VehicleName = c.String(nullable: false),
                        VehicleType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId);
            
            CreateTable(
                "dbo.TruckInspections",
                c => new
                    {
                        TruckInspectionId = c.Int(nullable: false, identity: true),
                        AcceptableLift = c.Int(nullable: false),
                        HasTowStrap = c.Boolean(nullable: false),
                        vehicles_VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.TruckInspectionId)
                .ForeignKey("dbo.Vehicles", t => t.vehicles_VehicleId)
                .Index(t => t.vehicles_VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TruckInspections", "vehicles_VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.CarInspections", "vehicles_VehicleId", "dbo.Vehicles");
            DropIndex("dbo.TruckInspections", new[] { "vehicles_VehicleId" });
            DropIndex("dbo.CarInspections", new[] { "vehicles_VehicleId" });
            DropTable("dbo.TruckInspections");
            DropTable("dbo.Vehicles");
            DropTable("dbo.CarInspections");
        }
    }
}
