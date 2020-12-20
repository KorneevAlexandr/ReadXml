using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LibraryFigurs;
using System.Reflection;

namespace ParsingFiles
{
	/// <summary>
	/// Class for write figure in gile
	/// </summary>
	public class WriteInFile
	{
		/// <summary>
		/// name file for writting
		/// </summary>
		private string filename;

		/// <summary>
		/// default constructor (with default file)
		/// </summary>
		public WriteInFile()
		{
			filename = "XMLFile3.xml";
		}

		/// <summary>
		/// constructor for other file
		/// </summary>
		/// <param name="FileName">name other file</param>
		public WriteInFile(string FileName)
		{
			filename = FileName;
		}

		/// <summary>
		/// allows you to choose the type of material so 
		/// that you can record the figures of only the required material
		/// by default all shapes are recorded
		/// </summary>
		/// <param name="Box">list object (box with figures)</param>
		/// <param name="TypeMaterial">type material figure</param>
		public void WriteFile(List<Figura> Box, string TypeMaterial = "")
		{
			XmlWriter xmlWriter = XmlWriter.Create(filename);

			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("Figurs");

			for (int i = 0; i < Box.Count; i++)
			{
				if (TypeMaterial.Equals("") || Box[i].TypeMaterial.Equals(TypeMaterial))
				{
					xmlWriter.WriteStartElement("figura");
					xmlWriter.WriteAttributeString("Type", Box[i].GetType().ToString().Split('.')[1]);
					xmlWriter.WriteAttributeString("Material", Box[i].TypeMaterial);
					xmlWriter.WriteAttributeString("Side", Box[i].Side().ToString());
					xmlWriter.WriteEndElement();
				}
			}

			xmlWriter.WriteEndDocument();
			xmlWriter.Close();
		}
	}
}
