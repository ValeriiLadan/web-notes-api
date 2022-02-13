using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CDC.WebNotes.Application.Contracts
{
    public interface INoteService
    {
        Task<object> GetAll();
    }
}
