namespace WebApi.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;
using WebApi.Stores;

[AllowAnonymous]
[Route("api/v1/[controller]")]
public class ExampleController : ControllerBase
{
    private readonly IStore store;
    private readonly IFrequencyService frequencyService;

    public ExampleController(
        IStore store,
        IFrequencyService frequencyService)
    {
        this.store = store;
        this.frequencyService = frequencyService;
    }

    [HttpGet("ping")]
    public IActionResult Index() => this.Ok();
    
    [HttpPost("upload")]
    public async Task<IActionResult> HandleFormFile(IFormFile formFile, [FromQuery] int n = 100)
    {
        await using var stream = formFile.OpenReadStream();

        var frequencies = await this.frequencyService.ComputeTopNFrequencies(stream, n);
        
        return this.Ok(
            new
            {
                formFile.Name,
                formFile.FileName,
                formFile.Length,
                Frequencies = frequencies
            });
    }

    [HttpPost("output")]
    public IActionResult Create([FromBody] Input input)
    {
        var output = new Output
        {
            Name = input.Name,
            Id = Guid.NewGuid()
        };

        this.store.Save(output);

        return this.CreatedAtAction(nameof(this.GetById), new { id = output.Id }, output);
    }

    [HttpGet("output/{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var output = this.store.GetById(id);
        if (output == null)
        {
            return this.NotFound($"Could not find item with id {id}");
        }

        return this.Ok(output);
    }

    [HttpGet("output")]
    public IActionResult GetAll() => this.Ok(this.store.GetAll());
}