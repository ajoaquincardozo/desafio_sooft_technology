namespace SooftTechnologyChallengeEj4.Domain.Entities
{
    public class Sucursal : BaseEntity<int>
    {
        public string Direccion { get; }
        public string Telefono { get; }

        public Sucursal(int id, string direccion, string telefono)
        {
            Id = id;
            Direccion = direccion;
            Telefono = telefono;
        }
    }
}
