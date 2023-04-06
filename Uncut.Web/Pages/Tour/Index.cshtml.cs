using Travaloud.Core.Models.PageModels;

namespace Uncut.Web.Pages.Tour
{
    public class IndexModel : TourPageModel
    {
        public override string Subject()
        {
            return "Tour Booking Enquiry";
        }

        public override string TemplateName()
        {
            return "TourEnquiryTemplate";
        }

        [BindProperty]
        public Travaloud.Core.Entities.Catalog.Tour Tour { get; set; }

        [BindProperty]
        public GenericCardsComponent RelatedToursCards { get; private set; }

        public override async Task<IActionResult> OnGetAsync(string tourName = null)
        {
            await OnGetDataAsync();

            Tour = Tours.FirstOrDefault(x => x.FriendlyUrl == tourName);

            if (Tour != null)
            {
                var relatedTours = ToursWithCategories.Where(t => t.Id != Tour.Id).ToList();
                relatedTours.Shuffle();
                relatedTours = relatedTours.Take(3).ToList();

                RelatedToursCards = WebComponentsBuilder.UncutTravel.GetToursWithCategoriesGenericCards(relatedTours, null, true);
                Tour.TourPrices = await ToursRepository.GetTourPrices(Tour.Id);
                Tour.TourItineraries = await ToursRepository.GetTourItineraries(Tour.Id);
                EnquireNowComponent = new EnquireNowComponent()
                {
                    TourName = Tour.Name
                };
            }

            return Page();
        }
    }
}
