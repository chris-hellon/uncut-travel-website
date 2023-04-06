namespace Uncut.Web.Pages.TourCategory
{
    public class IndexModel : TravaloudBasePageModel
    {
        [BindProperty]
        public PageCategoryComponent Cards { get; private set; }

        public async Task<IActionResult> OnGetAsync(string tourCategoryName = null)
        {
            await OnGetDataAsync();

            var tourCategory = tourCategoryName != null ? ToursWithCategories.FirstOrDefault(x => x.FriendlyUrl == tourCategoryName && !x.CategoryId.HasValue) : null;

            var toursWithCategories = ToursWithCategories.ToList();
            toursWithCategories.AddRange(DestinationsWithCategories.ToList());

            Cards = WebComponentsBuilder.UncutTravel.GetToursWithCategoriesPageCategoryComponent(toursWithCategories, tourCategory);

            if (tourCategory != null)
            {
                ViewData["Title"] = tourCategory.Name;
                ViewData["TourInfo"] = tourCategory.Description;
            }
            else
                ViewData["Title"] = "Tours & Activities";

            return Page();
        }
    }
}
