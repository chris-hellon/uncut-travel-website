using Travaloud.Core.Entities.Catalog;

namespace Uncut.Web.Pages.Destination
{
	public class IndexModel : TravaloudBasePageModel
    {
        [BindProperty]
        public PageCategoryComponent Cards { get; private set; }

        [BindProperty]
        public Travaloud.Core.Entities.Catalog.Destination Destination { get; set; }

        [BindProperty]
        public GenericCardsComponent RelatedDestinationsCards { get; private set; }

        [BindProperty]
        public GenericCardsComponent ToursCards { get; private set; }

        public async Task<IActionResult> OnGetAsync(string destinationName)
        {
            await OnGetDataAsync();

            Cards = WebComponentsBuilder.UncutTravel.GetDestinationsCategoryPage(Destinations);
            Destination = Destinations.FirstOrDefault(x => x.FriendlyUrl == destinationName);

            var relatedDestinations = Destinations.Where(t => t.Id != Destination.Id).ToList();
            relatedDestinations.Shuffle();
            relatedDestinations = relatedDestinations.Take(3).ToList();

            RelatedDestinationsCards = WebComponentsBuilder.UncutTravel.GetDestinationsWithCategoriesGenericCards(relatedDestinations);

            var tours = await DestinationsRepository.GetDestinationTours(Destination.Id, TenantId);
            ToursCards = WebComponentsBuilder.UncutTravel.GetToursGenericCards(tours, $"Tours in {Destination.Name}");

            return Page();
        }
    }
}
