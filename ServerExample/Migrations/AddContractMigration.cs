using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace ServerExample.Migrations
{
    internal class AddContractMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable("Contract",
                c => new
                {
                    ContractId = c.Int(nullable: false, identity: true),
                    CreationDate = c.DateTime(),
                    UpdateDate = c.DateTime(),
                })
                .PrimaryKey(t => t.ContractId);
        }

        public override void Down()
        {
            DropTable("Contract");
        }

    }
}
