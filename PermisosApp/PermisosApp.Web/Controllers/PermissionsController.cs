using System;
using Microsoft.AspNetCore.Mvc;
using PermisosApp.Domain.Entities;
using PermisosApp.Services.Abstract;

namespace PermisosApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService permissionService;
        public PermissionsController(IPermissionService permissionService) => this.permissionService = permissionService;

        [HttpGet("GetAll")]
        public IActionResult GetAll() => Ok(permissionService.GetAll());

        [HttpGet("GetById/{id}")]
        public IActionResult GetAll(int id) => Ok(permissionService.GetById(id));

        [HttpPost("Add")]
        public IActionResult Add([FromBody] Permission permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(permissionService.Create(permission));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Permission permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(permissionService.Update(permission, permission.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] Permission permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(permissionService.Delete(permission.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message
                });
            }
        }
    }
}
