using FluentMigrator;

namespace CDC.WebNotes.DB.Migrations
{
    [Migration(20220717)]
    public class InitialSchema : Migration
    {
        private const string NotesTableName = "Notes";
        private const string IdColumnName = "Id";

        public override void Up()
        {
            Create.Table(NotesTableName)
                .WithColumn(IdColumnName).AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Description").AsString().Nullable();

            // Fill some start data
            Execute.Sql(@"INSERT INTO [Notes]
                        VALUES
                        ('First Note', 'Test descriptiones'),
                        ('Second Note', NULL),
                        ('Third Note', 'Welcome to real world')");
        }

        public override void Down()
        {
            Delete.Table(NotesTableName);
        }
    }
}
