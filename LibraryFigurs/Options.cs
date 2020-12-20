using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;

namespace LibraryFigurs
{
	/// <summary>
	/// class for working with a box of shapes
	/// numbers will be counted from '1'
	/// </summary>
	public class Options
	{
		/// <summary>
		/// Box with figurs (up to 20 pieces)
		/// </summary>
		internal List<Figura> Box { get; }

		/// <summary>
		/// available number of figures
		/// </summary>
		public int BoxCount
		{
			get
			{
				return Box.Count;
			}
		}

		/// <summary>
		/// view figure by number
		/// </summary>
		/// <param name="number">number figura in box (not index)</param>
		/// <returns>strok about this figura</returns>
		public string this[int number]
		{
			get
			{
				if (number > 0 && number <= Box.Count)
					return Box[--number].ToString();
				else
					throw new Exception("Фигуры под заданным номером не существует");
			}
		}

		/// <summary>
		/// shape box initialization
		/// </summary>
		/// <param name="Box">list figura</param>
		public Options(List<Figura> Box)
		{
			this.Box = Box;
		}

		/// <summary>
		/// method for add figura in box
		/// </summary>
		/// <param name="figura">figura for add</param>
		public void AddFigura(Figura figura)
		{
			if (Box.Count < 20)
			{
				if (Box.Count > 0 && Box[Box.Count - 1].Equals(figura))
					throw new Exception("Нельзя добавлять одну и туже фигуру дважды");
				Box.Add(figura);
			}
			else
				throw new Exception("Коробка не может иметь больше 20 фигур");

		}

		/// <summary>
		/// painted figurs by number
		/// </summary>
		/// <param name="number">number figura</param>
		/// <param name="color">color</param>
		public void Painted(int number, Color color)
		{
			Box[--number].Color = color;
		}


		/// <summary>
		/// extracting a shape by number with removing a shape from the box
		/// </summary>
		/// <param name="number">number figura</param>
		/// <returns>figura of box</returns>
		public Figura DeleteByNumber(int number)
		{
			if (number > 0 && number <= Box.Count)
			{
				Figura figura = Box[--number];
				Box.Remove(figura);
				return figura;
			}
			else
				throw new Exception("Такого номера фигуры нету!");
		}

		/// <summary>
		/// replace figura by number
		/// </summary>
		/// <param name="number">number figura</param>
		/// <param name="figura">new figura for replace</param>
		public void ReplaceByNumber(int number, Figura figura)
		{
			if (number > 0 && number <= Box.Count)
			{
				Box[--number] = figura;
			}
			else
				throw new Exception("Номера заданной фигуры не существует");
		}

		/// <summary>
		/// search for a similar figure to a given one
		/// </summary>
		/// <param name="figura">similar figure</param>
		/// <returns>strok about similar figure</returns>
		public string FindBySample(Figura figura)
		{
			for (int i = 0; i < Box.Count; i++)
			{
				if (Box[i].GetType() == figura.GetType()
						&& Box[i].TypeMaterial == figura.TypeMaterial
						&& Box[i].Color == figura.Color)
				{
					return Box[i].ToString();
				}
			}
			return "Похожей фигуры на заданную не было найдено!";
		}

		/// <summary>
		/// calculate general square
		/// </summary>
		/// <returns>general square</returns>
		public double GeneralSquare()
		{
			double sum = 0;
			for (int i = 0; i < Box.Count; i++)
			{
				sum += Box[i].Square();
			}
			return Math.Round(sum, 2);
		}

		/// <summary>
		/// calculate general perimetr
		/// </summary>
		/// <returns>general perimetr</returns>
		public double GeneralPerimetr()
		{
			double sum = 0;
			for (int i = 0; i < Box.Count; i++)
			{
				sum += Box[i].Perimetr();
			}
			return Math.Round(sum, 2);
		}

		/// <summary>
		/// take all circle
		/// </summary>
		/// <returns>list circles</returns>
		public List<Figura> TakeCircle()
		{
			List<Figura> Circles = new List<Figura>();
			foreach (Figura f in Box)
			{
				if (f is Circle)
					Circles.Add(f);
			}
			return Circles;
		}

		/// <summary>
		/// take all film figurs
		/// </summary>
		/// <returns>list film figurs</returns>
		public List<Figura> TakeFilmFigurs()
		{
			List<Figura> FilmFigurs = new List<Figura>();
			for (int i = 0; i < Box.Count; i++)
			{
				if (Box[i].TypeMaterial == "Film")
					FilmFigurs.Add(Box[i]);
			}
			return FilmFigurs;
		}

		/// <summary>
		/// take all plastic which was not painted
		/// </summary>
		/// <returns>list figures</returns>
		public List<Figura> TakePlasticNotPaintedFigurs()
		{
			List<Figura> PlasticFigurs = new List<Figura>();
			for (int i = 0; i < Box.Count; i++)
			{
				if (Box[i].TypeMaterial == "Plastic" && Convert.ToInt32(Box[i].Color) == 0)
					PlasticFigurs.Add(Box[i]);
			}
			return PlasticFigurs;
		}

	}
}
