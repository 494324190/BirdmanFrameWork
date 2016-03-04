using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.IDAL
{
    /// <summary>
    /// 公共IDAL接口，该接口包含分页、获取总页数、单表保存、单表修改、单表查询
    /// </summary>
    /// <create>zg 2015/02/05</create>
    /// <typeparam name="K">实体类型</typeparam>
    public interface ICommonDAL<K>
    {
        /// <summary>
        /// 根据条件分页
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="nextPage">下一页</param>
        /// <param name="pageRowCount">每页行数</param>
        /// <param name="order">排序条件</param>
        /// <returns>list</returns>
        List<K> pageByWhere(Func<K, bool> where, int nextPage, int pageRowCount, Func<K, object> order, out int pageTatol);
        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        int getPageCount(Func<K, bool> where);
        /// <summary>
        /// 单表保存
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>int</returns>
        int Save(K model);
        /// <summary>
        /// 单表修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>int</returns>
        int Edit(K model);
        /// <summary>
        /// 单表查询
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns>K</returns>
        K getModel(Func<K, bool> func);
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns></returns>
        List<K> getList(Func<K, bool> func);
    }
}
