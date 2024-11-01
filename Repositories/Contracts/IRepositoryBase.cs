using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>  //Genelde CRUD işlemleri yani create read update delete işlemlerini burda yaparız
    {
        IQueryable<T> FindAll(bool trackChanges);    // Veri getirmek için metod
        T? FindByCondition(Expression<Func<T, bool>> expression,bool trackChanges);

        void Create(T entity);

        void Remove(T entity);


    }
}
