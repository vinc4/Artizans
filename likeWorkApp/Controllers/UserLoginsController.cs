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
    public class UserLoginsController : ApiController
    {
        private LeaveDbContext db = new LeaveDbContext();

        // GET: api/UserLogins
        public IQueryable<UserLogin> GetUserLogins()
        {
            return db.UserLogins;
        }

        // GET: api/UserLogins/5
        [ResponseType(typeof(UserLogin))]
        public async Task<IHttpActionResult> GetUserLogin(int id)
        {
            UserLogin userLogin = await db.UserLogins.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }

            return Ok(userLogin);
        }

        // PUT: api/UserLogins/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserLogin(int id, UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userLogin.UserLoginID)
            {
                return BadRequest();
            }

            db.Entry(userLogin).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginExists(id))
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

        // POST: api/UserLogins/AttemptLogin
        [HttpPost]
        [Route("api/UserLogins/AttemptLogin)")]
        [ResponseType(typeof(UserLogin))]
        public async Task<IHttpActionResult> AttemptLogin(UserLogin userLogin)
        {
            var loginSuccess = false;
            object user = null;
            if (string.IsNullOrEmpty(userLogin.Username) || string.IsNullOrEmpty(userLogin.Password))
            { 
                return Ok(new { loginSuccess, user });
            }

            user = db.UserLogins.Where(x => x.Password == userLogin.Password && x.Username == userLogin.Username).SingleOrDefault();
            if(user!= null)
            {
                loginSuccess = true;
            }

            return Ok( new {loginSuccess, user });
        }

        // POST: api/UserLogins
        [ResponseType(typeof(UserLogin))]
        public async Task<IHttpActionResult> PostUserLogin(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //get user role
            var role = db.Roles.Where(x => x.RoleID == 1).Single();
            userLogin.Role = role;

            db.UserLogins.Add(userLogin);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userLogin.UserLoginID }, userLogin);
        }

        // DELETE: api/UserLogins/5
        [ResponseType(typeof(UserLogin))]
        public async Task<IHttpActionResult> DeleteUserLogin(int id)
        {
            UserLogin userLogin = await db.UserLogins.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }

            db.UserLogins.Remove(userLogin);
            await db.SaveChangesAsync();

            return Ok(userLogin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserLoginExists(int id)
        {
            return db.UserLogins.Count(e => e.UserLoginID == id) > 0;
        }
    }
}