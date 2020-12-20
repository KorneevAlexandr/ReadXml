using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryFigurs;
using ParsingFiles;

namespace TestingProject
{
	/// <summary>
	/// Class for testing figures
	/// </summary>
	[TestClass]
	public class TestingFigures
	{
		/// <summary>
		/// testing create and compate to string figures
		/// </summary>
		[TestMethod]
		public void Testing_Create_Figurs()
		{
			Figura fig = new Circle(10) { TypeMaterial = "Paper" };
			Circle circle = new Circle(10) { TypeMaterial = "Paper" };

			var expected = true;
			var actual = fig.Equals(circle);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// testing cut figures
		/// </summary>
		[TestMethod]
		public void Testing_Cut_Circle_Of_Triangle()
		{
			Triangle triangle = new Triangle(10) { TypeMaterial = "Paper" };
			var res = new Circle(2) { TypeMaterial = "Paper" };
			var expected = res.ToString();

			var have = new Circle(triangle, 2);
			var actual = have.ToString();

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// testing cut and painted
		/// </summary>
		[TestMethod]
		public void Testing_Painted_And_Cut_Figura()
		{
			Quadrate quadrate = new Quadrate(400) { TypeMaterial = "Plastic" };
			quadrate.Color = Color.Brown;

			Circle circle = new Circle(quadrate, 50);
			Triangle triangle = new Triangle(circle, 2);

			var expected = Color.Brown;
			var actual = triangle.Color;

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// testing calculate square
		/// </summary>
		[TestMethod]
		public void Testing_Square_Triangle()
		{
			Triangle triangle = new Triangle(2) { TypeMaterial = "Plastic" };
			var expected = 1.73;

			var actual = triangle.Square();

			Assert.AreEqual(expected, actual);
		}
		/// <summary>
		/// testing calculate square
		/// </summary>
		[TestMethod]
		public void Testing_Square_Circle()
		{
			Circle circle = new Circle(10) { TypeMaterial = "Plastic" };
			var expected = 314.16;

			var actual = circle.Square();

			Assert.AreEqual(expected, actual);
		}
		/// <summary>
		/// testing calculate square
		/// </summary>
		[TestMethod]
		public void Testing_Square_Quadrate()
		{
			Quadrate quadrate = new Quadrate(3) { TypeMaterial = "Plastic" };
			var expected = 9;

			var actual = quadrate.Square();

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// testing calculate square (circle)
		/// </summary>
		[TestMethod]
		public void Testing_Perimetr()
		{
			Circle c = new Circle(10) { TypeMaterial = "Paper" };

			var expected = 62.83;
			var actual = c.Perimetr();

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// testing get size figures
		/// </summary>
		[TestMethod]
		public void Testing_Access_Private_Side()
		{
			Figura fig = new Triangle(12) { TypeMaterial = "Plastic" };

			var expected = 12;
			var actual = fig.Side();

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// testing override method Equals
		/// </summary>
		[TestMethod]
		public void Testing_Equals()
		{
			Figura trig = new Triangle(10) { TypeMaterial = "Paper" };
			Figura circ = new Circle(2) { TypeMaterial = "Paper" };
			Figura cut = new Circle((Triangle)trig, 2);

			cut = (Circle)cut;
			circ = (Circle)cut;

			var expected = true;
			var actual = circ.Equals(cut);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// testing override method Equals
		/// </summary>
		[TestMethod]
		public void Testing_Equals_False()
		{
			Figura trig = new Triangle(10) { TypeMaterial = "Paper" };
			Figura circ = new Circle(2) { TypeMaterial = "Plastic" };

			var expected = false;
			var actual = circ.Equals(trig);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// testing override method ToString
		/// </summary>
		[TestMethod]
		public void Testing_ToString()
		{
			Figura trig = new Triangle(10) { TypeMaterial = "Plastic" };
			trig.Color = Color.Green;

			var expected = "Figura: Triangle; Material: Plastic; Color: Green.";
			var actual = trig.ToString();

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// testing override method GetHashCode
		/// </summary>
		[TestMethod]
		public void Testing_GetHashCode()
		{
			Figura trig = new Triangle(10) { TypeMaterial = "Plastic" };
			trig.Color = Color.Pink;

			var expected = 9;
			var actual = trig.GetHashCode();

			Assert.AreEqual(expected, actual);
		}

	}
}
