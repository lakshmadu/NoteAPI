using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using NoteAPI.Models;

namespace NoteAPI.DataAccess 
{
    public static class PrepDB
    {
        public static void  PrepPopulation(IApplicationBuilder app){
            using(var serviceScope = app.ApplicationServices.CreateScope()){
                SeedData(serviceScope.ServiceProvider.GetService<NoteDbContext>());
            }
        }

        public static void SeedData(NoteDbContext context)
        {
            System.Console.WriteLine("Appling Migrations...");

            context.Database.Migrate();
            if(!context.Notes.Any()){
                System.Console.WriteLine("Adding Data - Seeding ....");
                context.Notes.AddRange(
                    new Note() {NoteLine="Hello"},
                    new Note() {NoteLine="Hi"},
                    new Note() {NoteLine="Ayubowan"},
                    new Note() {NoteLine="Wellcome"},
                    new Note() {NoteLine="Greetings"}
                );
                context.SaveChanges();
            }else{
                System.Console.WriteLine("Already have data  - not seeding");
            }
        } 

    }
}