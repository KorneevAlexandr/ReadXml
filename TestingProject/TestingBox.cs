using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryFigurs;
using ParsingFiles;
using System.Collections.Generic;

namespace TestingProject
{
	/// <summary>
	/// a test class for testing methods of working with a box of shapes
	/// </summary>
	[TestClass]
	public class TestingBox
	{
		/// <summary>
		///	checking the work of getting the number of figures in the box	
		/// </summary>
		[TestMethod]
		public void CountBox()
		{
			List<Figura> Box = new List<Figura>();
			Box.Add(new Circle(12) { TypeMaterial = "Film" });
			Box.Add(new Triangle(1.4) { TypeMaterial = "Plastic" });
			Box.Add(new Circle(2) { TypeMaterial = "Paper" });
			Box.Add(new Quadrate(10) { TypeMaterial = "Film" });

			Options opt = new Options(Box);

			var expected = 4;
			var actual = opt.BoxCount;

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// testing the method for getting circles out of the box
		/// </summary>
		[TestMethod]
		public void TakeCircle()
		{
			List<Figura> Box = new List<Figura>();
			Box.Add(new Circle(12) { TypeMaterial = "Film" });
			Box.Add(new Triangle(1.4) { TypeMaterial = "Plastic" });
			Box.Add(new Quadrate(10) { TypeMaterial = "Film" });

			Options opt = new Options(Box);

			var expected = new Circle(12) { TypeMaterial = "Film" };
			var actual = opt.TakeCircle();

			Assert.AreEqual(expected, actual[0]);
		}

		/// <summary>
		/// checking the operation of the method for obtaining all plastic unpainted figures
		/// </summary>
		[TestMethod]
		public void Testing_Take_Plastic_Not_Painted()
		{
			List<Figura> Box = new List<Figura>();
			Box.Add(new Circle(12) { TypeMaterial = "Plastic" });
			Box.Add(new Triangle(1.4) { TypeMaterial = "Plastic" });
			Box.Add(new Quadrate(10) { TypeMaterial = "Film" });
			Box.Add(new Triangle(10) { TypeMaterial = "Plastic" });

			Options opt = new Options(Box);

			opt.AddFigura(new Circle(10) { TypeMaterial = "Plastic" });
			opt.Painted(2, Color.Red);
			opt.Painted(5, Color.Pink);

			var expected = 2;
			var actual = opt.TakePlasticNotPaintedFigurs().Count;

			Assert.AreEqual(expected, actual);	
		}

		/// <summary>
		/// checking the operation of the method for obtaining all film figures
		/// </summary>
		[TestMethod]
		public void Testing_Take_Film_Figures()
		{
			Options opt = new Options(new List<Figura>());

			opt.AddFigura(new Circle(2) { TypeMaterial = "Plastic" });
			opt.AddFigura(new Quadrate(10) { TypeMaterial = "Film" });
			opt.AddFigura(new Triangle(10) { TypeMaterial = "Paper" });
			opt.AddFigura(new Quadrate(10) { TypeMaterial = "Film" });
			opt.AddFigura(new Triangle(10) { TypeMaterial = "Film" });

			var expected = 3;
			var actual = opt.TakeFilmFigurs().Count;

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// testing the method for finding a similar figure
		/// </summary>
		[TestMethod]
		public void Testing_Find_Sample_Figures()
		{
			Options opt = new Options(new List<Figura>());
			opt.AddFigura(new Circle(2) { TypeMaterial = "Plastic" });
			opt.AddFigura(new Triangle(3) { TypeMaterial = "Film" });
			opt.AddFigura(new Triangle(21) { TypeMaterial = "Paper" });

			Figura figura = new Triangle(100) { TypeMaterial = "Film" };

			var expected = "Figura: Triangle; Material: Film; Color: Colorless.";
			var actual = opt.FindBySample(figura);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// checking the work of the figure extraction method by number
		/// </summary>
		[TestMethod]
		public void Testing_Delete_By_Number()
		{
			Options opt = new Options(new List<Figura>());
			Figura figura = new Triangle(3) { TypeMaterial = "Paper" };
			figura.Color = Color.Purple;

			opt.AddFigura(new Circle(2) { TypeMaterial = "Plastic" });
			opt.AddFigura(figura);
			opt.AddFigura(new Triangle(21) { TypeMaterial = "Paper" });

			var expected = figura;
			var actual = opt.DeleteByNumber(2);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// checking the work of the figure replacement method by number
		/// </summary>
		[TestMethod]
		public void Testing_Replace_By_Number()
		{
			Options opt = new Options(new List<Figura>());
			Figura figura = new Triangle(3) { TypeMaterial = "Paper" };
			figura.Color = Color.Purple;

			opt.AddFigura(new Circle(2) { TypeMaterial = "Plastic" });
			opt.AddFigura(new Quadrate(10) { TypeMaterial = "Film" });
			opt.AddFigura(new Triangle(21) { TypeMaterial = "Paper" });

			var expected = "Figura: Triangle; Material: Paper; Color: Purple.";
			opt.ReplaceByNumber(2, figura);
			var actual = opt[2];

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// checking the operation of the general square calculation method
		/// </summary>
		[TestMethod]
		public void Testing_General_Square()
		{
			Options opt = new Options(new List<Figura>());

			opt.AddFigura(new Circle(2) { TypeMaterial = "Plastic" });
			opt.AddFigura(new Quadrate(10) { TypeMaterial = "Film" });
			opt.AddFigura(new Triangle(10) { TypeMaterial = "Paper" });

			var expected = 155.87;
			var actual = opt.GeneralSquare();

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// checking the operation of the general perimetr calculation method
		/// </summary>
		[TestMethod]
		public void Testing_General_Perimetr()
		{
			Options opt = new Options(new List<Figura>());

			opt.AddFigura(new Circle(2) { TypeMaterial = "Plastic" });
			opt.AddFigura(new Quadrate(10) { TypeMaterial = "Film" });
			opt.AddFigura(new Triangle(10) { TypeMaterial = "Paper" });

			var expected = 82.57;
			var actual = opt.GeneralPerimetr();

			Assert.AreEqual(expected, actual);
		}

	}
}
