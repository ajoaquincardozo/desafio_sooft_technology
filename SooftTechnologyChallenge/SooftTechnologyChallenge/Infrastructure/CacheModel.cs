using SooftTechnologyChallenge.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SooftTechnologyChallenge.Infrastructure
{
    public class CacheModel
    {
        public Dictionary<Guid, Caja> Cajas { get; set; }
        public Dictionary<int, IList<Caja>> CajasPorSucursal { get; set; }
        
        public CacheModel()
        {
            Cajas = new Dictionary<Guid, Caja>();
            CajasPorSucursal = new Dictionary<int, IList<Caja>>();
        }
    }
}
