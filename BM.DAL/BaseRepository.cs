using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BM.IDAL;
using BM.Models;

namespace BM.DAL
{
    public class BaseRepository<K> : IRepository<K> where K : class
    {
        /// <summary>
        /// 实例化数据库实例
        /// </summary>
        public BlogEntities ce;

        public BaseRepository()
        {
            ce = new BlogEntities();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(K model)
        {
            ce.Set<K>().Add(model);
            return ce.SaveChanges();
        }
        /// <summary>
        /// 添加并返回id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public K AddReturnID(K model)
        {
            ce.Set<K>().Add(model);
            ce.SaveChanges();
            return model;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fuc"></param>
        /// <returns></returns>
        public int Remove(Func<K, bool> fuc)
        {

            var model = ce.Set<K>().Where(fuc).FirstOrDefault();
            ce.Entry<K>(model).State = EntityState.Deleted;
            return ce.SaveChanges();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(K model)
        {

            ce.Entry<K>(model).State = EntityState.Modified;
            return ce.SaveChanges();
        }

        /// <summary>
        /// 获得全部
        /// </summary>
        /// <returns></returns>
        public List<K> GetAll()
        {

            return ce.Set<K>().ToList();
        }
        /// <summary>
        /// 根据条件获得列表
        /// </summary>
        /// <param name="func"></param>
        /// <param name="order">降序排序规则</param>
        /// <returns></returns>
        public List<K> Getlist(Func<K, bool> func, Func<K, object> order)
        {
            if (order != null)
            {
                return ce.Set<K>().Where(func).OrderByDescending(order).ToList();
            }
            else
            {
                return ce.Set<K>().Where(func).ToList();
            }
        }

        /// <summary>
        /// 根据条件获取
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public K Get(Func<K, bool> func)
        {
            return ce.Set<K>().AsNoTracking().Where(func).FirstOrDefault();
        }
    }
}
