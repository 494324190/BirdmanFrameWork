using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.IBLL;
using BM.IDAL;
using Microsoft.Practices.Unity;

namespace BM.BLL
{
    /// <summary>
    /// 公共BLL接口，该接口包含分页、获取总页数、单表保存、单表修改、单表查询
    /// </summary>
    /// <create>zg 2015/02/05</create>
    /// <typeparam name="K">实体类型</typeparam>
    /// <creat>zg 2015/02/05</creat>
    public class CommonBLL<K> : ICommonBLL<K> where K : class
    {
        [Dependency]
        public ICommonDAL<K> cdal { get; set; }
        /// <summary>
        /// 根据条件分页
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="nextPage">下一页（默认值1）</param>
        /// <param name="pageRowCount">每页行数（默认值10）</param>
        /// <param name="order">排序条件</param>
        /// <returns>list</returns>
        public List<K> pageByWhere(Func<K, bool> where,Func<K,object> order, int nextPage = 1, int pageRowCount = 10)
        {
            try
            {
                if (where != null)
                {
                    return cdal.pageByWhere(where, nextPage, pageRowCount,order);
                }
                else
                {
                    return null;
                }
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
        /// <returns>int</returns>
        public int getPageCount(Func<K, bool> where)
        {
            try
            {
                if(where !=null)
                {
                    return cdal.getPageCount(where);
                }
                else
                {
                    return -1;
                }
            }
            catch(Exception e)
            {
                return -1;
                throw e;
            }
        }
        /// <summary>
        /// 单表保存
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>bool</returns>
        public bool Save(K model)
        {
            try
            {
                if(model !=null)
                {
                    if (cdal.Save(model) > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
                throw e;
            }
        }
        /// <summary>
        /// 单表修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>int</returns>
        public bool Edit(K model)
        {
            try
            {
                if(model !=null)
                {
                    if (cdal.Edit(model) > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
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
                if(func !=null)
                {
                    return cdal.getModel(func);
                }
                return null;
            }
            catch(Exception e)
            {
                return null;
                throw e;
            }
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns>List<K></returns>
        public List<K> getList(Func<K, bool> func)
        {
            return cdal.getList(func);
        }
    }
}
