using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFigurs
{
    /// <summary>
    /// enumeration for colors
    /// </summary>
    public enum Color : int
    {
        Red = 1,
        Black,
        White,
        Green,
        Blue,
        Yellow,
        Brown,
        Purple,
        Pink,
        Silver
    }

    /// <summary>
    /// abstract class for main description figurs
    /// </summary>
    abstract public class Figura
    {
        /// <summary>
        /// material the figure is made of
        /// </summary>
        public string TypeMaterial { get; set; }
        /// <summary>
        /// color figura
        /// </summary>
        private Color color;

        /// <summary>
        /// get color; painted depending on material
        /// </summary>
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                if (TypeMaterial == "Plastic")
                    color = value;
                else if (TypeMaterial == "Paper" && Convert.ToInt32(color) == 0)
                    color = value;
                else
                    throw new Exception("Данную фигуру нельзя перекрасить!");
            }
        }

        /// <summary>
        /// method for access to private field 
        /// </summary>
        /// <returns>side figura</returns>
        abstract public double Side();

        /// <summary>
        /// abstract method for calculate Square
        /// </summary>
        /// <returns>square</returns>
        abstract public double Square();

        /// <summary>
        /// abstract method for calculate Perimetr
        /// </summary>
        /// <returns>square</returns>
		abstract public double Perimetr();
	}
}

