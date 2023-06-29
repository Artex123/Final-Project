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

        public void AddSupercar(Supercar supercarToAdd)
        {
            _conn.Execute("insert into supercars (brand, model, horsepower, top_speed, price) values (@brand, @model, @horsepower, @top_speed, @price)",
                new { brand = supercarToAdd.Brand, model = supercarToAdd.Model, horsepower = supercarToAdd.Horsepower, top_speed = supercarToAdd.Top_speed, price = supercarToAdd.Price });
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

        public void RemoveSupercar(Supercar supercarToRemove)
        {
            _conn.Execute("DELETE from games where id = @id", new { id = supercarToRemove.Id });
        }

        public void UpdateSupercar(Supercar supercar)
        {
            _conn.Execute("UPDATE supercars SET Brand = @brand, Horsepower = @horsepower, Top_Speed = @top_speed, Price = @price WHERE id = @id",
            new { brand = supercar.Brand,horsepower = supercar.Horsepower,top_speed = supercar.Top_speed, price = supercar.Price, id = supercar.Id });
        }
    }
}
