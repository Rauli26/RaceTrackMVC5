namespace RaceTrackMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarInspections", "vehicles_VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.TruckInspections", "vehicles_VehicleId", "dbo.Vehicles");
            DropIndex("dbo.CarInspections", new[] { "vehicles_VehicleId" });
            DropIndex("dbo.TruckInspections", new[] { "vehicles_VehicleId" });
            RenameColumn(table: "dbo.CarInspections", name: "vehicles_VehicleId", newName: "VehicleId");
            RenameColumn(table: "dbo.TruckInspections", name: "vehicles_VehicleId", newName: "VehicleId");
            AlterColumn("dbo.CarInspections", "VehicleId", c => c.Int(nullable: false));
            AlterColumn("dbo.TruckInspections", "VehicleId", c => c.Int(nullable: false));
            CreateIndex("dbo.CarInspections", "VehicleId");
            CreateIndex("dbo.TruckInspections", "VehicleId");
            AddForeignKey("dbo.CarInspections", "VehicleId", "dbo.Vehicles", "VehicleId", cascadeDelete: true);
            AddForeignKey("dbo.TruckInspections", "VehicleId", "dbo.Vehicles", "VehicleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TruckInspections", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.CarInspections", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.TruckInspections", new[] { "VehicleId" });
            DropIndex("dbo.CarInspections", new[] { "VehicleId" });
            AlterColumn("dbo.TruckInspections", "VehicleId", c => c.Int());
            AlterColumn("dbo.CarInspections", "VehicleId", c => c.Int());
            RenameColumn(table: "dbo.TruckInspections", name: "VehicleId", newName: "vehicles_VehicleId");
            RenameColumn(table: "dbo.CarInspections", name: "VehicleId", newName: "vehicles_VehicleId");
            CreateIndex("dbo.TruckInspections", "vehicles_VehicleId");
            CreateIndex("dbo.CarInspections", "vehicles_VehicleId");
            AddForeignKey("dbo.TruckInspections", "vehicles_VehicleId", "dbo.Vehicles", "VehicleId");
            AddForeignKey("dbo.CarInspections", "vehicles_VehicleId", "dbo.Vehicles", "VehicleId");
        }
    }
}
