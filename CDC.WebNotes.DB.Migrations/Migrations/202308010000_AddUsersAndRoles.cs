using FluentMigrator;
using System.Data;

namespace CDC.WebNotes.DB.Migrations
{
    [Migration(202308010000)]
    public class AddUsersAndRoles : Migration
    {
        private const string UsersTableName = "Users";
        private const string IdColumnName = "Id";

        public override void Up()
        {
            Create.Table(UsersTableName)
                .WithColumn(IdColumnName).AsInt32().PrimaryKey().Identity()
                .WithColumn("Username").AsString(100).NotNullable()
                .WithColumn("PasswordHash").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table(UsersTableName);
        }
    }
}
