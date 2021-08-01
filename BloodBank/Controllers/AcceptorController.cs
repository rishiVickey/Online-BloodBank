using BloodBank.DataAccess.IRepository;
using BloodBank.DataAccess.specification;
using BloodBank.Models.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloodBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcceptorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AcceptorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IReadOnlyList<BloodAcceptor>> GetAll()
        {
            var spec = new AcceptorWithGender();
            return await _unitOfWork.Acceptor.GetAllWithSpec(spec);
        }

        [HttpGet("{id}")]
        public  Task<BloodAcceptor> GetById(int id)
        {  ////bug here
            var spec = new AcceptorWithGender(id);
            return  _unitOfWork.Acceptor.GetEntityWithSpec(spec);
        }

        [HttpPost]
        public async Task<ActionResult<BloodAcceptor>> PostAcceptor([FromBody] BloodAcceptor entity)
        {
           if(entity.Id == 0)
            {
                await _unitOfWork.Acceptor.AddEntity(entity);
                 await _unitOfWork.Save();
                return Ok();

            }
            return StatusCode(404);
        }

        [HttpPut]
        public IActionResult UpdateAcceptor([FromBody] BloodAcceptor entity)
        {
            if(entity.Id != 0)
            {
                _unitOfWork.Acceptor.Update(entity);
                _unitOfWork.Save();
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteAcceptor(int id)
        {
            if(id != 0)
            {
               var objFromDb = _unitOfWork.Acceptor.GetById(id);
                _unitOfWork.Acceptor.DeleteEntity(objFromDb);
                _unitOfWork.Save();
                return Ok();
            }
            return NotFound();
        }

    }
}
