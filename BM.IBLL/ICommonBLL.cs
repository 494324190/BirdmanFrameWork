using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.IBLL
{
    /// <summary>
    /// 公共IBLL接口，该接口包含分页、获取总页数、单表保存、单表修改、单表查询
    /// </summary>
    /// <create>zg 2015/02/05</create>
    /// <typeparam name="K">实体类型</typeparam>
    /// <creat>zg 2015/02/05</creat>
    public interface ICommonBLL<K>
    {
        /// <summary>
        /// 根据条件分页
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="nextPage">下一页（默认值1）</param>
        /// <param name="pageRowCount">每页行数（默认值10）</param>
        /// <returns>list</returns>
        List<K> pageByWhere(Func<K, bool> where, Func<K,object> order, int nextPage = 1, int pageRowCount = 10);
        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>bool</returns>
        int getPageCount(Func<K, bool> where);
        /// <summary>
        /// 单表保存
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>bool</returns>
        bool Save(K model);
        /// <summary>
        /// 单表修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>int</returns>
        bool Edit(K model);
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
        /// <returns>List<K></returns>
        List<K> getList(Func<K, bool> func);
    }
}
