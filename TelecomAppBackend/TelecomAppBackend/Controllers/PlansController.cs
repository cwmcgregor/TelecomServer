using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TelecomAppBackend.Data;
using TelecomAppBackend.DTO;
using TelecomAppBackend.Models;

namespace TelecomAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly TelecomDbContext _context;

        public PlansController(TelecomDbContext context)
        {
            _context = context;
        }

        // GET: api/Plans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlans()
        {
          if (_context.Plans == null)
          {
              return NotFound();
          }
            return await _context.Plans.ToListAsync();
        }

        // GET: api/Plans
        [HttpGet("User/{id}")]
        public async Task<ActionResult<IEnumerable<Plan>>> GetUsersPlans(int id)
        {
            if (_context.Plans == null)
            {
                return NotFound();
            }
            var plans = await _context.Plans.Where(p => p.UserId == id).ToListAsync();
            var devices = await _context.Devices.Where(d => d.Plan.UserId == id).ToListAsync();
            return Ok(plans);
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetPlan(int id)
        {
          if (_context.Plans == null)
          {
              return NotFound();
          }
            var plan = await _context.Plans.FindAsync(id);

            if (plan == null)
            {
                return NotFound();
            }

            var devices=await _context.Devices.Where(d=>d.PlanId==plan.PlanId).ToListAsync();
            var planDto = new PlanDetailsDTO
            {
                PlanId = plan.PlanId,
                PlanName = plan.PlanName,
                DeviceLimit = plan.DeviceLimit,
                Price = plan.Price,
                Devices = devices
            };

            return Ok(planDto);
        }

        // PUT: api/Plans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan(int id, Plan plan)
        {
            if (id != plan.PlanId)
            {
                return BadRequest();
            }

            _context.Entry(plan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Plans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plan>> PostPlan(PlanDTO planDto)
        {
          if (_context.Plans == null)
          {
              return Problem("Entity set 'TelecomDbContext.Plans'  is null.");
          }
            var plan = new Plan()
            {
                PlanName = planDto.PlanName,
                DeviceLimit = planDto.DeviceLimit,
                Price = planDto.Price,
                UserId = planDto.UserId,
                Devices = new List<Device>()
            };

            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlan", new { id = plan.PlanId }, plan);
        }

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(int id)
        {
            if (_context.Plans == null)
            {
                return NotFound();
            }
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }

            _context.Plans.Remove(plan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanExists(int id)
        {
            return (_context.Plans?.Any(e => e.PlanId == id)).GetValueOrDefault();
        }
    }
}
