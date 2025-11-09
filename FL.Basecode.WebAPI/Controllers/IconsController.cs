using FL.Basecode.Services.Interfaces;
using FL.Basecode.WebAPI.DTOs;
using FL.Basecode.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FL.Basecode.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IconsController : ControllerBase
    {
        private readonly iIconService _iconService;

        public IconsController(iIconService iconService)
        {
            _iconService = iconService;
        }

        // CREATE
        [HttpPost("Add-Icons")]
        public async Task<ActionResult<IconsDTO.Response>> Create([FromBody] IconsDTO.CreateRequest request)
        {
            var icon = new mIcons
            {
                iconName = request.IconName,
                iconUrl = request.IconUrl
            };

            var created = await _iconService.CreateIconAsync(icon);

            var response = new IconsDTO.Response
            {
                IconId = created.iconId,
                IconName = created.iconName,
                IconUrl = created.iconUrl,
                CreatedAt = created.createdAt,
                UpdatedAt = created.updatedAt
            };

            return CreatedAtAction(nameof(GetById), new { iconId = response.IconId }, response);
        }

        // READ by ID
        [HttpGet("Get-Icons-by-Id/{iconId}")]
        public async Task<ActionResult<IconsDTO.Response>> GetById(string iconId)
        {
            var icon = await _iconService.GetIconByIdAsync(iconId);

            if (icon == null)
                return NotFound();

            return new IconsDTO.Response
            {
                IconId = icon.iconId,
                IconName = icon.iconName,
                IconUrl = icon.iconUrl,
                CreatedAt = icon.createdAt,
                UpdatedAt = icon.updatedAt
            };
        }

        // READ all
        [HttpGet("Get-All-Icons")]
        public async Task<ActionResult<List<IconsDTO.Response>>> GetAll()
        {
            var icons = await _iconService.GetAllIconsAsync();

            var response = icons.Select(i => new IconsDTO.Response
            {
                IconId = i.iconId,
                IconName = i.iconName,
                IconUrl = i.iconUrl,
                CreatedAt = i.createdAt,
                UpdatedAt = i.updatedAt
            }).ToList();

            return Ok(response);
        }

        // UPDATE
        [HttpPut("Update-Icons{iconId}")]
        public async Task<ActionResult<IconsDTO.Response>> Update(string iconId, [FromBody] IconsDTO.UpdateRequest request)
        {
            var icon = new mIcons
            {
                iconId = iconId,
                iconName = request.IconName,
                iconUrl = request.IconUrl
            };

            var updated = await _iconService.UpdateIconAsync(icon);

            if (updated == null)
                return NotFound();

            return new IconsDTO.Response
            {
                IconId = updated.iconId,
                IconName = updated.iconName,
                IconUrl = updated.iconUrl,
                CreatedAt = updated.createdAt,
                UpdatedAt = updated.updatedAt
            };
        }

        // DELETE
        [HttpDelete("Delete-Icons{iconId}")]
        public async Task<ActionResult<IconsDTO.DeleteResponse>> Delete(string iconId)
        {
            var success = await _iconService.DeleteIconAsync(iconId);

            return new IconsDTO.DeleteResponse
            {
                IconId = iconId,
                Success = success,
                Message = success ? "Icon deleted successfully." : "Icon not found."
            };
        }
    }
}
