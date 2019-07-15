using System;
using System.Collections.Generic;
using System.Text;

namespace WebHang.Data
{
    public interface IDataRepositoryCommon<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
