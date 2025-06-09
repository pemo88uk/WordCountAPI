using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wordCountAPI.Interfaces;

namespace wordCountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordCountController : ControllerBase
    {
        private readonly IWordCounter _wordCounter;

        public WordCountController(IWordCounter wordCounter)
        {
            _wordCounter = wordCounter;
        }

        [HttpPost]
        public async Task<IActionResult> UploadTextFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please upload a valid .txt file.");

            var result = await _wordCounter.CountWordsAsync(file.OpenReadStream());

            return Ok(result);
        }
    }
}