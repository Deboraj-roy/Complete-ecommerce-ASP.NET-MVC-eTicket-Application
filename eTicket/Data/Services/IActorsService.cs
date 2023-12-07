using eTicket.Models;

namespace eTicket.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();
        Actor GetById(int id);  
        void Add(Actor actor);
        Actor Update(int id, Actor newActor);
        void Delete(int id);
    }
}
