using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using wordCountAPI.Models; // ✅ Import your model namespace

namespace wordCountAPI.Interfaces
{
    public interface IWordCounter
    {
        Task<List<WordCountResult>> CountWordsAsync(Stream fileStream);
    }
}