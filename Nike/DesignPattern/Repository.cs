using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Nike.Models;

namespace Nike.DesignPattern
{
	public class Repository<T> where T : class
	{
		private readonly QuanLySanPhamEntities db = DbContextSingleton.GetInstance();

		public T Find(int id)
		{
			return db.Set<T>().Find(id);
		}

		public IEnumerable<T> GetAll(Func<T, bool> filter = null)
		{
			var query = db.Set<T>();

			if (filter != null)
			{
				query.Where(filter);
			}

			return query;
		}

		public void Add(T entity)
		{
			db.Set<T>().Add(entity);
		}

		public void Update(T entity)
		{
			db.Entry(entity).State = EntityState.Modified;
		}

		public void Delete(T entity)
		{
			db.Set<T>().Remove(entity);
		}

		public void Save()
		{
			db.SaveChanges();
		}
	}
}