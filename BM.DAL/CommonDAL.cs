using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.IDAL;
using System.Data.SqlClient;

namespace BM.DAL
{
    /// <summary>
    /// 公共DAL类，该类包含分页、单表保存、单表修改、单表查询
    /// </summary>
    /// <create>zg 2015/02/05</create>
    public class CommonDAL<K> : BaseRepository<K>, ICommonDAL<K> where K : class
    {
        /// <summary>
        /// 根据条件分页
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="nextPage">下一页</param>
        /// <param name="pageRowCount">每页行数</param>
        /// <param name="order">排序条件</param>
        /// <returns>list</returns>
        public List<K> pageByWhere(Func<K, bool> where, int nextPage, int pageRowCount, Func<K,object> order)
        {
            try
            {
                return Getlist(where,order).Skip((nextPage - 1) * pageRowCount).Take(pageRowCount).ToList();
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }
        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="order">排序条件</param>
        /// <returns></returns>
        public int getPageCount(Func<K,bool> where)
        {
            try
            {
                return Getlist(where,null).Count();
            }
            catch (Exception e)
            {
                return -1;
                throw e;
            }
        }
        /// <summary>
        /// 单表保存
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>int</returns>
        public int Save(K model)
        {
            try
            {
                return Add(model);
            }
            catch (Exception e)
            {
                return 0;
                throw e;
            }
        }
        /// <summary>
        /// 单表修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>int</returns>
        public int Edit(K model)
        {
            try
            {
                return Update(model);
            }
            catch (Exception e)
            {
                return 0;
                throw e;
            }
        }
        /// <summary>
        /// 单表查询
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns>K</returns>
        public K getModel(Func<K, bool> func)
        {
            try
            {
                return Get(func);
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns></returns>
        public List<K> getList(Func<K, bool> func)
        {
            return Getlist(func,null);
        }

        /// <summary>
        /// 操作存储过程
        /// </summary>
        /// <param name="para">参数数组</param>
        /// <returns></returns>
        public System.Data.DataSet Pro(string[] para)
        {
            throw new NotImplementedException();
        }
    }
}
