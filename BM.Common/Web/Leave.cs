namespace BM.Common.Web
{
    public class Leave
    {
        public static string Parse(int type)
        {
            string typeName = "";
            switch (type)
            {
                case 0:
                    typeName = "病假";
                    break;
                case 1:
                    typeName = "事假";
                    break;
                case 2:
                    typeName = "丧假";
                    break;
                case 3:
                    typeName = "年假";
                    break;
                case 4:
                    typeName = "婚假";
                    break;
                case 5:
                    typeName = "产假";
                    break;
                case 6:
                    typeName = "其他假";
                    break;
            }
            return typeName;
        }
        /// <summary>
        /// 请假类型
        /// </summary>
        enum LeaveType
        {
            病假 = 0,
            事假 = 1,
            丧假 = 2,
            年假 = 3,
            婚假 = 4,
            产假 = 5,
            其他假 = 6
        }
    }
}