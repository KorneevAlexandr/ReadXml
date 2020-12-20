using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryFigurs;

namespace ParsingFiles
{
    /// <summary>
    /// class with fabric method
    /// </summary>
    public class Fabrica
    {
        /// <summary>
        /// fabric method
        /// </summary>
        /// <param name="type">type figure</param>
        /// <param name="material">type material figure</param>
        /// <param name="side">size figure</param>
        /// <returns>object necessary type</returns>
        public Figura FabricObject(string type, string material, string side)
        {
            Figura figura = null;
            double[] value = side.Split(' ').Select(x => double.Parse(x)).ToArray();

            switch (type)
            {
                case "Circle":
                    figura = new Circle(value[0]) { TypeMaterial = material };
                    break;
                case "Quadrate":
                    figura = new Quadrate(value[0]) { TypeMaterial = material };
                    break;
                case "Triangle":
                    figura = new Triangle(value[0]) { TypeMaterial = material };
                    break;
                default:
                    throw new Exception("Неверно заданы параметры фигуры");
            }
            return figura;
        }
    }
}