using System;
using Microsoft.AspNetCore.Mvc;
using PermisosApp.Domain.Entities;
using PermisosApp.Services.Abstract;

namespace PermisosApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypesController : ControllerBase
    {
        private readonly IPermissionTypeService permissionTypeService;
        public PermissionTypesController(IPermissionTypeService permissionTypeService) => this.permissionTypeService = permissionTypeService;

        [HttpGet("GetAll")]
        public IActionResult GetAll() => Ok(permissionTypeService.GetAll());

        [HttpGet("GetById/{id}")]
        public IActionResult GetAll(int id) => Ok(permissionTypeService.GetById(id));

        [HttpPost("Add")]
        public IActionResult Add([FromBody] PermissionType permissionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(permissionTypeService.Create(permissionType));
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
        public IActionResult Update([FromBody] PermissionType permissionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(permissionTypeService.Update(permissionType, permissionType.Id));
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
        public IActionResult Delete([FromBody] PermissionType permissionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(permissionTypeService.Delete(permissionType.Id));
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
