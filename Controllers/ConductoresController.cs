using ApiTransito.DAL.DbContext;
using ApiTransito.DAL.Entities;
using ApiTransito.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTransito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductoresController : ControllerBase
    {

        #region Contructores

        private readonly TransitoDbContext _context;


        public ConductoresController(TransitoDbContext context)
        {
            _context = context;

        }

        #endregion Constructores

        #region get
        // GET: api/<ConductoresController>
        /// <summary>
        /// <Method="Get">
        /// </Method>
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        
        public async Task<ActionResult<IEnumerable<ConductoresDTO>>> Get()
        {
            try
            {
                var conductor = await _context.Conductores.Select(x =>
                new ConductoresDTO
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    MatriculasId = x.MatriculasId,
                    Vencimiento = x.Matriculas.ValidaHasta
                }).ToListAsync();
                if (conductor == null)
                {
                    return NotFound();
                }
                else
                {
                    return conductor;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion get

        #region get x id
        /// <summary>
        /// <Method="Get ById">
        /// </Method>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<ConductoresController>/5
        [HttpGet("{id}")]

        
        public async Task<ActionResult<ConductoresDTO>> Get(int id)
        {
            try
            {
                var conductor = await _context.Conductores.Select(x =>
                new ConductoresDTO
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    MatriculasId = x.MatriculasId,
                    Vencimiento = x.Matriculas.ValidaHasta
                }).FirstOrDefaultAsync(x => x.Id == id);
                if (conductor == null)
                {
                    return NotFound();
                }
                else
                {
                    return conductor;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion get xid
        #region post
        /// <summary>
        /// <Method="Post">
        /// </Method>
        /// </summary>
        /// <param name="conductores"></param>
        /// <returns></returns>
        // POST api/<ConductoresController>
        [HttpPost]
       
        public async Task<HttpStatusCode> Post(Conductores conductores)
        {
            var entity = new Conductores()
            {
                Identificacion = conductores.Identificacion,
                Nombre = conductores.Nombre,
                Apellido = conductores.Apellido,
                Direccion = conductores.Direccion,
                Telefono = conductores.Telefono,
                Email = conductores.Email,
                FechaNacimiento = conductores.FechaNacimiento,
                Activo = conductores.Activo,
                MatriculasId = conductores.MatriculasId

            };
            _context.Conductores.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        #endregion post
        #region put 
        /// <summary>
        /// <Method="Put">
        /// </Method>
        /// </summary>
        /// <param name="conductores"></param>
        /// <returns></returns>
        // PUT api/<ConductoresController>/5
        [HttpPut("{id}")]

        
        public async Task<HttpStatusCode> Put(Conductores conductores)
        {
            var entity = await _context.Conductores.FirstOrDefaultAsync(v => v.Id == conductores.Id);

            entity.Id = conductores.Id;
            entity.Nombre = conductores.Nombre;
            entity.Apellido = conductores.Apellido;
            entity.Direccion = conductores.Direccion;
            entity.Telefono = conductores.Telefono;
            entity.Email = conductores.Email;
            entity.FechaNacimiento = conductores.FechaNacimiento;
            entity.Activo = conductores.Activo;
            entity.MatriculasId = conductores.MatriculasId;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;

        }
        #endregion put
        #region delete
        /// <summary>
        /// <Method = "Delete">
        /// </Method>        
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<ConductoresController>/5
        [HttpDelete("{id}")]
        
        public async Task<HttpStatusCode> Delete(int id)
        {

            var entity = new Conductores()
            {
                Id = id
            };
            _context.Conductores.Attach(entity);
            _context.Conductores.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion delete

    }
}
