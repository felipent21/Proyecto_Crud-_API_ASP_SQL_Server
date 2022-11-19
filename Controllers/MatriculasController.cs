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
    public class MatriculasController : ControllerBase
    {
        #region constructores
        private readonly TransitoDbContext _context;


        public MatriculasController(TransitoDbContext context)
        {
            _context = context;

        }

        #endregion contructores

        #region get
        /// <summary>
        /// <Method = "get">
        /// </Method>
        /// </summary>
        /// <returns></returns>
        // GET: api/<MatriculasController>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<MatriculasDTO>>> Get()
        {
            try
            {
                var matricula = await _context.Matriculas.Select(x =>
                new MatriculasDTO
                {
                    Id = x.Id,
                    Numero = x.Numero,
                    FechaExpedicion = x.FechaExpedicion,
                    ValidaHasta = x.ValidaHasta,
                    Activo = x.Activo

                }).ToListAsync();
                if (matricula == null)
                {
                    return NotFound();
                }
                else
                {
                    return matricula;
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
        // GET api/<MatriculasController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult<MatriculasDTO>> Get(int id)
        {
            try
            {
                var matricula = await _context.Matriculas.Select(x =>
                new MatriculasDTO
                {
                    Id = x.Id,
                    Numero = x.Numero,
                    FechaExpedicion = x.FechaExpedicion,
                    ValidaHasta = x.ValidaHasta,
                    Activo = x.Activo

                }).FirstOrDefaultAsync(x => x.Id == id);
                if (matricula == null)
                {
                    return NotFound();
                }
                else
                {
                    return matricula;
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
        /// <param name="matriculas"></param>
        /// <returns></returns>
        // POST api/<MatriculasController>
        [HttpPost]

        public async Task<HttpStatusCode> Post(MatriculasDTO matriculas)
        {
            
                var entity = new Matriculas()
            {
                
                Numero = matriculas.Numero,
                FechaExpedicion = matriculas.FechaExpedicion,
                ValidaHasta = matriculas.ValidaHasta,
                Activo = matriculas.Activo
            };

            
                _context.Matriculas.Add(entity);
            
                await _context.SaveChangesAsync();
            
                return HttpStatusCode.Created;
   
        }

        #endregion post

        #region put
        /// <summary>
        /// <Method="put">
        /// </Method>
        /// </summary>
        /// <param name="matriculas"></param>
        /// <returns></returns>
        // PUT api/<MatriculasController>/5
        [HttpPut("{id}")]

        public async Task<HttpStatusCode> Put(MatriculasDTO matriculas)
        {
            var entity = await _context.Matriculas.FirstOrDefaultAsync(v => v.Id == matriculas.Id);

            entity.Id = matriculas.Id;
            entity.Numero = matriculas.Numero;
            entity.FechaExpedicion = matriculas.FechaExpedicion;
            entity.ValidaHasta = matriculas.ValidaHasta;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }


        #endregion put

        #region delete
        /// <summary>
        /// <Method ="delete">
        /// </Method>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<MatriculasController>/5
        [HttpDelete("{id}")]

        public async Task<HttpStatusCode> Delete(int id)
        {
            var entity = new Matriculas()
            {
                Id = id
            };
            _context.Matriculas.Attach(entity);
            _context.Matriculas.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;

        }

        #endregion delete

    }
    }
