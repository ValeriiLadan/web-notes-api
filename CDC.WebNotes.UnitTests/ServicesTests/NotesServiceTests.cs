using AutoFixture;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Application.Services;
using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.DataFactories.EntityBuilders;
using CDC.WebNotes.Domain;
using CDC.WebNotes.Dto.Notes;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CDC.WebNotes.UnitTests.ServicesTests
{
    public class NotesServiceTests : ServiceBaseTests<INotesService, NotesService>
    {

        protected override void Customize()
        {

        }

        [Fact]
        public async Task GetNote_ById_ShouldReturnNote()
        {
            var _fixture = new Fixture();
            Note note = _fixture.Create<Note>();
            note.Name = "test"; // new NoteBuilder().WithCheckListItems().Build();

            Mocker.GetMock<INotesRepository>()
                  .Setup((INotesRepository repo) => repo.GetNote(It.IsAny<int>()))
                  .ReturnsAsync(note);

            NoteDto noteDto = await Target.GetNote(note.Id);

            noteDto.Should().NotBeNull();
        }
    }
}
