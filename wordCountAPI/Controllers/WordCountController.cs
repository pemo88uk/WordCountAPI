using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace helloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordCountController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadTextFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please upload a valid .txt file.");

            using var reader = new StreamReader(file.OpenReadStream());
            var content = await reader.ReadToEndAsync();

            // Normalize and split words
            var matches = Regex.Matches(content.ToLower(), @"\b\w+\b");

            var wordCounts = matches
                .GroupBy(m => m.Value)
                .Select(g => new { Word = g.Key, Count = g.Count() })
                .OrderByDescending(w => w.Count)
                .Select(w => new KeyValuePair<string, int>(w.Word, w.Count))
                .ToList();

            return Ok(wordCounts);
        }
    }
}