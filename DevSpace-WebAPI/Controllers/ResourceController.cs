using DevSpace_DataAccessLayer.Models;
using DevSpace_DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevSpace_BusinessLayer.Infrastructure.Dto;
using MongoDB.Bson;

namespace DevSpace_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceCollection _resourceCollection;
        private readonly ResourceServices _resourceServices;

        public ResourceController(IResourceCollection resourceCollection, ResourceServices resourceServices)
        {
            _resourceCollection = resourceCollection;
            _resourceServices = resourceServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetResources()
        {
            try
            {
                return Ok(await _resourceCollection.GetResources());
            }catch(Exception ex){
                return BadRequest(ex.Message); 
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResourceById(string id)
        {
            try
            {
                return Ok(await _resourceCollection.GetResourceById(id));
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddResource([FromBody] PostResourceDto resourceDto)
        {
            try
            {
                await _resourceServices.AddResourceAsync(resourceDto);
                return Ok();
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateResource([FromBody] Resource resource)
        {
            try
            {
                await _resourceCollection.UpdateResource(resource);
                return Ok();
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(string id)
        {
            try
            {
                await _resourceCollection.DeleteResource(id);
                return Ok();
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("resources/{name}")]
        public async Task<IActionResult> GetResourcesByName (string name)
        {
            try
            {
                return Ok(await _resourceCollection.GetResourcesByName(name));
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("favorites")]
        public async Task<IActionResult> GetResourcesFavorites()
        {
            try
            {
                return Ok(await _resourceCollection.GetResourcesFavorites());
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("favorite/{id}")]
        public async Task<IActionResult> UpdateResourceFavorite(string id)
        {
            try
            {
                await _resourceServices.UpdateResourceFavoriteAsync(id);
                return Ok();
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("folder/{folderId}")]
        public async Task<IActionResult> GetResourcesByFolderId(string folderId)
        {
            try
            {
                return Ok(await _resourceCollection.GetResourcesByFolderId(folderId));
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("folder/{folderId}")]
        public async Task<IActionResult> DeleteResourcesByFolderId(string folderId)
        {
            try
            {
                await _resourceCollection.DeleteResourcesByFolderId(folderId);
                return Ok();
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
    }
}