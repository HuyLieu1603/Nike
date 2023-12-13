using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nike.Models;

namespace Nike.DesignPattern
{
	public class ProductSort
	{
		private static IProductSort tempSort;

		public static IEnumerable<Product> Ascending(IEnumerable<Product> products)
		{
			tempSort = new SortAscending();
			return tempSort.Sort(products);
		}

		public static IEnumerable<Product> Descending(IEnumerable<Product> products)
		{
			tempSort = new SortDescending();
			return tempSort.Sort(products);
		}

		public interface IProductSort
		{
			IEnumerable<Product> Sort(IEnumerable<Product> products);
		}

		public class SortAscending : IProductSort
		{
			public IEnumerable<Product> Sort(IEnumerable<Product> products)
			{
				return products.OrderBy(p => p.UnitPrice);
			}
		}

		public class SortDescending : IProductSort
		{
			public IEnumerable<Product> Sort(IEnumerable<Product> products)
			{
				return products.OrderByDescending(p => p.UnitPrice);
			}
		}
	}
}