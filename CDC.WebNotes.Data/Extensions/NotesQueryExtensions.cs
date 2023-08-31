using CDC.WebNotes.Domain;
using CDC.WebNotes.Dto;
using CDC.WebNotes.Dto.Notes;
using System.Linq;

namespace CDC.WebNotes.Data.Extensions
{
    public static class NotesQueryExtensions
    {
        public static IQueryable<Note> Sort(this IQueryable<Note> notes,
                                            SortingDto<NotesSortingFieldsDto> sortingDto)
        {
            IQueryable<Note> result = sortingDto.SortingField switch
            {
                NotesSortingFieldsDto.Id => notes.SortBy(sortingDto.Order, note => note.Id),
                NotesSortingFieldsDto.Name => notes.SortBy(sortingDto.Order, note => note.Name),

                _ => notes.SortBy(sortingDto.Order, note => note.Id)
            };

            return result;
        }
    }
}
