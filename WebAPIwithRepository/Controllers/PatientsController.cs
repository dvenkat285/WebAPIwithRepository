using Microsoft.AspNetCore.Mvc;
using WebAPIwithRepository.Models;
using WebAPIwithRepository.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIwithRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : Controller
    {
        private IPatient _patientRepo;

        public PatientsController(IPatient ptnt)
        {
            _patientRepo = ptnt;
        }

        // GET: api/<PatientsController>
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var a = _patientRepo.GetAllPatients();
            if (a == null)
            {
                return NotFound();
            }
            return Ok(a);
        }

        // GET api/<PatientsController>/5
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            Patient p = _patientRepo.GetPatientById(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        // POST api/<PatientsController>
        [HttpPost]
        [Route("Creates")]
        public IActionResult Creates(Patient pt)
        {
            int rs = _patientRepo.CreatePatient(pt);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else

            return Ok("Added! " + rs);
        }

        // PUT api/<PatientsController>/5
        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit(Patient pt)
        {
            int rs = _patientRepo.UpdatePatient(pt);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else

                return Ok("Updated! " + rs);

        }
        // DELETE api/<PatientsController>/5

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
            {
                int rs = _patientRepo.DeletePatient(id);
                if (rs <= 0)
                {
                    return BadRequest("Failed");
                }
                else

                    return Ok("Deleted! " + rs);
            }
        }
}
