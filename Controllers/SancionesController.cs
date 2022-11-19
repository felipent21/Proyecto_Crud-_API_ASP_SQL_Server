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
    public class SancionesController : ControllerBase
    {
        #region constructores
        private readonly TransitoDbContext _context;


        public SancionesController(TransitoDbContext context)
        {
            _context = context;

        }

        #endregion constructores
        #region get
        /// <summary>
        /// <Method = "get">
        /// </Method>
        /// </summary>
        /// <returns></returns>
        // GET: api/<SancionesController>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<SancionesDTO>>> Get()
        {
            try
            {
                var sancion = await _context.Sanciones.Select(x =>
                new SancionesDTO
                {
                    Id = x.Id,
                    FechaActual = x.FechaActual,
                    Sancion = x.Sancion,
                    Observacion = x.Observacion,
                    Valor = x.Valor,
                    ConductoresId = x.ConductoresId,
                    ConductoresNombre = x.Conductores.Nombre
                }).ToListAsync();
                if (sancion == null)
                {
                    return NotFound();
                }
                else
                {
                    return sancion;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion get

        #region get xid
        /// <summary>
        /// <Method = "get x id">
        /// </Method>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<SancionesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SancionesDTO>> Get(int id)
        {
            try
            {
                var sancion = await _context.Sanciones.Select(x =>
                new SancionesDTO
                {

                    Id = x.Id,
                    FechaActual = x.FechaActual,
                    Sancion = x.Sancion,
                    Observacion = x.Observacion,
                    Valor = x.Valor,
                    ConductoresId = x.ConductoresId,
                    ConductoresNombre = x.Conductores.Nombre

                }).FirstOrDefaultAsync(x => x.Id == id);
                if (sancion == null)
                {
                    return NotFound();
                }
                else
                {
                    return sancion;
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
        /// <Method = "post">
        /// </Method>
        /// </summary>
        /// <param name="sanciones"></param>
        /// <returns></returns>
        // POST api/<SancionesController>
        [HttpPost]

        public async Task<HttpStatusCode> Post(SancionesDTO sanciones)
        {
            var entity = new Sanciones()
            {
                //Id = vendedores.Id,

                FechaActual=sanciones.FechaActual,
                Sancion=sanciones.Sancion,
                Observacion=sanciones.Observacion,
                Valor=sanciones.Valor,
                ConductoresId=sanciones.ConductoresId
            };
            _context.Sanciones.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;

        }
        #endregion post
        #region put
        /// <summary>
        /// <Method ="put">
        /// </Method>
        /// </summary>
        /// <param name="sanciones"></param>
        /// <returns></returns>
        // PUT api/<SancionesController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(SancionesDTO sanciones)
        {
            var entity = await _context.Sanciones.FirstOrDefaultAsync(v => v.Id == sanciones.Id);
            entity.Id = sanciones.Id;
            entity.FechaActual = sanciones.FechaActual;
            entity.Sancion = sanciones.Sancion;
            entity.Observacion = sanciones.Observacion;
            entity.Valor = sanciones.Valor;
            entity.ConductoresId = sanciones.ConductoresId;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }
        #endregion put
        #region delete
        /// <summary>
        /// <Method="delete">
        /// </Method>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<SancionesController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {

            var entity = new Sanciones()
            {
                Id = id
            };
            _context.Sanciones.Attach(entity);
            _context.Sanciones.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion delete

    }
}
