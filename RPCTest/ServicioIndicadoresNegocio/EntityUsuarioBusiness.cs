﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AustinHarris.JsonRpc;
using ServicioIndicadoresDTO;
using ServiciosIndicadoresEntities;
using System.Data.Entity;
namespace ServicioIndicadoresNegocio
{
    public class EntityUsuarioBusiness : JsonRpcService{
    
        [JsonRpcMethod]

        public List<USUARIOSDTO> ValidarLogin(string usu, string pass)
        {
            using (var bd = new IndicadoresEntities())
            {
                var qrydb = from user in bd.USUARIOS
                            where user.EMAIL == usu && user.PASSWORD == pass
                            select user;
                if (qrydb.Count() > 0)
                {
                    var usuarioDTO=  USUARIOSAssembler.ToDTOs(qrydb);
                    return usuarioDTO; //ejecuta

                }
                else
                {

                return null; //wilmer expresate
                }
            }
        }
        //[JsonRpcMethod]
        //private string RegistrarLogin(string usuario, string nom, string apepat, string apemat, string email, string direc, string dni, string pass)
        //{

        //    using (IndicadoresEntities bd = new IndicadoresEntities())
        //    {
        //        if (bd.USUARIOS.Any(u => u.EMAIL == email))
        //        {
        //            return "El Email Ingresado Ya se Encuentra en uso";
        //        }
        //        else if (bd.USUARIOS.Any(u => u.CODUSUARIO == usuario))
        //        {
        //            return "El Nombre de Usuario Ingresado Ya se Encuentra en uso";
        //        }
        //        else if (bd.USUARIOS.Any(u => u.DNI == dni))
        //        {
        //            return "El DNI Ingresado Ya se Encuentra en uso";//descomentar esta seccion si desea evitar registrar a varios usuarios con el mismo dni
        //        }
        //        else
        //        {
        //            IndicadoresEntities bd1 = new IndicadoresEntities();
        //            USUARIOS _usu = new USUARIOS();
        //            _usu.NOMBRE = nom;
        //            _usu.APEPAT = apepat;
        //            _usu.APEMAT = apemat;
        //            _usu.DIRECCION = direc;
        //            _usu.DNI = dni;
        //            _usu.PASSWORD = pass;
        //            _usu.EMAIL = email;
        //            _usu.CODUSUARIO = usuario;
        //            _usu.IDROL = 1;
        //            bd1.USUARIOS.Add(_usu);
        //            bd1.SaveChanges();
        //            /*log.IDDET = cc.ID;*/
        //            return "Registro OK";
        //        }
        //    }

        //}
        [JsonRpcMethod]
        public List<Sph> TablaSph(int anho, int mes, String codobj)
        {
            using (var context = new IndicadoresEntities())
            {
                var blogNames = context.Database.SqlQuery<Sph>(
                "select FECHA,COUNT(distinct txt_01) logueados,COUNT(distinct txt_01) * 7 horas_trabajadas, "
                + "SUM(val_03) ventas,        (SELECT ROUND(VALOR,0) FROM GESTION_VARIABLES V WHERE CODOBJ=X.CODOBJ AND CODVAR = 'OBJ_VTA_DIA_NEG') "
                + "objetivo,       SUM(val_03)/(COUNT(distinct txt_01) * 7) sph,"
                + "(sum(case when txt_03 = 'DECO' then val_03 else 0 end)+sum(case when txt_03 = 'REGULAR' then val_03 else 0 end)) as TotalPaq,"
                + "sum(case when txt_03 = 'REGULAR' then val_03 else 0 end) regular,"
                + "sum(case when txt_03 = 'DECO' then val_03 else 0 end) deco,"
                + "sum(case when txt_06 = 'LIMA' then val_03 else 0 end) lima,"
                   + " sum(case when txt_06 = 'PROVINCIA' then val_03 else 0 end) provincia,"
                + "SUM(case when val_03 > 0 then val_08 else 0 end) tmo     "
                + "from dbo.GESTION_INDICADORES_DETALLE X "
                + "where tipo = 'TABLA_BASES_UNICOS' "
                + "and FECHA is not null "
                    + " and ANHO= " + anho
                    + " AND MES = " + mes
                    + " AND DIA >= 1"
               + " AND CODOBJ = '" + codobj + "'"
                + " AND ESTADO = 'A' group by fecha, "
                + " CODOBJ order by 1").ToList();
                return blogNames;
            }
        }


        [JsonRpcMethod]
        public List<TablaTeleavance> TablaTeleavance(String PRODUCTO, String SEGMENTO)
        {
            using (var context = new IndicadoresEntities())
            {
                var blogNames = context.Database.SqlQuery<TablaTeleavance>(
                "select CODOBJ, DESCRIPCION "
                 +"from GESTION_TELEAVANCE "
                  + "where PRODUCTO='" + PRODUCTO + "' "
                  + " and SEGMENTO='" + SEGMENTO + "' ").ToList();
                return blogNames;
            }
        }
        // consulta hecha por tobias -------------------------------------------------------
        // coonsulta 2

