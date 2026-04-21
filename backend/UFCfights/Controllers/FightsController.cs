namespace UFCfights.Controllers;

using Microsoft.AspNetCore.Mvc;
using UFCfights.Services;
using UFCfights.DTO;

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

    [HttpPost("brush")]
    public ActionResult GetFightsByMatchUp([FromBody] BrushRequest request)
    {
        var fights = _fightsService.GetFightsByMatchUp(request.Brush1_fighters, request.Brush2_fighters);
        return Ok(fights);
    }
}