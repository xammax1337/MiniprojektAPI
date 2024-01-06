using MiniprojektAPI.Data;
using MiniprojektAPI.Handlers;
using Microsoft.EntityFrameworkCore;
using MiniprojektAPI.Models.DTO;

namespace MiniprojektAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("ApplicationContext");
            builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString));
            var app = builder.Build();

            //List all persons with Full Name and Phonenumber
            app.MapGet("/person", PersonHandler.ListPersons);

            //View Specific persons Interests with that persons links
            app.MapGet("/person/{id}", PersonHandler.ViewPersonInterests);

            //Create a new Person
            app.MapPost("/person/create", PersonHandler.CreatePerson);

            //Create a new Interest
            app.MapPost("/interest/create", InterestHandler.CreateInterest);

            //Add Interest to a specific person wiht their personID and Interest Title
            app.MapPost("/person/connect", (ApplicationContext context, PersonInterestDto personInterestDto) =>
            {
                return InterestHandler.AddInterestToPerson(context, personInterestDto.PersonId, personInterestDto.InterestTitle);
            });


            //Add a link to a specific Interest
            app.MapPost("/interest/links/{interestTitle}", InterestHandler.AddWebsiteLink);

            app.Run();
        }
    }

    //View all Persons *
    //View all Interests for a Person *
    //View all links for a Person * 
    //Add person *
    //Add interest *
    //Link a person to a Interest * 
    //Add new website links to a persons interest *
}