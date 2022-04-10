namespace Wpb.CarsRating.Core.ContextObjects
{
    public class ReviewUnderTest : BaseContextUnderTest<ReviewUnderTest>
    {
        public ReviewUnderTest()
        {
            Current = new UserReview();
        }

        public UserReview Current { get; set; }
    }

    public class UserReview
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int VoteCount { get; set; }
        public string Review { get; set; }
        public string Author { get; set; }
        public string DateTime { get; set; }
    }
}
