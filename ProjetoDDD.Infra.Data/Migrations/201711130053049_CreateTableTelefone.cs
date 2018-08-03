namespace ProjetoDDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableTelefone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        TelefoneId = c.Int(nullable: false, identity: true),
                        Ddd = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TelefoneId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefone", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Telefone", new[] { "ClienteId" });
            DropTable("dbo.Telefone");
        }
    }
}
