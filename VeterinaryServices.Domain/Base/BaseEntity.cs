using System; //Usado para las fechas; retirarse cuando se haga(n) un(los) test(s)

namespace VeterinaryServices.Domain.Base
{
    public class BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}