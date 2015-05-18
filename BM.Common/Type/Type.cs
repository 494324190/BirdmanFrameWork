using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Common.Type
{
    public class Type<K>
    {
        public K k;
        public Type(K k)
        {
            this.k = k;
        }
        /// <summary>
        /// 获取类型属性名
        /// </summary>
        /// <returns></returns>
        public ArrayList GetAtrribute()
        {
            ArrayList at = new ArrayList();
            foreach (var item in k.GetType().GetProperties())
            {
                at.Add(item.Name);
            }
            return at;
        }
        /// <summary>
        /// 获取类型名称
        /// </summary>
        /// <returns></returns>
        public string GetClassName()
        {
            return k.GetType().Name;
        }
    }
}
