namespace Uncut.Web.Pages.Destinations
{
    public class IndexModel : TravaloudBasePageModel
    {
        [BindProperty]
        public PageCategoryComponent Cards { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await OnGetDataAsync();

            Cards = WebComponentsBuilder.UncutTravel.GetDestinationsCategoryPage(Destinations);

            return Page();
        }
    }
}
