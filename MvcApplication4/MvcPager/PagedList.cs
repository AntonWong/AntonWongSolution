using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CYP.Common.MvcPager
{
	/// <summary>
	///		分页类
	/// </summary>
	/// <typeparam name="T"></typeparam>
    public class PagedList<T> : List<T>, IPagedList
    {
		/// <summary>
		///		初始化设置页码、显示数
		/// </summary>
		/// <param name="pageIndex">页码</param>
		/// <param name="pageSize">每页显示数</param>
        public PagedList(int pageIndex, int pageSize)
        {
			CurrentPageIndex = pageIndex;
			PageSize = pageSize;
        }
		/// <summary>
		///		初始化设置集合对象、页码、显示数
		/// </summary>
		/// <param name="items">集合对象</param>
		/// <param name="pageIndex">页码</param>
		/// <param name="pageSize">每页显示数</param>
        public PagedList(IList<T> items, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            TotalItemCount = items.Count;
            CurrentPageIndex = pageIndex;
            for (int i = StartRecordIndex - 1; i < EndRecordIndex; i++)
            {
                Add(items[i]);
            }
        }

		/// <summary>
		///		初始化设置集合对象、页码、显示数、总数量
		/// </summary>
		/// <param name="items"></param>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <param name="totalItemCount"></param>
        public PagedList(IEnumerable<T> items, int pageIndex, int pageSize, int totalItemCount)
        {
            AddRange(items);
            TotalItemCount = totalItemCount;
            CurrentPageIndex = pageIndex;
            PageSize = pageSize;
        }


        /// <summary>
		///	页码
        /// </summary>
        public int CurrentPageIndex { get; set; }

		/// <summary>
		/// 每页显示数
		/// </summary>
        public int PageSize { get; set; }

		/// <summary>
		/// 总数量
		/// </summary>
        public int TotalItemCount { get; set; }

		/// <summary>
		/// 总页数
		/// </summary>
        public int TotalPageCount { get { return (int)Math.Ceiling(TotalItemCount / (double)PageSize); } }

		/// <summary>
		/// 
		/// </summary>
        public int StartRecordIndex { get { return (CurrentPageIndex - 1) * PageSize + 1; } }

		/// <summary>
		/// 
		/// </summary>
        public int EndRecordIndex { get { return TotalItemCount > CurrentPageIndex * PageSize ? CurrentPageIndex * PageSize : TotalItemCount; } }
    }
}
