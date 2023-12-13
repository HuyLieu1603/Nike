using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nike.Models;

namespace Nike.DesignPattern
{
	public class DbContextSingleton
	{
		private static QuanLySanPhamEntities dbInstance;
		private static readonly object lockObject = new object();
		public static QuanLySanPhamEntities GetInstance()
		{
			if (dbInstance == null)
			{
				lock (lockObject)
				{
					if (dbInstance == null)
					{
						dbInstance = new QuanLySanPhamEntities();
					}
				}
			}
			return dbInstance;
		}
	}
}