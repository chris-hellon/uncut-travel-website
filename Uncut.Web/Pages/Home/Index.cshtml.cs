namespace Uncut.Web.Pages.Home
{
	public class IndexModel : TravaloudBasePageModel
    {
        [BindProperty]
        public GenericCardsComponent Introduction { get; private set; }

        [BindProperty]
        public FullImageCarouselComponent CarouselComponent { get; private set; }

        [BindProperty]
        public FullImageCardsComponent DestinationsCards { get; private set; }

        [BindProperty]
        public FullImageCardsComponent ToursCards { get; private set; }

        [BindProperty]
        public FullImageCardsComponent PromotedToursCards { get; private set; }

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
            Introduction = new GenericCardsComponent("Experience Vietnam", new List<CardComponent>()
            {
                new CardComponent("Destinations", "<p>At our travel company, we take pride in providing a diverse range of travel options and tours that cater to every type of traveler. Whether you're looking to explore the bustling cities, quaint towns, or breathtaking natural landscapes, we've got you covered. With our extensive network of partners and knowledgeable local guides, we can take you off the beaten path to discover hidden gems and create unforgettable experiences. So no matter where in the country you want to go, we can provide you with a personalized and seamless travel experience.</p>", new ButtonComponent("", "Read More")),
                new CardComponent("Tours & Activities", "<p>We understand that every traveler has unique preferences and interests when it comes to exploring new destinations. That's why our travel company offers a wide range of tour options and activities all across the country. From cultural and historical tours to adventure activities, we've got you covered. Plus, we are here to help you tailor your itinerary and choose the activities that best suit your needs and desires. Whether you're traveling solo, with friends or family, or on a business trip, we are dedicated to providing you with a personalized and hassle-free travel experience.</p>", new ButtonComponent("", "Read More")),
                new CardComponent("Services", "<p>We believe that everyone's travel needs are unique and we are here to help make your dream trip a reality. Our team of experts will work with you to create a personalized itinerary that takes into account your preferences and requirements. We offer a range of optional services and add-ons, ensuring that your trip is truly one-of-a-kind. With our service, you can rest assured that your travel experience will be unforgettable.</p>", new ButtonComponent("", "Read More"))
            });
            CarouselComponent = new FullImageCarouselComponent(await GetHomePageCarouselImages());
            ToursCards = WebComponentsBuilder.UncutTravel.GetToursWithCategoriesFullImageCards(ToursWithCategories, null, null);
            DestinationsCards = WebComponentsBuilder.UncutTravel.GetDestinationsCards(Destinations);
            PromotedToursCards = WebComponentsBuilder.UncutTravel.GetPromotedToursFullImageCards(PromotedTours);

            return Page();
        }

        public async Task<List<Image>> GetHomePageCarouselImages()
        {
            var images = new List<Image>();

            await Task.Run(() =>
            {
                images = new List<Image>()
                {
                    new Image("https://ik.imagekit.io/rqlzhe7ko/uncut/Banner_Background_Image.webp?tr=w-2000&updatedAt=1680182565348", new Guid("F28C2D2C-1C90-40A5-B13E-31D323C14E1E"), "Page", null, null, null, null, "<img src='https://ik.imagekit.io/rqlzhe7ko/uncut/Travel__Banner__Landscape__transparnt_background.webp?tr=w-2000&updatedAt=1680182565348' class='img-fluid position-absolute bottom-0 has-parallax-scroll' />")
                };
            });

            return images;
        }
    }
}











































































