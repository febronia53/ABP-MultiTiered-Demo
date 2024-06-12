
using Acme.BookStore.Authors;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Controllers.Authors
{
    [Microsoft.AspNetCore.Mvc.Route("api/authors")]
    public class AuthorController: BookStoreController
    {
        private IAuthorAppService _authorAppService;
        public AuthorController(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorAsync(Guid id)
        {
            var author = await _authorAppService.GetAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpGet]
        public async Task<ActionResult> GetAuthorList(GetAuthorListDto dto)
        {
            var authorList = await _authorAppService.GetListAsync(dto);
            return Ok(authorList);
        }

        [HttpPost]
        public async Task<ActionResult> AuthorBook(CreateAuthorDto dto)
        {
            await _authorAppService.CreateAsync(dto);
            return Ok(StatusCode(200));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(Guid id)
        {
            await _authorAppService.DeleteAsync(id);
            return Ok(StatusCode(200));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(Guid id, UpdateAuthorDto dto)
        {
            await _authorAppService.UpdateAsync(id, dto);
            return Ok(StatusCode(200));
        }
    }
}
