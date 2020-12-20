using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFigurs
{
	/// <summary>
	/// Class for description triangle, inheritor Figura
	/// </summary>
	public class Triangle : Figura
	{
		/// <summary>
		/// side length of a triangle
		/// </summary>
		internal double len { get; }

		/// <summary>
		/// cutting a triangle from a quadrate, 
		/// if this triangle can be written off to a quadrate
		/// </summary>
		/// <param name="figura">The figure from which it is cut</param>
		/// <param name="radius">side new figura</param>
		public Triangle(Quadrate figura, double len)
		{
			if (len > figura.len)
			{
				throw new Exception("Вырезать данную фигуру невозможно!");
			}
			TypeMaterial = figura.TypeMaterial;
			Color = figura.Color;
			this.len = len;
		}


		/// <summary>
		/// cutting a triangle from a circle, 
		/// if this triangle can be written off to a circle
		/// </summary>
		/// <param name="figura">The figure from which it is cut</param>
		/// <param name="radius">side new figura</param>
		public Triangle(Circle figura, double len)
		{
			if (len / Math.Sqrt(3) > figura.radius)
			{
				throw new Exception("Вырезать данную фигуру невозможно!");
			}
			TypeMaterial = figura.TypeMaterial;
			Color = figura.Color;
			this.len = len;
		}

		/// <summary>
		/// initializing the dimensions of the shape
		/// </summary>
		/// <param name="radius">side figura</param>
		public Triangle(double len)
		{
			this.len = len;
		}

		/// <summary>
		/// method for access to side
		/// </summary>
		/// <returns>side</returns>
		public override double Side()
		{
			return Math.Round(len, 0);
		}

		/// <summary>
		/// calculate square
		/// </summary>
		/// <returns>square</returns>
		public override double Square()
		{
			return Math.Round( Math.Sqrt(3) / 4 * len * len, 2);
		}

		/// <summary>
		/// calculate perimetr
		/// </summary>
		/// <returns>perimetr</returns>
		public override double Perimetr()
		{
			return len * 3;
		}

		/// <summary>
		/// redefinition ToString()
		/// </summary>
		/// <returns>strok about figura</returns>
		public override string ToString()
		{
			string Fcolor = Color.ToString();
			if ((int)Color == 0)
				Fcolor = "Colorless";
			return String.Format("Figura: {0}; Material: {1}; Color: {2}.", "Triangle", TypeMaterial, Fcolor);
		}

		/// <summary>
		/// redefinition Equals
		/// comparison of two objects
		/// </summary>
		/// <param name="obj">object for comparison</param>
		/// <returns>true - if same, else - false</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			Triangle F = obj as Triangle;
			if (F as Triangle == null)
				return false;

			if (TypeMaterial != F.TypeMaterial || Color != F.Color || len != F.len)
				return false;

			return true;
		}

		/// <summary>
		/// Hash-method
		/// </summary>
		/// <returns>integer color value</returns>
		public override int GetHashCode()
		{
			return (int)Color;
		}

	}
}
