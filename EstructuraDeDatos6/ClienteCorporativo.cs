using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDeDatos6
{
    internal class ClienteCorporativo
    {
		private long _cuit;
		private string _razonSocial;
		
		public long Cuit
		{
			get { return this._cuit; }
			set { this._cuit = value; }
		}

		public string RazonSocial
		{
			get { return this._razonSocial; }
			set { this._razonSocial = value; }
		}

		public ClienteCorporativo(long cuit, string razonSocial)
        {
			this._cuit = cuit;
			this._razonSocial = razonSocial;
        }
	}
}
