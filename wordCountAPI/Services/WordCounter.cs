using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using wordCountAPI.Interfaces;
using wordCountAPI.Models;

namespace wordCountAPI.Services
{
    public class WordCounter : IWordCounter
    {
        public async Task<List<WordCountResult>> CountWordsAsync(Stream fileStream)
        {
            using var reader = new StreamReader(fileStream);
            var content = await reader.ReadToEndAsync();

            var matches = Regex.Matches(content.ToLower(), @"\b\w+\b");

            return matches
                .GroupBy(m => m.Value)
                .Select(g => new WordCountResult
                {
                    Word = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(w => w.Count)
                .ToList();
        }
    }
}