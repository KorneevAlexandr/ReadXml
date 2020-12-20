using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFigurs
{
	/// <summary>
	/// Class for description circles, inheritor Figura
	/// </summary>
	public class Circle : Figura
	{
		/// <summary>
		/// radius circle
		/// </summary>
		internal double radius { get; }

		/// <summary>
		/// cutting a circle from a quadrate, 
		/// if this circle can be written off to a quadrate
		/// </summary>
		/// <param name="figura">The figure from which it is cut</param>
		/// <param name="radius">side new figura</param>
		public Circle(Quadrate figura, double radius)
		{
			if (2 * radius > figura.len)
			{
				throw new Exception("Вырезать данную фигуру невозможно!");
			}
			TypeMaterial = figura.TypeMaterial;
			Color = figura.Color;
			this.radius = radius;
		}

		/// <summary>
		/// cutting a circle from a triangle, 
		/// if this circle can be written off to a triangle
		/// </summary>
		/// <param name="figura">The figure from which it is cut</param>
		/// <param name="radius">side new figura</param>
		public Circle(Triangle figura, double len)
		{
			if (len > figura.len / (2 * Math.Sqrt(3)))
			{
				throw new Exception("Вырезать данную фигуру невозможно!");
			}
			TypeMaterial = figura.TypeMaterial;
			Color = figura.Color;
			this.radius = radius;
		}

		/// <summary>
		/// initializing the dimensions of the shape
		/// </summary>
		/// <param name="radius">side figura</param>
		public Circle(double radius)
		{
			this.radius = radius;
		}

		/// <summary>
		/// method for access to side
		/// </summary>
		/// <returns>side</returns>
		public override double Side()
		{
			return Math.Round(radius, 0);
		}

		/// <summary>
		/// calculate square
		/// </summary>
		/// <returns>square</returns>
		public override double Square()
		{
			return Math.Round(Math.PI * radius * radius, 2);
		}

		/// <summary>
		/// calculate perimetr
		/// </summary>
		/// <returns>perimetr</returns>
		public override double Perimetr()
		{
			return Math.Round(2 * Math.PI * radius, 2);
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
			return String.Format("Figura: {0}; Material: {1}; Color: {2}.", "Circle", TypeMaterial, Fcolor);
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
			Circle F = obj as Circle;
			if (F as Circle == null)
				return false;

			if (TypeMaterial != F.TypeMaterial || Color != F.Color || radius != F.radius)
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
