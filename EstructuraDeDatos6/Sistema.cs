using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDeDatos6
{
    internal class Sistema
    {
		private List<UsuarioAdministrador> _usuarioAdministrador;
		private List<Producto> _producto;
		private List<Pedido> _pedido;
		private List<ClienteCorporativo> _clienteCorporativo;

		public Sistema()
		{
			this._usuarioAdministrador = new List<UsuarioAdministrador>();
			this._producto = new List<Producto>();
			this._pedido = new List<Pedido>();
			this._clienteCorporativo = new List<ClienteCorporativo>();
		}


		public int BuscarUsuarioAdministradorNombre(string nombre)
		{
			for (int i = 0; i < this._usuarioAdministrador.Count; i++)
			{
				if (this._usuarioAdministrador[i].Nombre == nombre)
				{
					return i;
				}
			}
			return -1;
		}


		public void MenuPrincipal()
		{
			Console.Clear();
			int opcion;
			string nombre;
			int posUsuarioA;
			UsuarioAdministrador uA;


			do
			{
				Console.Clear();
				opcion = Validador.PedirIntMenu("\n Menú Principal del Sistema" +
									   "\n [1] Ingresar a la Aplicación." +
									   "\n [2] Salir.", 1, 2);
				switch (opcion)
				{
					/* Aqui vamos a validar que el usuario exista */
					case 1:
						Console.Clear();

						nombre = Validador.PedirCaracterString("\n\n Ingrese su Nombre ", 0, 30);
						uA = new UsuarioAdministrador(nombre, this._producto,this._pedido,
							this._clienteCorporativo);
						_usuarioAdministrador.Add(uA);
						posUsuarioA = BuscarUsuarioAdministradorNombre(nombre);

						/* Si esto se cumple puedo crear un Usuario */
						if (posUsuarioA != -1)
						{

							_usuarioAdministrador[posUsuarioA].MenuAdministrador(this._producto,this._pedido,
							this._clienteCorporativo);
							this._producto = _usuarioAdministrador[posUsuarioA].Producto;
							this._pedido = _usuarioAdministrador[posUsuarioA].Pedido;
							this._clienteCorporativo = _usuarioAdministrador[posUsuarioA].ClienteCorporativo;

						}
						break;
					case 2:
						break;
				}

			} while (opcion != 2);

		}


		public void Iniciar()
		{
			MenuPrincipal();
		}
	}
}
