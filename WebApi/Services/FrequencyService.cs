namespace WebApi.Services;

public interface IFrequencyService
{
    Task<List<string>> ComputeTopNFrequencies(Stream stream, int n);
}

internal sealed class FrequencyService : IFrequencyService
{
    private static readonly char[] Separators = [' '];
    
    public async Task<List<string>> ComputeTopNFrequencies(Stream stream, int n)
    {
        using var streamReader = new StreamReader(stream);

        Dictionary<string, int> frequencies = new();
        
        while (await streamReader.ReadLineAsync() is { } line)
        {
            var words = line.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var word in words)
            {
                if (frequencies.TryGetValue(word, out var value))
                {
                    frequencies[word] = value + 1;
                }
                else
                {
                    frequencies.Add(word, 1);
                }
            }
        }

        var topN = frequencies
            .OrderByDescending(x => x.Value)
            .Take(n)
            .Select(x => $"{x.Key}: {x.Value}")
            .ToList();

        return topN;
    }
}