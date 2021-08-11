using System;
using System.Collections.Generic;
using System.Text;

namespace SooftTechnologyChallengeEj4.Domain.Entities
{
    public class Caja : BaseEntity<Guid>
    {
        public int SucursalId { get; }
        public string Descripcion { get; }
        public int TipoCajaId { get; }

        public Caja()
        {

        }

        public Caja(Guid id, int sucursalId, string descripcion, int tipoCajaId)
        {
            Id = id;
            SucursalId = sucursalId;
            Descripcion = descripcion;
            TipoCajaId = tipoCajaId;
        }

        public override string ToString() => $"{Id}-{SucursalId}-{Descripcion}-{TipoCajaId}";
    }
}
