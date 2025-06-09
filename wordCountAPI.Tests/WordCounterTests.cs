using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using wordCountAPI.Services;
using Xunit;

namespace wordCountAPI.Tests
{
    public class WordCounterTests
    {
        private readonly WordCounter _service = new();

        // Tests common word count logic with varied inputs and case sensitivity
        [Theory]
        [InlineData("apple apple banana", "apple", 2)]             // simple repeat
        [InlineData("DOG dog Dog cat", "dog", 3)]                  // case-insensitive match
        [InlineData("test TEST test Test", "test", 4)]             // mixed casing
        [InlineData("123 abc ABC abc", "abc", 3)]                  // alphanumeric & case-insensitive
        public async Task CountWordsAsync_ShouldReturnExpectedWordCount(string input, string expectedWord, int expectedCount)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            var result = await _service.CountWordsAsync(stream);
            var match = result.FirstOrDefault(r => r.Word == expectedWord);

            Assert.NotNull(match); // ensures word is found
            Assert.Equal(expectedCount, match.Count);
        }

        // Tests how the service handles completely empty input
        [Fact]
        public async Task CountWordsAsync_EmptyInput_ReturnsEmptyList()
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(""));
            var result = await _service.CountWordsAsync(stream);

            Assert.NotNull(result); // should return an empty list, not null
            Assert.Empty(result);   // confirms list is empty
        }

        // Tests that punctuation is ignored and words are still counted properly
        [Fact]
        public async Task CountWordsAsync_IgnoresPunctuationCorrectly()
        {
            var input = "Hello, hello! HELLO? World.";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            var result = await _service.CountWordsAsync(stream);

            var hello = result.FirstOrDefault(r => r.Word == "hello");
            var world = result.FirstOrDefault(r => r.Word == "world");

            Assert.NotNull(hello);
            Assert.Equal(3, hello.Count); // all variations of "hello" should be counted

            Assert.NotNull(world);
            Assert.Equal(1, world.Count);
        }
    }
}