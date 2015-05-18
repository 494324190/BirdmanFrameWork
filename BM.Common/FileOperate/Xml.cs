using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BM.Common.FileOperate
{
    public static class Xml
    {
        /// <summary>
        /// 读取XML文件或者指定属性值集合
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="nodeName">读取节点集合的根节点的名称，*代表获取全部节点的值</param>
        /// <param name="type">获取的类型：1：属性值  2：节点的文本值</param>
        /// <param name="typeName">要获取属性或节点的名称</param>
        /// <returns>List<string></returns>
        public static List<string> Read(string path, string nodeName, int type, string typeName)
        {
            List<string> sub = new List<string> { }; ;
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement rootElem = doc.DocumentElement;
            XmlNodeList childNodes = rootElem.GetElementsByTagName(nodeName);
            if (type == 1)
            {
                for (int i = 0; i < childNodes.Count; i++)
                {
                    sub.Add(((XmlElement)childNodes.Item(i)).GetAttribute(typeName));
                }
            }
            else
            {
                for (int i = 0; i < childNodes.Count; i++)
                {
                    sub.Add(childNodes.Item(i).InnerText);
                }
            }

            return sub;
        }
        /// <summary>
        /// 生成一个只有根节点的XML文件（注：如果要创建完整文件，请调用完该方法后再调用Insert方法进行创建）
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="RootName">根节点名称，默认为root</param>
        public static void Write(string path, string RootName = "root")
        {
            XmlDocument doc = new XmlDocument();
            XmlElement Root = doc.CreateElement(RootName);
            doc.AppendChild(Root);
            doc.Save(path);
        }
        /// <summary>
        /// 新增XML节点
        /// </summary>
        /// <param name="path">XML文件路径</param>
        /// <param name="InsertNodeFather">插入的位置，即父节点的名称</param>
        /// <param name="CreateNode">创建的节点的名称</param>
        /// <param name="Attributes">节点的属性</param>
        /// <param name="Node">创建的的子节点名称和内容</param>
        public static void Insert(string path, string InsertNodeFather, string CreateNode, string[,] Attributes = null, string[,] Node = null)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNode root = xmlDoc.SelectSingleNode(InsertNodeFather);//查找RootName
            XmlElement xe1 = xmlDoc.CreateElement(CreateNode);//创建一个CreateNode节点
            for (int i = 0; i < Attributes.Rank; i++)
            {
                for (int j = 0; j < Attributes.Rank; j++)
                {
                    if (j == 1)
                    {
                        continue;
                    }
                    xe1.SetAttribute(Attributes[i, j], Attributes[i, j + 1]);//设置该节点属性
                }
            }

            for (int i = 0; i < Attributes.Rank; i++)
            {
                for (int j = 0; j < Attributes.Rank; j++)
                {
                    if (j == 1)
                    {
                        continue;
                    }
                    XmlElement xesub1 = xmlDoc.CreateElement(Attributes[i, j]);
                    xesub1.InnerText = Attributes[i, j + 1];
                    xe1.AppendChild(xesub1);
                    root.AppendChild(xe1);

                }
            }
            xmlDoc.Save(path);

        }
        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="DeleteNodeFather">要删除节点的父节点</param>
        /// <param name="DeleteNode">要删除的节点</param>
        /// <param name="para">删除参数</param>
        public static void Delete(string path,string DeleteNodeFather,string DeleteNode,string para=null)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(path);
            XmlNode xnRoot = xmldoc.SelectSingleNode(DeleteNodeFather);
            XmlNodeList nodelist = xnRoot.ChildNodes;

            foreach (XmlNode node in nodelist)
            {
               
                if (node.SelectSingleNode(DeleteNode).InnerXml == para)
                {
                    xnRoot.RemoveChild(node);

                }
            }
            xmldoc.Save(path);
        }
    }
}
