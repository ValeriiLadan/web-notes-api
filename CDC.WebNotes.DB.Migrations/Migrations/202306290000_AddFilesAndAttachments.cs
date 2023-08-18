using FluentMigrator;
using System.Data;

namespace CDC.WebNotes.DB.Migrations
{
    [Migration(202306290000)]
    public class AddFilesAndAttachmentsTables : Migration
    {
        private const string FilesTableName = "Files";
        private const string AttachmentsTableName = "Attachments";
        private const string NotesTableName = "Notes";
        private const string IdColumnName = "Id";

        public override void Up()
        {
            Create.Table(FilesTableName)
                .WithColumn(IdColumnName).AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Url").AsString().NotNullable();

            Create.Table(AttachmentsTableName)
                .WithColumn(IdColumnName).AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("NoteId").AsInt32().NotNullable()
                    .ForeignKey(NotesTableName, IdColumnName).OnDelete(Rule.Cascade)
                .WithColumn("FileId").AsInt32().NotNullable()
                    .ForeignKey(FilesTableName, IdColumnName).OnDelete(Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(FilesTableName);
            Delete.Table(AttachmentsTableName);
        }
    }
}
