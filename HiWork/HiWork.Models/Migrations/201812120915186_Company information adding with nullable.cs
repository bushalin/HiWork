namespace HiWork.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Companyinformationaddingwithnullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderDetails", "ProductInfoId", "dbo.ProductInfo");
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CountryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EMail = c.String(),
                        Password = c.String(),
                        CompanyName = c.String(),
                        Designation = c.String(),
                        ContactPersonName = c.String(),
                        ContactPersonPhone = c.String(),
                        PostalCode = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        AddressLine3 = c.String(),
                        Website = c.String(),
                        RepresentativeName = c.String(),
                        BusinessContent = c.String(),
                        CompanyIntro = c.String(),
                        ForeginersRecrDes = c.String(),
                        DOE = c.DateTime(nullable: false),
                        Capital = c.Double(nullable: false),
                        NoOfEmployees = c.Int(nullable: false),
                        ForeginersRecrExperience = c.Boolean(nullable: false),
                        ForeginersRecrQty = c.Int(nullable: false),
                        DepartmentId = c.Int(),
                        CurrencyId = c.Int(),
                        IndustryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.CurrencyId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Industry", t => t.IndustryId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CurrencyId)
                .Index(t => t.IndustryId);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrencyName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Industry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndustryName = c.String(),
                        IndCatId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndustryCategory", t => t.IndCatId)
                .Index(t => t.IndCatId);
            
            CreateTable(
                "dbo.IndustryCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndCatName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyCities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(),
                        CityId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .Index(t => t.CompanyId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.CompanyIndustries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(),
                        IndustryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .ForeignKey("dbo.Industry", t => t.IndustryId)
                .Index(t => t.CompanyId)
                .Index(t => t.IndustryId);
            
            AddForeignKey("dbo.Order", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Order", "Id");
            AddForeignKey("dbo.OrderDetails", "ProductInfoId", "dbo.ProductInfo", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductInfoId", "dbo.ProductInfo");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropForeignKey("dbo.CompanyIndustries", "IndustryId", "dbo.Industry");
            DropForeignKey("dbo.CompanyIndustries", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.CompanyCities", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.CompanyCities", "CityId", "dbo.City");
            DropForeignKey("dbo.Company", "IndustryId", "dbo.Industry");
            DropForeignKey("dbo.Industry", "IndCatId", "dbo.IndustryCategory");
            DropForeignKey("dbo.Company", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Company", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.City", "CountryId", "dbo.Country");
            DropIndex("dbo.CompanyIndustries", new[] { "IndustryId" });
            DropIndex("dbo.CompanyIndustries", new[] { "CompanyId" });
            DropIndex("dbo.CompanyCities", new[] { "CityId" });
            DropIndex("dbo.CompanyCities", new[] { "CompanyId" });
            DropIndex("dbo.Industry", new[] { "IndCatId" });
            DropIndex("dbo.Company", new[] { "IndustryId" });
            DropIndex("dbo.Company", new[] { "CurrencyId" });
            DropIndex("dbo.Company", new[] { "DepartmentId" });
            DropIndex("dbo.City", new[] { "CountryId" });
            DropTable("dbo.CompanyIndustries");
            DropTable("dbo.CompanyCities");
            DropTable("dbo.IndustryCategory");
            DropTable("dbo.Industry");
            DropTable("dbo.Department");
            DropTable("dbo.Currency");
            DropTable("dbo.Company");
            DropTable("dbo.Country");
            DropTable("dbo.City");
            AddForeignKey("dbo.OrderDetails", "ProductInfoId", "dbo.ProductInfo", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Order", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Order", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
    }
}
