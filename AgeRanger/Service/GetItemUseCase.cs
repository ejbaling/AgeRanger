
using System;
using System.Collections.Generic;
using System.Linq;
using AgeRanger.Models;
using AgeRanger.Repository;

namespace AgeRanger.Service
{
    public class GetItemUseCase : IGetItemsUseCase
    {
        public IEnumerable<PersonAgeGroup> Execute(string searchTerm)
        {
            using (var dataContext = new AgeRangerContext())
            {
                var people = dataContext.People.AsQueryable();
                var ageGroups = dataContext.AgeGroups.AsQueryable();

                var result = from p in people
                    from a in ageGroups
                    where
                        (p.Age >= a.MinAge || a.MinAge == null || (a.MinAge*1) == 0) &&
                        (p.Age < a.MaxAge || a.MaxAge == null || (a.MaxAge*1) == 0)
                    select
                        new
                        {
                            Id = p.Id,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            Age = p.Age,
                            Description = a.Description
                        };

                if (!String.IsNullOrWhiteSpace(searchTerm))
                {
                    result =
                        result.Where(
                            p =>
                                p.FirstName.ToLower().Contains(searchTerm.ToLower()) ||
                                p.LastName.ToLower().Contains(searchTerm.ToLower()));
                }

                return
                    result.Select(
                        r =>
                            new PersonAgeGroup
                            {
                                Id = r.Id,
                                FirstName = r.FirstName,
                                LastName = r.LastName,
                                Age = r.Age,
                                Description = r.Description
                            }).ToArray();
            }
        }
    }
}