using BM.BLL;
using BM.DAL;
using BM.IBLL;
using BM.IDAL;
using Microsoft.Practices.Unity;
using BM.Models;
namespace BM.Core
{
    public class DependencyRegisterType
    {
		//-------------------------------------------------
		//该内容由T4模板生成
		//-------------------------------------------------

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
									container.RegisterType<ICommonDAL<tb_Article>, CommonDAL<tb_Article>>();
				container.RegisterType<ICommonBLL<tb_Article>, CommonBLL<tb_Article>>();
									container.RegisterType<ICommonDAL<tb_ArticleClassification>, CommonDAL<tb_ArticleClassification>>();
				container.RegisterType<ICommonBLL<tb_ArticleClassification>, CommonBLL<tb_ArticleClassification>>();
									container.RegisterType<ICommonDAL<tb_ErrorLog>, CommonDAL<tb_ErrorLog>>();
				container.RegisterType<ICommonBLL<tb_ErrorLog>, CommonBLL<tb_ErrorLog>>();
									container.RegisterType<ICommonDAL<tb_OperateLog>, CommonDAL<tb_OperateLog>>();
				container.RegisterType<ICommonBLL<tb_OperateLog>, CommonBLL<tb_OperateLog>>();
									container.RegisterType<ICommonDAL<tb_SensitiveWord>, CommonDAL<tb_SensitiveWord>>();
				container.RegisterType<ICommonBLL<tb_SensitiveWord>, CommonBLL<tb_SensitiveWord>>();
					        }
    }
}
