using SecondMaxFinderLibrary;

namespace SecondMaxFinderTestProject
{
    public class SecondMaxFinderTests
    {
        private readonly SecondMaxFinder _finder;

        public SecondMaxFinderTests()
        {
            _finder = new SecondMaxFinder();
        }

        /// <summary>
        /// it should return correct result (etc. 8)
        /// </summary>
        [Fact]
        public void FindSecondLargest_CorrectResult()
        {
            var inputArray = new List<int> { 5, 2, 8, 1, 9, 3 };

            int? result = _finder.FindSecondMax(inputArray);

            Assert.Equal(8, result);
        }

        /// <summary>
        /// Should return null if given list is empty
        /// </summary>
        [Fact]
        public void FindSecondLargest_ShouldReturnNullIfListIsEmpty()
        {
            var inputArray = new List<int>();

            int? result = _finder.FindSecondMax(inputArray);

            Assert.Null(result);
        }

        /// <summary>
        /// Should return number when list contains same numbers
        /// </summary>
        [Fact]
        public void FindSecondLargest_ListContainsSameNumbers()
        {
            var inputArray = new List<int> { 5, 5, 5, 5, 5, 5 };

            int? result = _finder.FindSecondMax(inputArray);

            Assert.Equal(5, result);
        }
    }
}
