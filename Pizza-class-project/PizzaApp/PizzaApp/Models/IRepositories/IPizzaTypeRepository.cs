using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.IRepositories
{
    public interface IPizzaTypeRepository
    {
        PizzaType Get(int id);
        IEnumerable<PizzaType> GetAll();
        PizzaType Add(PizzaType pizza);
        PizzaType Update(PizzaType pizza);
        PizzaType Delete(int id);
    }
}
