using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace TaoriaTools {
    public static class XmlSerializer {
        /// <summary>
        /// 将对象序列化为xml文件
        /// </summary>
        /// <param name="filePath">保存的地址</param>
        /// <param name="sourceObj">对象</param>
        /// <param name="type">对象类型</param>
        /// <param name="xmlRootName">XML根节点名称</param>
        public static void SaveToXml(string filePath, object sourceObj, Type type, string xmlRootName) {
            if(!string.IsNullOrEmpty( filePath ) && sourceObj != null) {
                type = type != null ? type : sourceObj.GetType();

                using(StreamWriter writer = new StreamWriter( filePath )) {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = string.IsNullOrEmpty( xmlRootName ) ?
                        new System.Xml.Serialization.XmlSerializer( type ) :
                        new System.Xml.Serialization.XmlSerializer( type, new XmlRootAttribute( xmlRootName ) );
                    xmlSerializer.Serialize( writer, sourceObj );
                }
            }
        }
        /// <summary>
        /// 将XML文件序列化为对象
        /// </summary>
        /// <param name="filePath">文件地址</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static object LoadFromXml(string filePath, Type type) {
            object result = null;

            if(File.Exists( filePath )) {
                using(StreamReader reader = new StreamReader( filePath )) {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer( type );
                    result = xmlSerializer.Deserialize( reader );
                }
            }

            return result;
        }
    }
}
