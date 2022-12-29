using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace CTS.BAL.Services
{
    public class ConvertToXML
    {
        public string GetXMLForSave(object _Obj)
        {
            XmlDocument _xmldoc = new XmlDocument();
            XmlSerializer _XmlSerializer = new XmlSerializer(_Obj.GetType());

            using (MemoryStream _MemoryStream = new MemoryStream())
            {
                _XmlSerializer.Serialize(_MemoryStream, _Obj);
                _MemoryStream.Position = 0;
                _xmldoc.Load(_MemoryStream);
                return _xmldoc.InnerXml;
            }

        }
    }
}
