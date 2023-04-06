using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Uncut.Web.Pages.AboutUs
{
	public class IndexModel : TravaloudBasePageModel
    {
        public async Task<IActionResult> OnGet()
        {
            await base.OnGetDataAsync();

            return Page();
        }
    }
}
