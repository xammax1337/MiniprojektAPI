using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MiniprojektAPI.Data;
using MiniprojektAPI.Models;
using MiniprojektAPI.Models.DTO;
using System;
using System.Net;

namespace MiniprojektAPI.Handlers
{
    public class InterestHandler
    {
        public static IResult CreateInterest(ApplicationContext context, InterestDto interest)
        {
            context.Interests.Add(new Interest()
            {
                Title = interest.Title,
                Description = interest.Description,
            });
            context.SaveChanges();

            return Results.StatusCode((int)HttpStatusCode.Created);
        }

        public static IResult AddWebsiteLink(ApplicationContext context, string interestTitle, InterestDto interestDto)
        {
            PersonInterest? personInterest = context.PersonInterests
                    .Include(pi => pi.Interest)
                    .SingleOrDefault(pi => pi.Interest.Title == interestTitle);

            if (personInterest == null)
            {
                return Results.NotFound("PersonInterest not found.");
            }

            personInterest.WebsiteLink = interestDto.WebsiteLink;

            context.SaveChanges();

            return Results.StatusCode((int)HttpStatusCode.Created);
        }

        public static IResult AddInterestToPerson(ApplicationContext context, int personId, string interestTitle)
        {
            Person? person = context.Persons
                .Include(p => p.PersonInterests)
                .SingleOrDefault(p => p.PersonId == personId);

            if (person == null)
            {
                return Results.NotFound("Person not found.");
            }

            Interest? interest = context.Interests
                .SingleOrDefault(i => i.Title == interestTitle);

            if (interest == null)
            {
                return Results.NotFound("Interest not found.");
            }

            if (person.PersonInterests.Any(pi => pi.InterestId == interest.InterestId))
            {
                return Results.BadRequest($"Person already has the interest '{interestTitle}'.");
            }

            PersonInterest personInterest = new PersonInterest
            {
                Person = person,
                Interest = interest,
            };

            person.PersonInterests.Add(personInterest);
            context.SaveChanges();
            return Results.StatusCode((int)HttpStatusCode.Created);
        }
    }
}
