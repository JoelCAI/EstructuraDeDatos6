using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDeDatos6
{
    internal class Producto
    {
		private string _codigo;
		private string _nombre;
		private string _descripcion;
		private int _cantidad;
		private int _costo;
		private int _precio;
		private int _componente;

		public string Codigo
		{
			get { return this._codigo; }
			set { this._codigo = value; }
		}

		public string Nombre
		{
			get { return this._nombre; }
			set { this._nombre = value; }
		}

		public string Descripcion
		{
			get { return this._descripcion; }
			set { this._descripcion = value; }
		}

		public int Cantidad
		{
			get { return this._cantidad; }
			set { this._cantidad = value; }
		}

		public int Costo
		{
			get { return this._costo; }
			set { this._costo = value; }
		}

		public int Precio
		{
			get { return this._precio; }
			set { this._precio = value; }
		}

		public int Componente
		{
			get { return this._componente; }
			set { this._componente = value; }
		}


		public Producto(string codigo, string nombre, string descripcion, int cantidad,
						int costo, int precio, int componente)
		{

			this._codigo = codigo;
			this._nombre = nombre;
			this._descripcion = descripcion;
			this._costo = costo;
			this._precio = precio;
			this._componente = componente;
			this._cantidad = cantidad;
		}
	}
}
