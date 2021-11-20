namespace ShopBrige_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationToInventoryItems : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InventoryItems", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InventoryItems", "Name", c => c.String());
        }
    }
}
