using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BM.BLL;
using BM.DAL;
using BM.IBLL;
using BM.IDAL;
using Microsoft.Practices.Unity;
using BM.Models;
using System.Reflection;

namespace BM.Core
{
    public class DependencyRegisterType
    {
        //注入所需的对象
        //在每次新添加一个IBLL、BLL、IDAL、DAL时需要在此添加两行注入代码，代码格式如下：
        //container.RegisterType<DAL接口<实体类型>, 接口实现<实体类型>>();
        //container.RegisterType<BLL接口<实体类型>, 接口实现<实体类型>>();
        //注意:
        //1、如果不需要注入，请不要在这里写入注入代码，同时在调用的位置请不要实例化IDAL或者IBLL，以免产生不必要的麻烦
        //2、ICommonDAL、CommonDAL、ICommonBLL、CommonBLL是公共接口/类，所以如果其他类或页面中存在调用公共累的地方也需要，在此注册，注册格式如下：
        //    container.RegisterType<ICommonDAL<调用处返回值的实体类型>, CommonDAL<调用处返回值的实体类型>>();
        //    container.RegisterType<ICommonBLL<调用处返回值的实体类型>, CommonBLL<调用处返回值的实体类型>>();
        public static void Container_Sys(ref UnityContainer container)
        {
            //错误日志注入
            container.RegisterType<ICommonDAL<tb_error>, CommonDAL<tb_error>>();
            container.RegisterType<ICommonBLL<tb_error>, CommonBLL<tb_error>>();
            //操作日志注入
            container.RegisterType<ICommonDAL<tb_OperateLog>, CommonDAL<tb_OperateLog>>();
            container.RegisterType<ICommonBLL<tb_OperateLog>, CommonBLL<tb_OperateLog>>();
            //敏感词汇注入
            container.RegisterType<ICommonDAL<tb_SensitiveWord>, CommonDAL<tb_SensitiveWord>>();
            container.RegisterType<ICommonBLL<tb_SensitiveWord>, CommonBLL<tb_SensitiveWord>>();
            //用户信息注入
            container.RegisterType<ICommonDAL<tb_Users>, CommonDAL<tb_Users>>();
            container.RegisterType<ICommonBLL<tb_Users>, CommonBLL<tb_Users>>();
        }
    }
}
