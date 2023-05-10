using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.App.Infra.Data.Contexts;
using UsuariosApp.Domain.Interfaces.Repositorios;

namespace Usuarios.App.Infra.Data.Repositories
{
    public abstract class BaseRepository<TModel, TKey> : IBaseRepository<TModel, TKey>
        where TModel : class
    {
        private readonly DataContext _dateContext;

        protected BaseRepository(DataContext dateContext)
        {
            _dateContext = dateContext;
        }

        public virtual void Add(TModel model)
        {
            _dateContext?.Add(model);
        }

        public virtual void Delete(TModel model)
        {
            _dateContext.Remove(model);
        }

        public virtual void Update(TModel model)
        {
            _dateContext?.Update(model);
        }


        public virtual List<TModel> GetAll()
        {
            return _dateContext?.Set<TModel>().ToList();
        }

        public virtual List<TModel> GetAll(Func<TModel, bool> where)
        {
            return _dateContext?.Set<TModel>().Where(where).ToList();
        }
        public virtual TModel Get(Func<TModel, bool> where)
        {
            return _dateContext?.Set<TModel>().FirstOrDefault(where);
        }

        public virtual TModel GetById(TKey id)
        {
            return _dateContext?.Set<TModel>().Find(id);
        }

        public virtual void Dispose()
        {
            _dateContext.Dispose();
        }
    }
}
