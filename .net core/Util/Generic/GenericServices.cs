using Entitys;
using Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Util.Generic
{
    public class GenericServices<TEntity> : IGenericServices<TEntity> where TEntity : BaseEntity
    {

        private readonly DbContexto _dbContexto;

        public GenericServices(DbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbContexto.Set<TEntity>().Add(entity);
            await _dbContexto.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContexto.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            var entity = await _dbContexto.Set<TEntity>().FindAsync(id);
            if (entity == null) throw new NotFoundException($"A entidade {typeof(TEntity)} com o ID {id} não foi encontrada no banco de dados.");
            return entity;
        }

        public async Task<TEntity> UpdateAsync(long id, TEntity entity)
        {
            // Verifica se a entidade existe no banco de dados
            var existingEntity = await _dbContexto.Set<TEntity>().FindAsync(id);
            if (existingEntity == null) throw new NotFoundException($"A entidade {entity} com o ID {id} não foi encontrada no banco de dados.");

            entity.Id = existingEntity.Id;
            entity.UpdateAt = DateTime.UtcNow;

            entity = this.onPrevUpdate(entity);

            _dbContexto.Set<TEntity>().Entry(existingEntity).CurrentValues.SetValues(entity);
            await _dbContexto.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(long id)
        {
            // Verifica se a entidade existe no banco de dados
            var existingEntity = await _dbContexto.Set<TEntity>().FindAsync(id);
            if (existingEntity == null) throw new NotFoundException($"A entidade com o ID {id} não foi encontrada no banco de dados.");

            existingEntity.RemoveAt = DateTime.UtcNow;

            _dbContexto.Set<TEntity>().Entry(existingEntity).CurrentValues.SetValues(existingEntity);
            await _dbContexto.SaveChangesAsync();
            return existingEntity;
        }

        public virtual TEntity onPrevUpdate(TEntity entity) { return entity; }

    }
}