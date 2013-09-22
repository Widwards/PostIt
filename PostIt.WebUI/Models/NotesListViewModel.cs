using PostIt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostIt.WebUI.Models
{
    public class NotesListViewModel
    {
        public IEnumerable<Note> Notes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}