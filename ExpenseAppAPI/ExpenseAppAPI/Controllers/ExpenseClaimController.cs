using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExpenseAppAPI.Models;
using ExpenseAppAPI.Data;


namespace ExpenseAppAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpenseClaimController : ControllerBase
    {
        private readonly ApiContext _context;

        public ExpenseClaimController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult CreateEdit(ExpenseClaim claim)
        {
            if(claim.Id == 0)
            {
                _context.Claims.Add(claim);

            }else
            {
                var bookinginDb = _context.Claims.Find(claim.Id);
                if (bookinginDb == null) {
                    return new JsonResult(NotFound());
                    }

                _context.Entry(bookinginDb).CurrentValues.SetValues(claim);

            }

            _context.SaveChanges();

            return new JsonResult(Ok(claim));

        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Claims.Find(id);

            if (result == null) {
                return new JsonResult(NotFound());

            }

            return new JsonResult(Ok(result));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Claims.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
            _context.Claims.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        [HttpGet("/GetAll")]
        public JsonResult GetAll()
        {
            var result = _context.Claims.ToList();

            return new JsonResult(Ok(result));
        }

    }
}
