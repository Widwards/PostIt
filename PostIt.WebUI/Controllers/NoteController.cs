using PostIt.Domain.Abstract;
using PostIt.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PostIt.Domain.Entities;
using Ninject;

namespace PostIt.WebUI.Controllers
{
    public class NoteController : Controller
    {

        public int PageSize = 3;

        [Inject]
        public INoteRepository repository { get; set; }

        public NoteController()
        {
        }

        [ValidateInput(false)] //TODO: very bad
        public ViewResult Note(int id)
        {

            Note note = repository.Notes.FirstOrDefault(x => x.NoteId == id);
            if (note != null) return View(note);
            else
            {
                return View("404");
            }
        }

        public ViewResult List(string category, int page = 1)
        {
            NotesListViewModel viewModel = new NotesListViewModel
                {
                    Notes = repository.Notes
                                      .Where( m => category == null || m.Category == category )
                                      .OrderBy(m => m.NoteId)
                                      .Skip((page - 1)*PageSize)
                                      .Take(PageSize),
                    PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = PageSize,
                            TotalItems = category == null ?
                                repository.Notes.Count() :
                                repository.Notes.Count(n => n.Category == category)
                        },
                    CurrentCategory = category
                };

            //<!--#readmore#--> implementation


            return View(viewModel);
        }

        //GET query
        public ViewResult Search(string query)
        {
            ViewBag.query = query;

            //TODO: implement normal serch logic
            IEnumerable<Note> searchResult =
                repository.Notes.Where(x => x.Title.Contains(query) || x.Text.Contains(query)).OrderBy(x => x.NoteId).Select(x => x);

            
            return View("SimpleSearchResult", searchResult);
        }

    }
}
