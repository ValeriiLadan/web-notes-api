using AutoFixture;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Application.Mapping;
using CDC.WebNotes.Application.Services;
using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Domain.Notes;
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
            Note note = Fixture.Create<Note>();

            Mocker.GetMock<INotesRepository>()
                  .Setup((INotesRepository repo) => repo.GetNote(It.IsAny<int>()))
                  .ReturnsAsync(note);

            NoteDto noteDto = await Target.GetNote(note.Id);

            noteDto.Should().NotBeNull();
        }
    }
}
