using System;
using System.ComponentModel;

namespace CDC.WebNotes.Dto
{
    public class PagingDto
    {
        public int Limit { get; set; } = 10;
        public int Offset { get; set; }
    }

    public class SortingDto<T> where T : Enum
    {
        public T SortingField { get; set; }
        public ListSortDirection Order { get; set; }
    }
}
