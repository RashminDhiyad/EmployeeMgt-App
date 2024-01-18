using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly EmployeeManagementDBContext _context;

        public DesignationController(EmployeeManagementDBContext context)
        {
            _context = context;
        }

        // GET: api/Designation
        [HttpGet]
        public async Task<IActionResult> GetDesignations()
        {
            var designations = await _context.designations.ToListAsync();
            return Ok(designations);
        }

        // GET: api/Designation/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDesignationById(int id)
        {
            var designationMst = await _context.designations.FirstOrDefaultAsync(x => x.DesignationId == id);

            if (designationMst == null)
            {
                return NotFound();
            }

            return Ok(designationMst);
        }

        // POST: api/Designation
        [HttpPost]
        public async Task<IActionResult> AddDesignation(DesignationMst designationMst)
        {
            _context.designations.Add(designationMst);
            await _context.SaveChangesAsync();

            return Ok(designationMst);
        }

        // PUT: api/Designation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDesignation(int id, DesignationMst designationMst)
        {
            if (id != designationMst.DesignationId)
            {
                return BadRequest();
            }

            _context.Entry(designationMst).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(designationMst);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignationMstExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/Designation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesignationMst(int id)
        {
            var designationMst = await _context.designations.FindAsync(id);
            if (designationMst == null)
            {
                return NotFound();
            }

            _context.designations.Remove(designationMst);
            await _context.SaveChangesAsync();

            return Ok(designationMst);
        }

        private bool DesignationMstExists(int id)
        {
            return _context.designations.Any(e => e.DesignationId == id);
        }
    }
}
