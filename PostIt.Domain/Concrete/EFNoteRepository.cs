using PostIt.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostIt.Domain.Concrete
{
    public class EFNoteRepository : INoteRepository
    {
        EFDbContext context = new EFDbContext();
        public IQueryable<Entities.Note> Notes
        {
            get { return context.Notes; }
        }


        public void SaveNote(Entities.Note note)
        {
            if (note.NoteId == 0)
            {
                note.Date = DateTime.Now;
                context.Notes.Add(note);
            }
            else
            {
                Entities.Note noteToEdit = context.Notes.FirstOrDefault(x => x.NoteId == note.NoteId);
                noteToEdit.Title = note.Title;
                noteToEdit.Text = note.Text;
                noteToEdit.Category = note.Category;
            }



            context.SaveChanges();
        }


        public void RemoveNote(Entities.Note note)
        {
            context.Notes.Remove(note);
            context.SaveChanges();
        }
    }
}
