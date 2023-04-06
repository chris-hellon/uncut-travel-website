namespace Uncut.Web.Pages.ToursAndActivities
{
	public class IndexModel : TravaloudBasePageModel
    {
        [BindProperty]
        public PageCategoryComponent Cards { get; private set; }

        public override List<Guid> PromotedToursIds()
        {
            return new List<Guid>() {
                new Guid("F83B2402-EA2C-4530-80B7-24E24D58E463"),
                new Guid("37EDAF8C-14C4-400C-9C20-9E905F73D731"),
                new Guid("0FE6316A-2A07-4DBB-9AF9-48EBE66AE49F"),
                new Guid("E30909AB-6264-4FDE-8651-E8D22DF46409"),
                new Guid("91B44754-F87F-4B6D-9750-6B38E6C1A270"),
                new Guid("4327CC5B-1B10-4361-9E33-6AB7255BE235"),
                new Guid("AB890E77-3B6E-4947-953A-463ED7D8684D"),
                new Guid("FA77BC16-F234-4059-B81B-32BD4EC615D6")
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await OnGetDataAsync();
            Cards = WebComponentsBuilder.UncutTravel.GetToursWithCategoriesPageCategoryComponent(ToursWithCategories);
            Cards.Cards.Cards.InsertRange(0, WebComponentsBuilder.UncutTravel.GetPromotedToursCards(PromotedTours));

            ViewData["Title"] = "Tours & Activities";

            return Page();
        }
    }
}
