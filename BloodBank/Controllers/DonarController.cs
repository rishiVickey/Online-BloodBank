using BloodBank.DataAccess.IRepository;
using BloodBank.DataAccess.specification;
using BloodBank.Models.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloodBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonarController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DonarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        [HttpGet]
        public async Task<IReadOnlyList<BloodDonar>> GetAll(string sort)
        {
            var spec = new DonarWithGenderAndBloodSpec(sort);
            return await _unitOfWork.donar.GetAllWithSpec(spec);
        }

        [HttpGet("{id}")]
        public async Task<BloodDonar> GetById(int id)
        {
            var spec = new DonarWithGenderAndBloodSpec(id);
            return await _unitOfWork.donar.GetEntityWithSpec(spec);
        }

        [HttpPost]
        public async Task<ActionResult> PostDonar([FromBody] BloodDonar entity)
        {
            if (entity.Id == 0)
            {
                await _unitOfWork.donar.AddEntity(entity);
                await _unitOfWork.Save();
                return Ok();
            }
            return StatusCode(404);

        }

        [HttpPut]
        public async Task<ActionResult> UpdateDonar([FromBody] BloodDonar entity)
        {
            if (entity.Id != 0)
            {
                await _unitOfWork.donar.Update(entity);
                await _unitOfWork.Save();
                return Ok();
            }
            return StatusCode(404);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEntity(int id)
        {
           var obj = _unitOfWork.donar.GetById(id);
            if(obj!= null)
            {
                _unitOfWork.donar.DeleteEntity(obj);
                _unitOfWork.Save();
                return Ok();
            }
            return StatusCode(404);
            
        }
    }
}
