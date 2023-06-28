using Dapper;
using Final_Project.Models;
using System.Data;

namespace Final_Project
{
    public class SupercarRepository : ISupercarRepository
    {
        private readonly IDbConnection _conn;
        public SupercarRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Supercar> GetAllSupercars()
        {
            return _conn.Query<Supercar>("SELECT * FROM supercars;");
        }

        public Supercar GetSupercar(int id)
        {
            return _conn.QuerySingle<Supercar>("SELECT * FROM supercars WHERE id = @id", 
                new { id = id });
        }
    }
}
