namespace OTS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        exam_ID = c.Int(),
                        question_ID = c.Int(),
                        selectedAnswer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exam", t => t.exam_ID)
                .ForeignKey("dbo.Question", t => t.question_ID)
                .ForeignKey("dbo.Answer", t => t.selectedAnswer_ID)
                .Index(t => t.exam_ID)
                .Index(t => t.question_ID)
                .Index(t => t.selectedAnswer_ID);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        accessId = c.String(),
                        isTaken = c.Boolean(nullable: false),
                        grade = c.String(),
                        dateTaken = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        user_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.user_ID)
                .Index(t => t.user_ID);
            
            CreateTable(
                "dbo.SubInventory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        inventory_ID = c.Int(),
                        Exam_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inventory", t => t.inventory_ID)
                .ForeignKey("dbo.Exam", t => t.Exam_ID)
                .Index(t => t.inventory_ID)
                .Index(t => t.Exam_ID);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        description = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        userName = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        question = c.String(),
                        numberOfAnswers = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        subInventory_ID = c.Int(),
                        ExamQuestion_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubInventory", t => t.subInventory_ID)
                .ForeignKey("dbo.ExamQuestion", t => t.ExamQuestion_ID)
                .Index(t => t.subInventory_ID)
                .Index(t => t.ExamQuestion_ID);
            
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        answer = c.String(),
                        isCorrect = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        question_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Question", t => t.question_ID)
                .Index(t => t.question_ID);
            
            CreateTable(
                "dbo.ExamQuestion",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        exam_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exam", t => t.exam_ID)
                .Index(t => t.exam_ID);
            
            CreateTable(
                "dbo.GradingCriteria",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        minVal = c.Int(nullable: false),
                        maxVal = c.Int(nullable: false),
                        grade = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        examTime = c.Int(nullable: false),
                        maxQuestionsInSubInventories = c.Int(nullable: false),
                        minSubInventories = c.Int(nullable: false),
                        maxSubInventories = c.Int(nullable: false),
                        randomLength = c.Int(nullable: false),
                        questionGrades = c.Int(nullable: false),
                        validTimeAccess = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "ExamQuestion_ID", "dbo.ExamQuestion");
            DropForeignKey("dbo.ExamQuestion", "exam_ID", "dbo.Exam");
            DropForeignKey("dbo.ExamLog", "selectedAnswer_ID", "dbo.Answer");
            DropForeignKey("dbo.Answer", "question_ID", "dbo.Question");
            DropForeignKey("dbo.ExamLog", "question_ID", "dbo.Question");
            DropForeignKey("dbo.Question", "subInventory_ID", "dbo.SubInventory");
            DropForeignKey("dbo.ExamLog", "exam_ID", "dbo.Exam");
            DropForeignKey("dbo.Exam", "user_ID", "dbo.User");
            DropForeignKey("dbo.SubInventory", "Exam_ID", "dbo.Exam");
            DropForeignKey("dbo.SubInventory", "inventory_ID", "dbo.Inventory");
            DropIndex("dbo.ExamQuestion", new[] { "exam_ID" });
            DropIndex("dbo.Answer", new[] { "question_ID" });
            DropIndex("dbo.Question", new[] { "ExamQuestion_ID" });
            DropIndex("dbo.Question", new[] { "subInventory_ID" });
            DropIndex("dbo.SubInventory", new[] { "Exam_ID" });
            DropIndex("dbo.SubInventory", new[] { "inventory_ID" });
            DropIndex("dbo.Exam", new[] { "user_ID" });
            DropIndex("dbo.ExamLog", new[] { "selectedAnswer_ID" });
            DropIndex("dbo.ExamLog", new[] { "question_ID" });
            DropIndex("dbo.ExamLog", new[] { "exam_ID" });
            DropTable("dbo.Setting");
            DropTable("dbo.GradingCriteria");
            DropTable("dbo.ExamQuestion");
            DropTable("dbo.Answer");
            DropTable("dbo.Question");
            DropTable("dbo.User");
            DropTable("dbo.Inventory");
            DropTable("dbo.SubInventory");
            DropTable("dbo.Exam");
            DropTable("dbo.ExamLog");
        }
    }
}
