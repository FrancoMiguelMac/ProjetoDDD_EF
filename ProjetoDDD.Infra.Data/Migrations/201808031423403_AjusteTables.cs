namespace ProjetoDDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Telefone", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Telefone", new[] { "ClienteId" });
            AddColumn("dbo.Cliente", "Cpf", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Cliente", "Nome", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Produto", "Nome", c => c.String(nullable: false, maxLength: 100, unicode: false));
            DropColumn("dbo.Cliente", "Sobrenome");
            DropColumn("dbo.Cliente", "Email");
            DropColumn("dbo.Cliente", "Ativo");
            DropColumn("dbo.Produto", "Disponivel");
            DropTable("dbo.Telefone");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.TelefoneId);
            
            AddColumn("dbo.Produto", "Disponivel", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cliente", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cliente", "Email", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddColumn("dbo.Cliente", "Sobrenome", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AlterColumn("dbo.Produto", "Nome", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Cliente", "Nome", c => c.String(nullable: false, maxLength: 150, unicode: false));
            DropColumn("dbo.Cliente", "Cpf");
            CreateIndex("dbo.Telefone", "ClienteId");
            AddForeignKey("dbo.Telefone", "ClienteId", "dbo.Cliente", "ClienteId");
        }
    }
}
