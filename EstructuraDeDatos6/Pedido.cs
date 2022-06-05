using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDeDatos6
{
    internal class Pedido
    {
		protected int _idPedido;

		protected decimal _subTotal;
		protected decimal _recargo;
		protected decimal _totalSinIva;

		protected List<Item> _item;

		protected long _cuitClienteCorporativo;
		protected string _razonSocialClienteCorporativo;

		public List<Item> Item
		{
			get { return this._item; }
			/* set { this._items = value; } No debería poder setearse todo el listado */
			/* Para eso está implementar el método: AddItem */
			/* Se podría agregar DeleteItem */
		}

		public int IdPedido
		{
			get { return this._idPedido; }
			
		}

		public decimal SubTotal
		{
			get { return this._subTotal; }
			set { this._subTotal = value; }
		}
		public decimal Recargo
		{
			get { return this._recargo; }
			set
			{
				this._recargo = value;
				this._totalSinIva = this._subTotal + this._recargo;
			}
		}

		public decimal TotalSinIva
		{
			get { return this._totalSinIva; }
			set { this._totalSinIva = value; }
		}

		public long CuitClienteCorporativo
		{
			get { return this._cuitClienteCorporativo; }
			set { this._cuitClienteCorporativo = value; }
		}

		public string RazonSocialClienteCorporativo
		{
			get { return this._razonSocialClienteCorporativo; }
			set { this._razonSocialClienteCorporativo = value; }
		}

		public static int _registroPedido = 1;

		public Pedido(long cuitCliente, string razonSocialCliente)
		{
			this._item = new List<Item>();
			this._cuitClienteCorporativo = cuitCliente;
			this._razonSocialClienteCorporativo = razonSocialCliente;
			this._idPedido = _registroPedido;
			_registroPedido++;
		}

		public void AddItem(Item item)
		{
			this._item.Add(item); 
			this._subTotal = this._subTotal + (item.CantidadProducto * item.PrecioUnitarioProducto);
		}

		public void CalcularRecargo(string mensaje)
		{
			decimal urgente = 1.2m; 
			decimal retiroenPuerta = 500;
			decimal internacional = 2000;
			decimal sinRecargo = 0;
			
			if (mensaje == "URGENTE")
			{
				this._recargo = this._recargo * urgente ;
			}
			else if (mensaje == "RETIROENPUERTA")
            {
				this._recargo = this._recargo + retiroenPuerta;
			}
			else if (mensaje == "INTERNACIONAL")
			{
				this._recargo = this._recargo + internacional;
			}
			else if (mensaje == "NINGUNO")
			{
				this._recargo = this._recargo + sinRecargo;
			}
		}

		public void CalcularTotalSinIVA()
		{
			this._totalSinIva = this._subTotal + this._recargo; // Se calcula el "total"
		}




	}
}
