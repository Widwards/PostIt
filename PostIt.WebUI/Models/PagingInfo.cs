using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostIt.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get
            {
                
                int cnt = (int) Math.Ceiling((decimal) TotalItems/ItemsPerPage);
                if (cnt==1)
                {
                    return 0;
                }
                else
                {
                    return cnt;
                }
            }
        }
    }
}