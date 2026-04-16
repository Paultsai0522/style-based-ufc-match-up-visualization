namespace UFCfights.Controllers;

using Microsoft.AspNetCore.Mvc;
using UFCfights.Services;

[ApiController]
[Route("api/[controller]")]
public class FightsController : ControllerBase
{
    private readonly FightsService _fightsService;

    public FightsController(FightsService fightsService)
    {
        _fightsService = fightsService;
    }

    [HttpGet]
    public IActionResult GetFights()
    {
        var fights = _fightsService.GetFights();
        return Ok(fights);
    }
}