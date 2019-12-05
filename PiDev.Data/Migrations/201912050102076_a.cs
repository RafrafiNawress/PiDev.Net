namespace PiDev.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "pidev.bill",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.claims",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        claimdate = c.DateTime(precision: 0),
                        subject = c.String(unicode: false),
                        message = c.String(unicode: false),
                        type = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.commentaire",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.compentency",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.employeecompentency",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.employee",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            birthday = c.DateTime(precision: 0),
            //            email = c.String(maxLength: 255, unicode: false),
            //            firstname = c.String(maxLength: 255, unicode: false),
            //            isActif = c.Boolean(storeType: "bit"),
            //            lastname = c.String(maxLength: 255, unicode: false),
            //            password = c.String(maxLength: 255, unicode: false),
            //            phone = c.Int(nullable: false),
            //            photo = c.String(maxLength: 255, unicode: false),
            //            role = c.String(maxLength: 255, unicode: false),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.team",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.evaluationsheet",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.followedup",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.holiday",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.jobcompetency",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.jobfamily",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.job",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.missionrequest",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.mission",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.notification",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.planifiedtraining",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.planing",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.project",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.reclamation",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.request",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.task",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.trainingcentre",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.training",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "pidev.team_employee",
            //    c => new
            //        {
            //            Employees_id = c.Int(nullable: false),
            //            Teams_id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.Employees_id, t.Teams_id })
            //    .ForeignKey("pidev.employee", t => t.Employees_id, cascadeDelete: true)
            //    .ForeignKey("pidev.team", t => t.Teams_id, cascadeDelete: true)
            //    .Index(t => t.Employees_id)
            //    .Index(t => t.Teams_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("pidev.team_employee", "Teams_id", "pidev.team");
            DropForeignKey("pidev.team_employee", "Employees_id", "pidev.employee");
            DropIndex("pidev.team_employee", new[] { "Teams_id" });
            DropIndex("pidev.team_employee", new[] { "Employees_id" });
            DropTable("pidev.team_employee");
            DropTable("pidev.training");
            DropTable("pidev.trainingcentre");
            DropTable("pidev.task");
            DropTable("pidev.request");
            DropTable("pidev.reclamation");
            DropTable("pidev.project");
            DropTable("pidev.planing");
            DropTable("pidev.planifiedtraining");
            DropTable("pidev.notification");
            DropTable("pidev.mission");
            DropTable("pidev.missionrequest");
            DropTable("pidev.job");
            DropTable("pidev.jobfamily");
            DropTable("pidev.jobcompetency");
            DropTable("pidev.holiday");
            DropTable("pidev.followedup");
            DropTable("pidev.evaluationsheet");
            DropTable("pidev.team");
            DropTable("pidev.employee");
            DropTable("pidev.employeecompentency");
            DropTable("pidev.compentency");
            DropTable("pidev.commentaire");
            DropTable("dbo.claims");
            DropTable("pidev.bill");
        }
    }
}
