using Microsoft.AspNetCore.Mvc;
using SecondMaxFinderLibrary;

namespace VivaAssesment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecondMaxController : Controller
    {
        private readonly SecondMaxFinder _secondMaxFinder;

        public SecondMaxController(SecondMaxFinder secondLargestFinder)
        {
            _secondMaxFinder = secondLargestFinder;
        }

        [HttpPost]
        public IActionResult SecondMax(RequestObj requestObj)
        {
            try
            {
                if (requestObj == null || requestObj.RequestArrayObj == null)
                {
                    return BadRequest("BadRequest");
                }
                if (requestObj.RequestArrayObj.Count() < 2)
                {
                    return BadRequest("Arguments should be 2 or more");
                }
                IEnumerable<int> numbersArray = requestObj.RequestArrayObj;
                int? secondLargest = _secondMaxFinder.FindSecondMax(numbersArray);

                return Ok(secondLargest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
