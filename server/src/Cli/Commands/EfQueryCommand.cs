using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oakton;
using Workshop.AccountsApi.Database;
using Workshop.AccountsApi.Domain;

namespace Cli.Commands
{
    public class EfQueryInput {}
    
    [Description("ef-query", Name = "ef-query")]
    public class EfQueryCommand : OaktonAsyncCommand<EfQueryInput>
    {
        public override async Task<bool> Execute(EfQueryInput input)
        {
            var dbContextFactory = Program.Resolve<IDbContextFactory<AccountsDbContext>>();

            await using var dbContext = dbContextFactory.CreateDbContext();

            var highestId = await dbContext
                .People
                .OrderByDescending(p => p.Id)
                .Select(p => p.Id)
                .FirstOrDefaultAsync();

            if (highestId == null)
            {
                highestId = new PersonId(1);
            }

            var person = new Person
            {
                Id = new PersonId(highestId.Value + 1) ,
                Name = "mick delaney",
                WebSite = "mickdelaney.com"
            };

            dbContext.People.Add(person);
            
            await dbContext.SaveChangesAsync();

            var loadedPerson = await dbContext.People.Where(p => p.Id == highestId).FirstOrDefaultAsync();

            var matches = loadedPerson.Name == person.Name;
            
            return false;
        }
    }
}