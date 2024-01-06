using MiniprojektAPI.Data;
using MiniprojektAPI.Models;
using MiniprojektAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using MiniprojektAPI.Models.DTO;
using System.Net;

namespace MiniprojektAPI.Handlers
{
    public static class PersonHandler
    {
        public static IResult ListPersons(ApplicationContext context)
        {
            PersonViewModel[] result =
                context.Persons
                .Select(p => new PersonViewModel()
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Number = p.Number
                }).ToArray();
            return Results.Json(result);
        }

        public static IResult ViewPersonInterests(ApplicationContext context, int id)
        {
            Person? person =
                context.Persons
                .Where(p => p.PersonId == id)
                .Include(p => p.PersonInterests)
                    .ThenInclude(pi => pi.Interest)
                .SingleOrDefault();

            if (person == null)
            {
                return Results.NotFound();
            }

            PersonInterestViewModel result = new PersonInterestViewModel()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Interests = person.PersonInterests
                .Select(pi => new InterestViewModel()
                { 
                    Title = pi.Interest.Title,
                    Description = pi.Interest.Description,
                    WebsiteLink = pi.WebsiteLink,
                }).ToArray()
            };
            return Results.Json(result);
        }

        public static IResult CreatePerson(ApplicationContext context, PersonDto person)
        {
            context.Persons.Add(new Person()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Number = person.Number,
            });
            context.SaveChanges();
            return Results.StatusCode((int)HttpStatusCode.Created);
        }
    }
}
