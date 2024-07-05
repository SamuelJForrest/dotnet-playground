using DotnetPlayground.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DotnetPlayground.ViewModels
{
    public class BlogViewModel
    {
        public required Blog Blog { get; set; }
        public SelectList ColorOptions { get; set; }

        public BlogViewModel()
        {
            ColorOptions = new SelectList(new List<string> { "green", "orange", "yellow" });
        }
    }
}
