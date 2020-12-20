using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LibraryFigurs;

namespace ParsingFiles
{
    /// <summary>
    /// Class for parsing xml-files
    /// </summary>
    public class ParsingXML
    {
        /// <summary>
        /// name xml-file
        /// </summary>
        private string filename;

        /// <summary>
        /// default constructor (default file)
        /// </summary>
        public ParsingXML()
        {
            filename = "XMLFile1.xml";
        }

        /// <summary>
        /// constructor for definitions file
        /// </summary>
        /// <param name="FileName">name file</param>
        public ParsingXML(string FileName)
        {
            filename = FileName;
        }

        /// <summary>
        ///  method for parsing file
        /// </summary>
        /// <returns>list objects (box with figures)</returns>
        public List<Figura> ReadFile()
        {
            List<Figura> Box = new List<Figura>();

            int numerous = 0;
            Fabrica fabrica = new Fabrica();
            XmlReader xmlReader = XmlReader.Create(filename);
            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Figura"))
                {
                    if (xmlReader.HasAttributes && numerous < 20)
                    {
                        Box.Add(fabrica.FabricObject(
                            xmlReader.GetAttribute("Type"),
                            xmlReader.GetAttribute("Material"),
                            xmlReader.GetAttribute("Side")));
                        numerous++;
                    }
                    else break;
                }
            }
            return Box;
        }

    }
}