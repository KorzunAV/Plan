using System.Collections.Generic;

namespace Common.Data.Core
{
	public class Page<T> where T : class
	{
		private const int DefltPage = 1;
		private const int DefltPageSize = 10;

		public Page()
			: this(DefltPageSize)
		{
		}

		public Page(int itemPerPage)
			: this(itemPerPage, DefltPage)
		{
		}

		public Page(int itemPerPage, int currentPage)
		{
			ItemPerPage = itemPerPage;
			CurrentPage = currentPage;
		}

		public int StartIndex
		{
			get { return (CurrentPage - 1)*ItemPerPage; }
		}

		public int EndIndex
		{
			get { return (CurrentPage)*ItemPerPage; }
		}

		public bool EnableNext
		{
			get { return EndIndex <= MaxIndex; }
		}

		public bool EnablePrev
		{
			get { return StartIndex > 1; }
		}

		public int MaxIndex { get; set; }

		public int ItemPerPage { get; set; }

		public int CurrentPage { get; set; }

		public IEnumerable<T> Items { get; set; }
	}
}