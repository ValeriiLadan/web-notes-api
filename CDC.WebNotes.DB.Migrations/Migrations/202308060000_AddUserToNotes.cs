using FluentMigrator;
using System.Data;

namespace CDC.WebNotes.DB.Migrations
{
    [Migration(202308060000)]
    public class AddUsersToNotes : Migration
    {
        private const string NotesTableName = "Notes";
        private const string UsersTableName = "Users";
        private const string IdColumnName = "Id";
        private const string UserIdColumnName = "UserId";

        public override void Up()
        {
            Delete.FromTable(NotesTableName).AllRows();
            Delete.FromTable("NoteCheckListItems").AllRows();
            Delete.FromTable("Attachments").AllRows();
            Delete.FromTable("Files").AllRows();

            Alter.Table(NotesTableName)
                .AddColumn(UserIdColumnName).AsInt32().NotNullable();

            Create.ForeignKey("FK_Notes_Users_UserId")
                .FromTable(NotesTableName).ForeignColumn(UserIdColumnName)
                .ToTable(UsersTableName).PrimaryColumn(IdColumnName);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Notes_Users_UserId");
            Delete.Column(UserIdColumnName).FromTable(NotesTableName);
        }
    }
}
