using FluentMigrator;
using System.Data;

namespace CDC.WebNotes.DB.Migrations
{
    [Migration(202208092200)]
    public class AddNoteCheckListItemsTable : Migration
    {
        private const string CheckListItemsTableName = "NoteCheckListItems";
        private const string NotesTableName = "Notes";
        private const string IdColumnName = "Id";

        public override void Up()
        {
            Create.Table(CheckListItemsTableName)
                .WithColumn(IdColumnName).AsInt32().PrimaryKey().Identity()
                .WithColumn("Value").AsString().NotNullable()
                .WithColumn("IsComplited").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("NoteId").AsInt32()
                    .ForeignKey(NotesTableName, IdColumnName).OnDelete(Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(CheckListItemsTableName);
        }
    }
}
