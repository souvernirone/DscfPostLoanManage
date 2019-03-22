using Dscf.Common.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Common.Manager.Implement
{
    public abstract class GenericManagerBase<TEntity> : IGenericManager<TEntity> where TEntity : class
    {
        public IRepository<TEntity> CurrentRepository { get; set; }

        #region 公共方法
        /// <summary>
        ///     获取 当前实体的查询数据集
        /// </summary>
        public virtual DbSet<TEntity> Entities
        {
            get { return CurrentRepository.Entities; }
        }

        /// <summary>
        ///     插入实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Insert(TEntity entity, bool isSave = true)
        {
            return CurrentRepository.Insert(entity, isSave);
        }

        public virtual int Insert(IEnumerable<TEntity> entities, bool isSave = true)
        {
            return CurrentRepository.Insert(entities, isSave);
        }

        public virtual int Delete(object id, bool isSave = true)
        {
            return CurrentRepository.Delete(id, isSave);
        }

        public virtual int Delete(TEntity entity, bool isSave = true)
        {
            return CurrentRepository.Delete(entity, isSave);
        }

        public virtual int Delete(IEnumerable<TEntity> entities, bool isSave = true)
        {
            return CurrentRepository.Delete(entities, isSave);
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> predicate, bool isSave = true)
        {
            return CurrentRepository.Delete(predicate, isSave);
        }

        public virtual int Update(TEntity entity, bool isSave = true)
        {
            return CurrentRepository.Update(entity, isSave);
        }

        public virtual TEntity GetByKey(object key)
        {
            return CurrentRepository.GetByKey(key);
        }

        #endregion

        #region 原子操作方法
        public int Commit()
        {
            return CurrentRepository.UnitOfWork.Commit();

        }


        /// <summary>
        ///     把当前单元操作回滚成未提交状态
        /// </summary>
        public void Rollback()
        {
            CurrentRepository.UnitOfWork.Rollback();

        }

        #endregion

    }
}
