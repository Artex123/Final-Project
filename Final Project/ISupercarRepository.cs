using Final_Project.Models;

namespace Final_Project
{
    public interface ISupercarRepository
    {
        public IEnumerable<Supercar> GetAllSupercars();
        public Supercar GetSupercar(int id);
        public void UpdateSupercar(Supercar supercar);

        public void AddSupercar(Supercar supercarToAdd);

        public void RemoveSupercar(Supercar supercarToRemove);
    }
    
}
