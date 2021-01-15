using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSore.WebUI.Models
{
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPgaes
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemPerPage);
            }
        }
    }
}