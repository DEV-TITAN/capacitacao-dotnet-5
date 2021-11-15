using System.Threading.Tasks;
using LojaTitanica.Data;
using LojaTitanica.Models;

namespace LojaTitanica.Services
{
    public class DBService
    {
        public readonly MySQLContext _db;

        public DBService(MySQLContext context)
        {
            _db = context;
        }

        public async Task<bool> CriarProduto(Produto produto)
        {
            _db.Add<Produto>(produto);
            int changes = await _db.SaveChangesAsync();
            if (changes >= 1) 
            {
                return true;
            }
            return false;
        }
    }
}