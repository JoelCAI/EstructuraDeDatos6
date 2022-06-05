using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EstructuraDeDatos6
{
	internal class UsuarioAdministrador : Usuario
	{
		protected List<Producto> _producto;
		protected List<Pedido> _pedido;
		protected List<ClienteCorporativo> _clienteCorporativo;
		public List<Producto> Producto
		{
			get { return this._producto; }
			set { this._producto = value; }
		}

		public List<Pedido> Pedido
		{
			get { return this._pedido; }
			set { this._pedido = value; }
		}

		public List<ClienteCorporativo> ClienteCorporativo
		{
			get { return this._clienteCorporativo; }
			set { this._clienteCorporativo = value; }
		}

		public UsuarioAdministrador(string nombre, List<Producto> producto,
			                        List<Pedido> pedido,
									List<ClienteCorporativo> clienteCorporativo) : base(nombre)
		{
			this._producto = producto;
			this._pedido = pedido;
			this._clienteCorporativo = clienteCorporativo;
		}

		public void MenuAdministrador(List<Producto> producto,List<Pedido> pedido,
									  List<ClienteCorporativo> clienteCorporativo)
		{

			Producto = producto;
			Pedido = pedido;
			ClienteCorporativo = clienteCorporativo;

			int opcion;
			do
			{

				Console.Clear();
				Console.WriteLine(" Bienvenido Usuario: *" + Nombre + "* ");
				opcion = Validador.PedirIntMenu("\n Menú de Registro de nuevos Productos: " +
									   "\n [1] Crear Producto" +
									   "\n [2] Grabar Producto" +
									   "\n [3] Leer Producto" +
									   "\n [4] Crear Cliente Corporativo" +
									   "\n [5] Crear Pedido" +
									   "\n [6] Crear Factura" +
									   "\n [7] Salir del Sistema.", 1, 7);

				switch (opcion)
				{
					case 1:
						DarAltaProducto();
						break;
					case 2:
						GrabarProducto();
						break;
					case 3:
						LeerProducto();
						break;
					case 4:
						CrearClienteCorporativo();
						break;
					case 5:
						CrearPedido();
						break;
					case 6:
						CrearFactura();
						break;
				}
			} while (opcion != 7);
		}

		public int BuscarProductoCodigo(string codigo)
		{
			for (int i = 0; i < this._producto.Count; i++)
			{
				if (this._producto[i].Codigo == codigo)
				{
					return i;
				}
			}
			/* si no encuentro el producto retorno una posición invalida */
			return -1;
		}

		public int BuscarClienteCorporativo(long cuit)
		{
			for (int i = 0; i < this._clienteCorporativo.Count; i++)
			{
				if (this._clienteCorporativo[i].Cuit == cuit)
				{
					return i;
				}
			}
			/* si no encuentro el producto retorno una posición invalida */
			return -1;
		}

		Dictionary<string, Producto> productoLista = new Dictionary<string, Producto>();

		Dictionary<long, ClienteCorporativo> clienteCorporativoLista = new Dictionary<long, ClienteCorporativo>();

		Dictionary<int, Pedido> pedidoLista = new Dictionary<int, Pedido>();

		protected override void DarAltaProducto()
		{

			string codigo;
			string nombre;
			string descripcion;

			int cantidad;
			int costo;
			int precio;
			int componente;

			string opcion;

			Console.Clear();
			codigo = Validador.PedirCaracterString(" Ingrese el Código" +
											  "\n El documento debe estar entre este rango.", 6, 6);
			if (BuscarProductoCodigo(codigo) == -1)
			{
				VerProducto();
				Console.WriteLine("\n ¡En hora buena! Puede utilizar este Nombre para crear un Producto Nuevo");
				nombre = Validador.PedirCaracterString("\n Ingrese el nombre del Producto", 1, 15);
				Console.Clear();
				descripcion = Validador.PedirCaracterString("Ingrese la descripción del Producto", 1, 200);
				Console.Clear();
				costo = Validador.PedirIntMayor("\n Ingrese el Costo", 0);

				precio = Validador.PedirIntMayor("Ingrese el precio del Producto", 0);
				componente = Validador.PedirIntMayor("Ingrese los Componentes del Producto", 0);
				cantidad = Validador.PedirIntMayor("Ingrese la cantidad del Producto", 0);

				opcion = ValidarSioNoProductoNoCreado("\n Está seguro que desea crear este producto? ", codigo, nombre);

				if (opcion == "SI")
				{
					Producto p = new Producto(codigo, nombre, descripcion, cantidad,costo, precio, componente);
					AddProducto(p);
					productoLista.Add(codigo, p);
					VerProducto();
					VerProductoDiccionario();
					Console.WriteLine("\n Producto con nombre *" + nombre + "* agregado exitósamente");
					Validador.VolverMenu();
				}
				else
				{
					VerProducto();
					Console.WriteLine("\n Como puede verificar no se creo ninguna Persona");
					Validador.VolverMenu();

				}

			}
			else
			{
				VerProducto();
				Console.WriteLine("\n Usted digitó el Documento *" + codigo + "*");
				Console.WriteLine("\n Ya existe una persona con ese Documento");
				Console.WriteLine("\n Será direccionado nuevamente al Menú para que lo realice correctamente");
				Validador.VolverMenu();

			}

		}

		public void AddProducto(Producto producto)
		{
			this._producto.Add(producto);
		}

		public void AddClienteCorporativo(ClienteCorporativo clienteCorporativo)
		{
			this._clienteCorporativo.Add(clienteCorporativo);
		}

		public void AddPedido(Pedido pedido)
		{
			this._pedido.Add(pedido);
		}


		protected override void GrabarProducto()
		{
			using (var archivoLista = new FileStream("archivoLista.txt", FileMode.Create))
			{
				using (var archivoEscrituraAgenda = new StreamWriter(archivoLista))
				{
					foreach (var persona in productoLista.Values)
					{

						var linea =
									"\n Código del Producto: " + persona.Codigo +
									"\n Nombre del Producto: " + persona.Nombre +
									"\n Descripcion del Producto: " + persona.Descripcion +
									"\n Costo del Producto: " + persona.Costo +
									"\n Precio del Producto: " + persona.Precio +
									"\n Componente del Producto: " + persona.Componente;

						archivoEscrituraAgenda.WriteLine(linea);

					}

				}
			}
			VerProducto();
			Console.WriteLine("Se ha grabado los datos de las personas en la Agenda correctamente");
			Validador.VolverMenu();

		}

		protected override void LeerProducto()
		{
			Console.Clear();
			Console.WriteLine("\n Productos: ");
			using (var archivoLista = new FileStream("archivoLista.txt", FileMode.Open))
			{
				using (var archivoLecturaAgenda = new StreamReader(archivoLista))
				{
					foreach (var persona in productoLista.Values)
					{


						Console.WriteLine(archivoLecturaAgenda.ReadToEnd());


					}

				}
			}
			Validador.VolverMenu();

		}

		public void CrearClienteCorporativo()
		{
			
			string razonSocial;
			string cuitString;

			int codigoCuitPrimero;
			int codigoCuitSegundo;
			int codigoCuitTercero;

			VerClienteCorporativo();
			codigoCuitPrimero = Validador.PedirIntMenu("Ingrese los dos primeros dígitos del CUIT", 10, 99);
			codigoCuitSegundo = Validador.PedirIntMenu("Ingrese los 8 digitos del Cuit" +
													   "\n " + codigoCuitPrimero + "-", 10000000, 99999999);
			codigoCuitTercero = Validador.PedirIntMenu("\n Ingrese el último digito: " +
													   "\n " + codigoCuitPrimero +"-"+
													   codigoCuitSegundo+"-" , 0, 9);

			cuitString = codigoCuitPrimero.ToString() + codigoCuitSegundo.ToString() +
						codigoCuitTercero.ToString(); 
			bool cuitConvertido = long.TryParse(cuitString, out long cuit);

			string opcion;

			Console.Clear();
			
			if (BuscarClienteCorporativo(cuit) == -1)
			{
				VerClienteCorporativo();
				Console.WriteLine("\n ¡En hora buena! Puede utilizar este Nombre para crear un Producto Nuevo");
				razonSocial = Validador.PedirCaracterString("\n Ingrese el nombre de la Razón Social", 1, 30);
				Console.Clear();

				opcion = ValidarSioNoClienteNoCreado("\n Está seguro que desea crear este Cliente Corporativo? ",
													codigoCuitPrimero,codigoCuitSegundo,codigoCuitTercero,
													razonSocial);

				if (opcion == "SI")
				{
					ClienteCorporativo p = new ClienteCorporativo(cuit, razonSocial);
					AddClienteCorporativo(p);
					clienteCorporativoLista.Add(cuit, p);
					VerClienteCorporativo();
					VerClienteCorporativoDiccionario();
					Console.WriteLine("\n Cliente Corporativo con Razón Social *" + razonSocial + "* agregado exitósamente");
					Validador.VolverMenu();
				}
				else
				{
					VerClienteCorporativo();
					Console.WriteLine("\n Como puede verificar no se creo ningún Cliente Corporativo");
					Validador.VolverMenu();

				}

			}
			else
			{
				VerClienteCorporativo();
				Console.WriteLine("\n Usted digitó un CUIT *" + cuit + "*");
				Console.WriteLine("\n Ya existe una Razón Social con ese número de CUIT");
				Console.WriteLine("\n Será direccionado nuevamente al Menú para que lo realice correctamente");
				Validador.VolverMenu();

			}

		}

		public void CrearPedido()
		{
			long cuitCliente;
			string razonSocial;

			string codigoProducto;
			string nombreProducto;

			string tipodeRecargo;

			int precioProducto;
			int cantidadProducto;
			

			string opcion;
			string opcionDos;
			string opcionTres;

			Console.Clear();
			Console.WriteLine("\n Registrar Pedido:");

			VerClienteCorporativo();
			cuitCliente = Validador.PedirLongMenu("Ingrese el CUIT del Cliente Corporativo", 10000000000,
												  99999999999);

			if (BuscarClienteCorporativo(cuitCliente) != -1)
			{
				VerClienteCorporativo();
				Console.WriteLine("\n Pedido para Cliente con CUIT: " +
									ClienteCorporativo[BuscarClienteCorporativo(cuitCliente)].Cuit +
								  "\n Razón Social del Cliente: " +
								  ClienteCorporativo[BuscarClienteCorporativo(cuitCliente)].RazonSocial);;

				razonSocial = ClienteCorporativo[BuscarClienteCorporativo(cuitCliente)].RazonSocial;

				Console.Clear();

				opcion = ValidarSioNoContinuarCliente("\n Desea Continuar? ",cuitCliente,razonSocial);

				if (opcion == "SI")
				{
					Pedido pedido = new Pedido(cuitCliente, razonSocial);
					do
					{
						VerProducto();
						codigoProducto = ValidarStringNoVacioProducto("Ingrese el código del producto a vender");
						if (BuscarProductoCodigo(codigoProducto) != -1)
						{

							VerProducto();
							precioProducto = Producto[BuscarProductoCodigo(codigoProducto)].Precio;
							nombreProducto = Producto[BuscarProductoCodigo(codigoProducto)].Nombre;

							do
							{
								Console.Clear();
								Console.WriteLine("\n Cantidad del Producto a vender *" +
													Producto[BuscarProductoCodigo(codigoProducto)].Cantidad + "*");
								Console.WriteLine("\n No se puede vender más de lo que existe en el Stock");
								cantidadProducto = Validador.PedirIntMayor("\n Ingrese la cantidad a comprar", 0);

							} while (cantidadProducto > Producto[BuscarProductoCodigo(codigoProducto)].Cantidad);


							Producto[BuscarProductoCodigo(codigoProducto)].Cantidad =
							Producto[BuscarProductoCodigo(codigoProducto)].Cantidad - cantidadProducto;
							Item item = new Item(codigoProducto, nombreProducto, precioProducto, cantidadProducto);
							pedido.AddItem(item);
							
						}
                       
						opcionDos = Validador.ValidarSioNo("\n Desea Continuar cargando productos?");
						
						
					} while (opcionDos == "SI");

					opcionTres = Validador.ValidarSioNo("\n Desea suspender todo o continuar con el pedido?");

					if (opcionTres == "NO")
                    {
						tipodeRecargo = Validador.ValidarTipoRecargo("Ingrese el tipo de Recargo");
						pedido.CalcularRecargo(tipodeRecargo);
						pedido.CalcularTotalSinIVA();
						AddPedido(pedido);
						
						pedidoLista.Add(pedido.IdPedido, pedido);
						VerPedidoDiccionario();
						Console.WriteLine("Pedido registrado exitósamente");
						VerPedido();
						

						Validador.VolverMenu();

					}
					else
                    {
						
						Console.WriteLine("No se generó ningún pedido");
						Validador.VolverMenu();
					}

				}
				else
				{
					Console.WriteLine("\n Eligió no generar ningún Pedido.");
					Validador.VolverMenu();

				}

			}
			else
			{
				VerClienteCorporativo();
				Console.WriteLine("\n Usted digitó un CUIT *" + cuitCliente + "*");
				Console.WriteLine("\n No existe una Razón Social con ese número de CUIT");
				Console.WriteLine("\n Será direccionado nuevamente al Menú para que pueda Crearlo");
				Validador.VolverMenu();

			}

		}

		public void CrearFactura()
        {

        }

		protected string ValidarStringNoVacioProducto(string mensaje)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Por favor ingrese el valor solicitado y que no sea vacio.";


			do
			{
				VerProducto();
				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeValidador);

				opcion = Console.ReadLine().ToUpper();

				if (opcion == "")
				{

					Console.WriteLine("\n");

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}



		protected string ValidarSioNoProductoNoCreado(string mensaje, string codigo, string nombre)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
									  "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{
				VerProducto();

				Console.WriteLine(
								  "\n Codigo del Producto a Crear: " + codigo +
								  "\n Nombre del Producto a Crear: " + nombre);

				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeError);
				Console.WriteLine(mensajeValidador);
				opcion = Console.ReadLine().ToUpper();
				string opcionC = "SI";
				string opcionD = "NO";

				if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
				{
					continue;

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}

		protected string ValidarSioNoClienteNoCreado(string mensaje, int uno, int dos, int tres,
													string razonSocial)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
									  "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{
				VerClienteCorporativo();

				Console.WriteLine(
								  "\n Cuit del Cliente Corporativo a Crear: " +
									uno + "-" + dos + "-" + tres +
								  "\n Razón social del Cliente Corporativo a Crear: " + razonSocial);

				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeError);
				Console.WriteLine(mensajeValidador);
				opcion = Console.ReadLine().ToUpper();
				string opcionC = "SI";
				string opcionD = "NO";

				if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
				{
					continue;

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}

		protected string ValidarSioNoContinuarCliente(string mensaje, long cuit, string razonSocial)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
									  "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{

				Console.WriteLine(
								  "\n Cuit del Cliente Corporativo: " +
									cuit +
								  "\n Razón social del Cliente Corporativo: " + razonSocial);

				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeError);
				Console.WriteLine(mensajeValidador);
				opcion = Console.ReadLine().ToUpper();
				string opcionC = "SI";
				string opcionD = "NO";

				if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
				{
					continue;

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}


		public void VerProducto()
		{
			Console.Clear();
			Console.WriteLine("\n Productos");
			Console.WriteLine(" #\t\tCódigo.\t\tNombre.\t\tDescrípción.");
			for (int i = 0; i < Producto.Count; i++)
			{
				Console.Write(" " + (i + 1));

				Console.Write("\t\t");
				Console.Write(Producto[i].Codigo);
				Console.Write("\t\t");
				Console.Write(Producto[i].Nombre);
				Console.Write("\t\t");
				Console.Write(Producto[i].Descripcion);
				Console.Write("\t\t");

				Console.Write("\n");
			}

		}

		public void VerClienteCorporativo()
		{
			Console.Clear();
			Console.WriteLine("\n Clientes Corporativos ");
			Console.WriteLine(" #\t\tCuit.\t\tRazón Social.");
			for (int i = 0; i < ClienteCorporativo.Count; i++)
			{
				Console.Write(" " + (i + 1));

				Console.Write("\t\t");
				Console.Write(ClienteCorporativo[i].Cuit);
				Console.Write("\t\t");
				Console.Write(ClienteCorporativo[i].RazonSocial);
				Console.Write("\t\t");

				Console.Write("\n");
			}

		}

		public void VerPedido()
		{
			Console.Clear();
			Console.WriteLine("\n Pedido: ");
			Console.WriteLine(" #\t\tCódigo Pedido.\t\tCuit Cliente.\t\tProductos.");
			for (int i = 0; i < Pedido.Count; i++)
			{
				Console.Write(" " + (i + 1));

				Console.Write("\t\t");
				Console.Write(Pedido[i].IdPedido);
				Console.Write("\t\t");
				Console.Write(Pedido[i].CuitClienteCorporativo);
				Console.Write("\t\t");

				foreach (Pedido pedido in Pedido)
				{
					foreach (Item item in pedido.Item)
					{
						Console.Write(Pedido[i].Item[i].CodigoProducto);
						Console.Write("\t\t");
						Console.Write(Pedido[i].Item[i].NombreProducto);
						Console.Write("\n");
					}

				}
				

			}

		}

		public void VerPedidoCuenta()
		{
			
			Console.Clear();
			Console.WriteLine("Pedidos del día");
			Console.WriteLine("#\tSubTototal.\tRecargo.\tTotal");
			for (int i = 0; i < Pedido.Count; i++)
			{
				Console.Write(i + 1);
				Console.Write("\t");
				Console.Write(Pedido[i].SubTotal);
				Console.Write("\t");
				Console.Write(Pedido[i].Recargo);
				Console.Write("\t");
				Console.Write(Pedido[i].TotalSinIva);
				Console.Write("\n");
			}

			decimal totalCobradoSinIVA = 0;
			int cantidadProductos = 0;
			int cantidadRecargos = 0;
			decimal totalRecargos = 0;

			/* Los Pedidos realizados estan en la lista de Pedidos así que recorremos esa lista */
			foreach (Pedido pedido in Pedido)
			{
				totalCobradoSinIVA = totalCobradoSinIVA + pedido.TotalSinIva;
			}

			/* cantidad de Pedidos emitidos */
			foreach (Pedido pedido in Pedido)
			{
				foreach (Item item in pedido.Item)
				{
					cantidadProductos = cantidadProductos + item.CantidadProducto;
				}

			}
			/* Cantidad de Recargos aplicados */
			foreach (Pedido pedido in Pedido)
			{
				if (pedido.Recargo > 0)
				{
					cantidadRecargos = cantidadRecargos + 1;
				}
			}
			/* Total de Recargos aplicados */
			foreach (Pedido pedido in Pedido)
			{
				if (pedido.Recargo > 0)
				{
					totalRecargos = totalRecargos + pedido.Recargo;
				}
			}
			Console.WriteLine("Total cobrado sin IVA: " + totalCobradoSinIVA.ToString());
			Console.WriteLine("Cantidad de productos vendidos: " + cantidadProductos.ToString());
			Console.WriteLine("Cantidad de Recargos aplicados: " + cantidadRecargos.ToString());
			Console.WriteLine("Total de Recargos aplicados: " + totalRecargos.ToString());

			Console.ReadLine();
		}

		public void VerProductoDiccionario()
		{
			Console.WriteLine("\n Productos en el Diccionario");
			for (int i = 0; i < productoLista.Count; i++)
			{
				KeyValuePair<string, Producto> producto = productoLista.ElementAt(i);

				Console.WriteLine("\n Código: " + producto.Key);
				Producto productoValor = producto.Value;


				Console.WriteLine(" Nombre del Producto: " + productoValor.Nombre);
				Console.WriteLine(" Descripción del Producto: " + productoValor.Descripcion);
				Console.WriteLine(" Costo del Producto: " + productoValor.Costo);
				Console.WriteLine(" Precio del Producto: " + productoValor.Precio);
				Console.WriteLine(" Cantidad del Producto: " + productoValor.Cantidad);
				Console.WriteLine(" Componentes del Producto: " + productoValor.Componente);


			}


		}

		public void VerClienteCorporativoDiccionario()
		{
			Console.WriteLine("\n Productos en el Diccionario");
			for (int i = 0; i < clienteCorporativoLista.Count; i++)
			{
				KeyValuePair<long, ClienteCorporativo> persona = clienteCorporativoLista.ElementAt(i);

				Console.WriteLine("\n CUIT: " + persona.Key);
				ClienteCorporativo personaValor = persona.Value;


				Console.WriteLine(" Razón Social: " + personaValor.RazonSocial);


			}


		}

		public void VerPedidoDiccionario()
		{
			Console.WriteLine("\n Pedidos en el Diccionario");
			for (int i = 0; i < pedidoLista.Count; i++)
			{
				KeyValuePair<int, Pedido> pedido = pedidoLista.ElementAt(i);

				Console.WriteLine("\n Id Pedido: " + pedido.Key);
				Pedido pedidoValor = pedido.Value;

				Console.WriteLine(" Cuit Cliente: " + pedidoValor.CuitClienteCorporativo);
				Console.WriteLine(" Productos: " + pedidoValor.Item[i].NombreProducto);

			}


		}
	}
}
