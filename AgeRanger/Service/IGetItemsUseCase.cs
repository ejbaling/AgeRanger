using AgeRanger.Models;
using System.Collections.Generic;

namespace AgeRanger.Service
{
    public interface IGetItemsUseCase
    {
        IEnumerable<PersonAgeGroup> Execute(string searchTerm);
    }
}
