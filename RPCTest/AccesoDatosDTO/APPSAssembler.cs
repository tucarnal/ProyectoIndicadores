//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2014/02/08 - 23:05:45
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ADODBFactory;

namespace AccesoDatosDTO
{

    /// <summary>
    /// Assembler for <see cref="APPS"/> and <see cref="APPSDTO"/>.
    /// </summary>
    public static partial class APPSAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="APPSDTO"/> converted from <see cref="APPS"/>.</param>
        static partial void OnDTO(this APPS entity, APPSDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="APPS"/> converted from <see cref="APPSDTO"/>.</param>
        static partial void OnEntity(this APPSDTO dto, APPS entity);

        /// <summary>
        /// Converts this instance of <see cref="APPSDTO"/> to an instance of <see cref="APPS"/>.
        /// </summary>
        /// <param name="dto"><see cref="APPSDTO"/> to convert.</param>
        public static APPS ToEntity(this APPSDTO dto)
        {
            if (dto == null) return null;

            var entity = new APPS();

            entity.IDAPP = dto.IDAPP;
            entity.CODAPP = dto.CODAPP;
            entity.NOMAPP = dto.NOMAPP;
            entity.ESTADO = dto.ESTADO;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="APPS"/> to an instance of <see cref="APPSDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="APPS"/> to convert.</param>
        public static APPSDTO ToDTO(this APPS entity)
        {
            if (entity == null) return null;

            var dto = new APPSDTO();

            dto.IDAPP = entity.IDAPP;
            dto.CODAPP = entity.CODAPP;
            dto.NOMAPP = entity.NOMAPP;
            dto.ESTADO = entity.ESTADO;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="APPSDTO"/> to an instance of <see cref="APPS"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<APPS> ToEntities(this IEnumerable<APPSDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="APPS"/> to an instance of <see cref="APPSDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<APPSDTO> ToDTOs(this IEnumerable<APPS> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
