//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2014/02/16 - 11:41:09
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioIndicadoresDTO
{
    public partial class USUARIOSDTO
    {
        public Decimal IDUSUARIO { get; set; }

        public String CODUSUARIO { get; set; }

        public String APEPAT { get; set; }

        public String APEMAT { get; set; }

        public String NOMBRE { get; set; }

        public String EMAIL { get; set; }

        public String DIRECCION { get; set; }

        public String DNI { get; set; }

        public String PASSWORD { get; set; }

        public Nullable<Decimal> IDROL { get; set; }

        public Decimal ROLES_IDROL { get; set; }

        public USUARIOSDTO()
        {
        }

        public USUARIOSDTO(Decimal iDUSUARIO, String cODUSUARIO, String aPEPAT, String aPEMAT, String nOMBRE, String eMAIL, String dIRECCION, String dNI, String pASSWORD, Nullable<Decimal> iDROL, Decimal rOLES_IDROL)
        {
			this.IDUSUARIO = iDUSUARIO;
			this.CODUSUARIO = cODUSUARIO;
			this.APEPAT = aPEPAT;
			this.APEMAT = aPEMAT;
			this.NOMBRE = nOMBRE;
			this.EMAIL = eMAIL;
			this.DIRECCION = dIRECCION;
			this.DNI = dNI;
			this.PASSWORD = pASSWORD;
			this.IDROL = iDROL;
			this.ROLES_IDROL = rOLES_IDROL;
        }
    }
}
