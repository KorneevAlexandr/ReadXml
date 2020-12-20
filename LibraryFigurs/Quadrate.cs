using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFigurs
{
	/// <summary>
	/// Class for description quadrate, inheritor Figura
	/// </summary>
	public class Quadrate : Figura
	{
		/// <summary>
		/// side length of a quadrate
		/// </summary>
		internal double len { get; }

		/// <summary>
		/// cutting a quadrate from a circle, 
		/// if this quadrate can be written off to a circle
		/// </summary>
		/// <param name="figura">The figure from which it is cut</param>
		/// <param name="radius">side new figura</param>
		public Quadrate(Circle figura, double len)
		{
			if ((2 * figura.radius) < len * Math.Sqrt(2))
			{
				throw new Exception("Вырезать данную фигуру невозможно!");
			}
			TypeMaterial = figura.TypeMaterial;
			Color = figura.Color;
			this.len = len;
		}

		/// <summary>
		/// cutting a quadrate from a triangle, 
		/// if this quadrate can be written off to a triangle
		/// </summary>
		/// <param name="figura">The figure from which it is cut</param>
		/// <param name="radius">side new figura</param>
		public Quadrate(Triangle figura, double a)
		{
			double x = (figura.len - a) / 2;
			if (Math.Sqrt(3) * x < a)
			{
				throw new Exception("Вырезать данную фигуру невозможно!");
			}
			TypeMaterial = figura.TypeMaterial;
			Color = figura.Color;
			this.len = a;
		}

		/// <summary>
		/// initializing the dimensions of the shape
		/// </summary>
		/// <param name="radius">side figura</param>
		public Quadrate(double len)
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
			return len * len;
		}

		/// <summary>
		/// calculate perimetr
		/// </summary>
		/// <returns>perimetr</returns>
		public override double Perimetr()
		{
			return len * 4;
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
			return String.Format("Figura: {0}; Material: {1}; Color: {2}.", "Quadrate", TypeMaterial, Fcolor);
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
			Quadrate F = obj as Quadrate;
			if (F as Quadrate == null)
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
