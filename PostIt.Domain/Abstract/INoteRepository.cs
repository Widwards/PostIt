using PostIt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostIt.Domain.Abstract
{
    public interface INoteRepository
    {
        IQueryable<Note> Notes { get; }
        void SaveNote(Note note);
        void RemoveNote(Note note);
    }
}
