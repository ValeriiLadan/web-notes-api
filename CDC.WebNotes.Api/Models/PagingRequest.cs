using System;

namespace CDC.WebNotes.Api.Models
{
    public class PagingRequest
    {
        public virtual int Limit { get; set; } = 10;
        public int Offset { get; set; }
    }

    public class SortingRequest<T> where T : Enum
    {
        public SortOrder Order { get; set; }
        public T SortingField { get; set; }
    }

    public enum SortOrder
    {
        Asc,
        Desc
    }
}
