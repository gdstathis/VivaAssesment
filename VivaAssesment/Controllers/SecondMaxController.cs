using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
        public IActionResult SecondMax([FromBody] RequestObj? requestObj)
        {
            try
            {
                if (requestObj == null || requestObj.RequestArrayObj == null)
                {
                    return BadRequest("BadRequest");
                }
                else if (requestObj.RequestArrayObj.Count() < 2)
                {
                    return BadRequest("Arguments should be 2 or more numbers");
                }
                else if (requestObj.RequestArrayObj.Any(item => !int.TryParse(item.ToString(), out _)))
                {
                    return BadRequest("Invalid input. All elements in the request input must be integers.");
                }

                int? secondMax =
                    _secondMaxFinder.FindSecondMax(
                        (IEnumerable<int>)requestObj.RequestArrayObj.Select(item => Convert.ToInt32(item)));

                return Ok(secondMax);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
