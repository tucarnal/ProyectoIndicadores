//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2014/02/16 - 11:41:10
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioIndicadoresDTO
{
    public partial class GESTION_INDICADORES_RESUMENDTO
    {
        public Decimal IDRESUMEN { get; set; }

        public String CODOBJ { get; set; }

        public Nullable<Decimal> ANHO { get; set; }

        public Nullable<Decimal> MES { get; set; }

        public Nullable<Decimal> DIA { get; set; }

        public Nullable<DateTime> FECHA { get; set; }

        public String CODVAR { get; set; }

        public String DESCRIPCION { get; set; }

        public Decimal VALOR { get; set; }

        public Nullable<Decimal> VALOROBJ { get; set; }

        public Nullable<Decimal> LIMA { get; set; }

        public Nullable<Decimal> PROVINCIA { get; set; }

        public GESTION_INDICADORES_RESUMENDTO()
        {
        }

        public GESTION_INDICADORES_RESUMENDTO(Decimal iDRESUMEN, String cODOBJ, Nullable<Decimal> aNHO, Nullable<Decimal> mES, Nullable<Decimal> dIA, Nullable<DateTime> fECHA, String cODVAR, String dESCRIPCION, Decimal vALOR, Nullable<Decimal> vALOROBJ, Nullable<Decimal> lIMA, Nullable<Decimal> pROVINCIA)
        {
			this.IDRESUMEN = iDRESUMEN;
			this.CODOBJ = cODOBJ;
			this.ANHO = aNHO;
			this.MES = mES;
			this.DIA = dIA;
			this.FECHA = fECHA;
			this.CODVAR = cODVAR;
			this.DESCRIPCION = dESCRIPCION;
			this.VALOR = vALOR;
			this.VALOROBJ = vALOROBJ;
			this.LIMA = lIMA;
			this.PROVINCIA = pROVINCIA;
        }
    }
}