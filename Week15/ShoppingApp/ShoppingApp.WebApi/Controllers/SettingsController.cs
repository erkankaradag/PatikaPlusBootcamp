using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Operations.Setting;

namespace ShoppingApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SettingsController : ControllerBase
{
    private readonly ISettingService _settingService;

    public SettingsController(ISettingService settingService)
    {
        _settingService = settingService;
    }

    [HttpPatch]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ToggleMaintenence()
    {
        await _settingService.ToggleMaintenence();

        return Ok();
    }
}