using Bogus;
using CDC.WebNotes.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CDC.WebNotes.DataFactories.EntityBuilders
{
    public class NoteBuilder : BuilderBase<Note>
    {
        public NoteBuilder()
        {
            _model = new Faker<Note>()
                .Rules((faker, note) =>
                {
                    note.Id = 0;
                    note.Name = faker.Random.Word();
                    note.Description = faker.Lorem.Sentence();
                });
        }

        public NoteBuilder WithCheckListItems(ICollection<NoteCheckListItem> checkListItems = null,
                                              int count = 3)
        {
            _model.CheckListItems = checkListItems != null
                ? checkListItems.Take(count).ToList()
                : new Faker<NoteCheckListItem>()
                .Rules((faker, checkListItem) =>
                    {
                        checkListItem.IsComplited = faker.Random.Bool();
                        checkListItem.Value = faker.Lorem.Sentence();
                        checkListItem.Note = _model;
                    })
                    .Generate(count);

            return this;
        }
    }
}
