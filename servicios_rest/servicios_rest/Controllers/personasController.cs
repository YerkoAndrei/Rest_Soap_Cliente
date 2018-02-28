using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using servicios_rest.Models;

namespace servicios_rest
{
    public class personasController : ApiController
    {
        private bd_personasEntities1 db = new bd_personasEntities1();

        // GET: api/personas
        public IQueryable<persona> Getpersonas()
        {
            return db.personas;
        }

        // GET: api/personas/5
        [ResponseType(typeof(persona))]
        public IHttpActionResult Getpersona(int id)
        {
            persona persona = db.personas.Find(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/personas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpersona(int id, persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.id)
            {
                return BadRequest();
            }

            db.Entry(persona).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!personaExists(id))
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

        // POST: api/personas
        [ResponseType(typeof(persona))]
        public IHttpActionResult Postpersona(persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.personas.Add(persona);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = persona.id }, persona);
        }

        // DELETE: api/personas/5
        [ResponseType(typeof(persona))]
        public IHttpActionResult Deletepersona(int id)
        {
            persona persona = db.personas.Find(id);
            if (persona == null)
            {
                return NotFound();
            }

            db.personas.Remove(persona);
            db.SaveChanges();

            return Ok(persona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool personaExists(int id)
        {
            return db.personas.Count(e => e.id == id) > 0;
        }
    }
}