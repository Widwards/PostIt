using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PostIt.Domain.Entities
{
    public class Note
    {
        private bool hasReadMore = false;

        [HiddenInput(DisplayValue = false)]
        public int NoteId { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        //[UIHint("tinymce_jquery_full"), AllowHtml]
        //[DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a text")]
        [AllowHtml]
        public string Text { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime Date { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Likes { get; set; }

        [Required(ErrorMessage = "Please enter a category")]
        public string Category { get; set; }

        public int? UserId { get; set; }
 
        //<!-- readmore -->
        public string NoteReadMore()
        {
            if (this.Text.Contains("<!-- readmore -->"))
            {
                int position = this.Text.IndexOf("<!-- readmore -->");
                this.hasReadMore = true;
                return this.Text.Substring(0, position);
            }
            else
            {
                this.hasReadMore = false;
                return this.Text;
            }
        }

        public bool HasReadMoreLink()
        {
            return hasReadMore;
        }
    }
}