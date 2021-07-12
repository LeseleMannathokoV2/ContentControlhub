using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApI_Project.Data.Dto;
using WebApI_Project.Data.Entities;
using WebApI_Project.Repository;
using WebApI_Project.Repository.Interfaces;

namespace WebApI_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : BaseApiController
    {
        private readonly IContentRepository _contentRepository;

        public IMapper Mapper { get; }

        public ContentController(IContentRepository contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentDto>>> GetContents()
        {
            var content = await _contentRepository.GetContentsAsync();
            var returnedContent = Mapper.Map<IEnumerable<ContentDto>>(content);
            return Ok(returnedContent);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ContentDto>> GetContent(string name)
        {
            var user = await _contentRepository.GetContentsById(name);
            return Mapper.Map<ContentDto>(user);
        }

        [HttpPost("{createContent}")]
        public async Task<ActionResult<ContentDto>> CreateContent(ContentDto contentDto)
        {
            var content = new Content
            {
                Name = contentDto.Name,
                Description = contentDto.Description
            };
            var returnedContent = Mapper.Map<ContentDto>(content);
            _contentRepository.SaveContents(content);
            if (await _contentRepository.SaveAllAsync()) return Ok(returnedContent);
            return BadRequest("Unable to send");
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult> DeleteContent(string name)
        {
            var content = await _contentRepository.GetContentsById(name);
             _contentRepository.DeleteContent(content);
            if( await _contentRepository.SaveAllAsync()) return Ok();

            return BadRequest("Unable to delete");
        }

         //[HttpPut]
        [HttpPut("{name}")]
         public async Task<IActionResult> UpdateContent(ContentDto contentDto , string contentid )
         {
                var contents = await _contentRepository.GetContentsById(contentid);

                Mapper.Map(contentDto, contents);
                _contentRepository.Update(contents);

                if (await _contentRepository.SaveAllAsync()) return NoContent();
               
            
            return BadRequest("Failed to update user");

        }
    }
}
