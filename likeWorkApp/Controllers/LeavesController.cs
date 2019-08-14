using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using likeWorkApp.Models;

namespace likeWorkApp.Controllers
{
    public class LeavesController : ApiController
    {
        private LeaveDbContext db = new LeaveDbContext();

        // GET: api/Leaves
        public IQueryable<Leave> GetLeaves()
        {
            return db.Leaves;
        }

        // GET: api/Leaves/5
        [ResponseType(typeof(Leave))]
        public async Task<IHttpActionResult> GetLeave(int id)
        {
            Leave leave = await db.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            return Ok(leave);
        }

        // PUT: api/Leaves/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLeave(int id, Leave leave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leave.LeaveID)
            {
                return BadRequest();
            }

            db.Entry(leave).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Leaves
        [ResponseType(typeof(Leave))]
        public async Task<IHttpActionResult> PostLeave(Leave leave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Leaves.Add(leave);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = leave.LeaveID }, leave);
        }

        // DELETE: api/Leaves/5
        [ResponseType(typeof(Leave))]
        public async Task<IHttpActionResult> DeleteLeave(int id)
        {
            Leave leave = await db.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            db.Leaves.Remove(leave);
            await db.SaveChangesAsync();

            return Ok(leave);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeaveExists(int id)
        {
            return db.Leaves.Count(e => e.LeaveID == id) > 0;
        }
    }
}