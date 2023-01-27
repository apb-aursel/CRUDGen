using AutoMapper;
using CRUDGen.Extensions;
using CRUDGen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO.Pipelines;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CRUDGen.Controllers
{
    public class BaseCRUDController<TEntity, TEntityDto> : BaseController where TEntity : class
    {
        private readonly DbCtx _dbCtx;
        private readonly bool _isIdiomEntity;
        private readonly IMapper _mapper;
        private readonly string _primaryKeyName;


        public BaseCRUDController(DbCtx dbCtx, IMapper mapper, string primaryKeyName, bool isIdiomEntity = false) : base(
            )
        {
            _dbCtx = dbCtx;
            _mapper = mapper;
            _primaryKeyName = primaryKeyName;
            _dbSet = _dbCtx.Set<TEntity>();
            _isIdiomEntity = isIdiomEntity;
        }

        protected DbSet<TEntity> _dbSet { get; set; }

        [HttpPost(Name = "CreateCrud")]

        public ActionResult<TEntity> CreateCrud(TEntityDto input)
        {
            var entity = _mapper.Map<TEntity>(input);
            _dbSet.AddAsync(entity).GetAwaiter().GetResult();
            _dbCtx.SaveChanges();

            var valueId = input?.GetPropValue(_primaryKeyName);
            var id = valueId != null ? (int)valueId : 0;

            var expr = TypeExtension.GetExpresion<TEntity>(id, _primaryKeyName);
            var output = _mapper.Map<TEntityDto>(_dbSet.Where(expr).FirstOrDefault());
            return Ok(output);
        }

        [HttpDelete("{id}", Name = "DeleteCrud")]
        public IActionResult DeleteCrud(int id)
        {
            var expr = TypeExtension.GetExpresion<TEntity>(id, _primaryKeyName);
            var res = _dbSet.Where(expr).FirstOrDefault();

            if(res == null)
                return NotFound();

            _dbCtx.Remove(res);
            _dbCtx.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}", Name = "GetCrud")]
        public ActionResult<TEntityDto> GetCrud(int id)
        {
            var expr = TypeExtension.GetExpresion<TEntity>(id, _primaryKeyName);
            IQueryable<TEntity> query = _dbSet.Where(expr);
            query = _isIdiomEntity ? query.Include($"{typeof(TEntity).Name}_Idioma") : query;
            var res = query.FirstOrDefault();

            if(res == null)
                return NotFound();
            else
                return Ok(_mapper.Map<TEntityDto>(res));
        }


        [HttpGet(Name = "GetDataCrud")]
        public ActionResult<TEntityDto> GetDataCrud()
        {
            try
            {
                IQueryable<TEntity> query = _dbSet;
                string idiomEntity = $"{typeof(TEntity).Name}_Idioma";
                query = query.Include(idiomEntity);

                return Ok(query.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                return Ok();
            }

        }


        [HttpPatch("{id}", Name = "UpdateDoc")]
        public ActionResult<TEntityDto> UpdateCrud([FromRoute] int id, [FromBody] JsonPatchDocument patchDoc)
        {
            var expr = TypeExtension.GetExpresion<TEntity>(id, _primaryKeyName);
            IQueryable<TEntity> query = _dbSet.Where(expr);
            query = _isIdiomEntity ? query.Include($"{typeof(TEntity).Name}_Idioma") : query;
            var res = query.FirstOrDefault();

            if(res == null)
                return NotFound();

            patchDoc.ApplyTo(res);
            _dbCtx.SaveChanges();

            return Ok(_mapper.Map<TEntityDto>(res));
        }
    }
}
