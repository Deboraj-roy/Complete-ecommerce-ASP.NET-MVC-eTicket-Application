using eTicket.Data.Base;
using eTicket.Data.Services.IServices;
using eTicket.Models;

namespace eTicket.Data.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
    {
        public CinemaService(AppDbContext context) : base(context) { }
       
    }
}
