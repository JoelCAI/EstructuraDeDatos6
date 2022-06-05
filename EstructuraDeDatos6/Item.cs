using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDeDatos6
{
    internal class Item
    {
        private string _codigoProduto;
        private string _nombreProducto;
        private int _cantidadProducto;
        private int _precioUnitarioProducto;

        public string CodigoProducto
        {
            get { return this._codigoProduto; }
            set { this._codigoProduto = value; }
        }
        public string NombreProducto
        {
            get { return this._nombreProducto; }
            set { this._nombreProducto = value; }
        }

        public int CantidadProducto
        {
            get { return this._cantidadProducto; }
            set { this._cantidadProducto = value; }
        }

        public int PrecioUnitarioProducto
        {
            get { return this._precioUnitarioProducto; }
            set { this._precioUnitarioProducto = value; }
        }

        public Item(string codigoProducto, string nombreProducto, int cantidadProducto, int precioUnitarioProducto)
        {
            this._codigoProduto = codigoProducto;
            this._nombreProducto = nombreProducto;
            this._cantidadProducto = cantidadProducto;
            this._precioUnitarioProducto = precioUnitarioProducto;
        }

    }
}