        [JsonRpcMethod]
        public List<GESTION_INDICADORES_DETALLEbasecerrado> GestionIndicadoresCierre(int anho, int mes, String codobj, String atributo)
        {
            using (var context = new IndicadoresEntities())
            {
                var Valores2 = context.Database.SqlQuery<GESTION_INDICADORES_DETALLEbasecerrado>(
                "SELECT " + atributo + ",txt_06,SUM(VAL_09) MARCACIONES,SUM(VAL_04) POTENCIAL, "
       + " sum(CASE WHEN TXT_02 = 'Fijo'    THEN VAL_09 ELSE 0 END) MARCACIONES_FIJA, "
       + "sum(CASE WHEN TXT_02 = 'Celular' THEN VAL_09 ELSE 0 END) MARCACIONE_CELULAR,  "
       + " (sum(CASE WHEN TXT_02 = 'Fijo'    THEN VAL_09 ELSE 0 END)/((SELECT SUM(X.VAL_01+X.VAL_02+X.VAL_03) TRAMITADOS FROM GESTION_INDICADORES_DETALLE x where tipo = 'TABLA_BASES_UNICOS'  AND X.CODOBJ = Z.CODOBJ AND ESTADO = 'A' AND X.MES=Z.MES AND x.txt_06 = Z.TXT_06 ))) INTENTOS_FIJO, "
       + "(sum(CASE WHEN TXT_02 = 'Celular' THEN VAL_09 ELSE 0 END)/((SELECT SUM(X.VAL_01+X.VAL_02+X.VAL_03) TRAMITADOS FROM GESTION_INDICADORES_DETALLE x where tipo = 'TABLA_BASES_UNICOS'  AND X.CODOBJ = Z.CODOBJ AND ESTADO = 'A' AND X.MES=Z.MES AND x.txt_06 = Z.TXT_06 ))) INTENTOS_CELULAR, "
       + " (SUM(VAL_09)/((SELECT SUM(X.VAL_01+X.VAL_02+X.VAL_03) TRAMITADOS FROM GESTION_INDICADORES_DETALLE x where tipo = 'TABLA_BASES_UNICOS'  AND X.CODOBJ = Z.CODOBJ AND ESTADO = 'A' AND X.MES=Z.MES AND x.txt_06 = Z.TXT_06 ))) REINTENTOS "
+ " FROM GESTION_INDICADORES_DETALLE z "
+ " where tipo = 'TABLA_BASES_GESTION' "
+ " AND CODOBJ = '" + codobj + "'"
+ " AND MES=" + mes
+ " AND ANHO=" + anho
+ " group by z." + atributo + ",z.txt_06,z.CODOBJ,z.mes"
+ " order by 1 ").ToList();
                return Valores2;
            }
        }



        ///consulta 1
        [JsonRpcMethod]
        public List<GESTION_INDICADORES> GestionIndicadores(int anho, int mes, String codobj, String atributo)
        {
            using (var context = new IndicadoresEntities())
            {
                var Valores = context.Database.SqlQuery<GESTION_INDICADORES>(
                " SELECT " + atributo + ",txt_06,SUM(VAL_09) TOTAL_BASE, "
  + " SUM(VAL_03) CEF, "
+ "  SUM(VAL_02) CNE, "
+ "  SUM(VAL_01) NOC, "
+ "  SUM(VAL_01+VAL_02+VAL_03) TRAMITADOS, "
+ "  SUM(CASE WHEN FECHA IS NULL THEN VAL_09 ELSE 0 END) PENDIENTES, "
+ "  SUM(VAL_03+VAL_02) CONTACTOS, "
+ "  SUM(VAL_04) CONTACTOS_POTENCIAL, "
+ "  (SUM(VAL_04)/SUM(VAL_01+VAL_02+VAL_03))*100 CONTACTABILIDAD_POTENCIAL, "
+ "  (SUM(VAL_03)/SUM(VAL_01+VAL_02+VAL_03))*100 EFECTIVIDAD, "
+ "  (SUM(VAL_03)/SUM(VAL_02+VAL_03))*100 EFECT_CONTACTO, "
+ "  (SUM(VAL_03)/SUM(VAL_04))*100 EFECT_POTENCIAL "
+ " FROM GESTION_INDICADORES_DETALLE "
+ " where tipo = 'TABLA_BASES_UNICOS' "
 + " AND CODOBJ = '" + codobj + "'"
+ " AND ESTADO = 'A' "
+ " AND MES= " + mes
+ " AND ANHO= " + anho
+ " group by " + atributo + ",txt_06 "
+ " order by 1").ToList();
                return Valores;
            }
        }
        [JsonRpcMethod]
        public List<GESTIONINDICADORESRESUMEN> GestionIndicadoresResumen(String codobj, int anho, int mes)
        {
            using (var cnx = new IndicadoresEntities())
            {
                var resumen = cnx.Database.SqlQuery<GESTIONINDICADORESRESUMEN>(
                    " select DESCRIPCION, VALOR, LIMA, PROVINCIA "
                    + " from gestion_indicadores_resumen"
                    + " where CODOBJ = '" + codobj + "'"
                    + " and ANHO = " + anho.ToString()
                    + " and MES = " + mes.ToString()).ToList();
                return resumen;
            }

        }
    }
}
