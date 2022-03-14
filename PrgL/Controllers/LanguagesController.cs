using Microsoft.AspNetCore.Mvc;
using PrgL.Models;
using PrgL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrgL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LanguagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var languages = await _unitOfWork.Language.GetAll();
            return Ok(languages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguage(int id)
        {
            var language = await _unitOfWork.Language.GetById(id);

            if (language == null)
            {
                return NotFound();
            }

            return Ok(language);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLanguage(Language language)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }

            await _unitOfWork.Language.Add(language);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetLanguage", new { language.Id }, language);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLanguage(int id, Language language)
        {
            if(await _unitOfWork.Language.GetById(id) == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return new JsonResult("Something wen wrong") { StatusCode = 500 };
            }

            language.Id = id;

            await _unitOfWork.Language.Update(language);
            await _unitOfWork.CompleteAsync();

            return Ok(language);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLanguage(int id)
        {
            if(await _unitOfWork.Language.GetById(id) == null)
            {
                return NotFound();
            }

            await _unitOfWork.Language.Delete(id);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
