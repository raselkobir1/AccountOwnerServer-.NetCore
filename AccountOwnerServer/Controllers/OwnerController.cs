using Contracts;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities.LoggerConfiguration;

namespace AccountOwnerServer.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        public OwnerController(IRepositoryWrapper repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;   
        }
        [HttpGet]
        public IActionResult GetallOwners()
        {
            try
            {
                var owners = _repository.Owner.GetAllOwners().ToList();
                var ownerDto = new OwnerDto();
                var ownrsDtoList = ownerDto.SetOwnerDtoList(owners);
                //SetOwnerDtoList
                _logger.LogInfo("Returned all owners from data base");
                return Ok(ownrsDtoList);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetOwnerById(Guid id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerById(id);
                if(owner is null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
