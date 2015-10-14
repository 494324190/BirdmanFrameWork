namespace BM.Common.Web
{
    public class Step
    {
        public static string Parse(int type)
        {
            string typeName = "";
            switch (type)
            {
                case 0:
                    typeName = "直接领导审批";
                    break;
                case 1:
                    typeName = "部门领导审批";
                    break;
                case 2:
                    typeName = "公司领导审批";
                    break;
                case 3:
                    typeName = "人事经理审批";
                    break;
                case 4:
                    typeName = "财务经理审批";
                    break;
            }
            return typeName;
        }
        /// <summary>
        /// 申请流程
        /// </summary>
        enum StepType
        {
            直接领导审批 = 0,
            部门领导审批 = 1,
            公司领导审批 = 2,
            人事经理审批 = 3,
            财务经理审批 = 4
        }
    }
}