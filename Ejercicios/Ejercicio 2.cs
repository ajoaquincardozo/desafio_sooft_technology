/*
Teniendo en cuenta la librería ICache, que fue escrita e implementada por otro equipo y utiliza una cache del tipo Key Value,
tomar la clase CajaRepository y modificar los métodos AddAsync, GetAllAsync, GetAllBySucursalAsync y GetOneAsync para que utilicen cache.

Datos:
    * Existen en la empresa 20 sucursales
    * Como mucho hay 100 cajas en la base

Restricción:
	* Solo es posible utilizar 1 key (IMPORTANTE)

Aclaración:
	* No realizar una implementación de ICache, otro equipo la esta brindando
*/

public interface ICache
{
    Task AddAsync<T>(string key, T obj, int? durationInMinutes);
    Task<T> GetOrDefaultAsync<T>(string key);
    Task RemoveAsync(string key);
}

public class CajaRepository
{
    private readonly DataContext _db;

    public CajaRepository(DataContext db)
    => _db = db ?? throw new ArgumentNullException(nameof(DataContext));

    public async Task AddAsync(Entities.Caja caja)
    {
        await _db.Cajas.AddAsync(caja);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Entities.Caja>> GetAllAsync()
    {
        return await _db.Cajas.ToListAsync()
    }

    public async Task<IEnumerable<Entities.Caja>> GetAllBySucursalAsync(int sucursalId)
    {
        return await _db.Cajas
            .Where(x => x.SucursalId == sucursalId)
            .ToListAsync()
    }

    public async Task<Entities.Caja> GetOneAsync(Guid id)
    {
        return await _db.Cajas.FirstOrDefaultAsync(x => x.Id == id);
    }
}