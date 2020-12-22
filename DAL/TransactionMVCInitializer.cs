using Bogus;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{ 
    public class TransactionMVCInitializer : DropCreateDatabaseAlways<TransactionMVCContext>
    {
        public void Initialize(TransactionMVCContext context)
        {
            var faker = new Faker();
            var categoryBogus = new Faker<Category>()
                .RuleFor(c => c.Title, f => f.Lorem.Word())
                .RuleFor(c => c.CreatedDate, f => DateTime.Now)
                .RuleFor(c => c.UpdatedDate, f => DateTime.Now);

            var categories = categoryBogus.Generate(faker.Random.Number(20, 30));
            var transactionBogus = new Faker<Transaction>()
                .RuleFor(c => c.Title, f => f.Lorem.Word())
                .RuleFor(c => c.Description, f => f.Lorem.Paragraph())
                .RuleFor(c => c.Value, f => f.Random.Decimal() + f.Random.Number(-100000, 100000))
                .RuleFor(c => c.CreatedDate, f => DateTime.Now)
                .RuleFor(c => c.UpdatedDate, f => DateTime.Now)
                .RuleFor(c => c.CategoryId, f => f.Random.Number(1,categories.Count()));
                
            var transactions = transactionBogus.Generate(faker.Random.Number(20, 30));

            

            context.Categories.AddRange(categories);
            context.SaveChanges();
            context.Transactions.AddRange(transactions);
            context.SaveChanges();
        }

        protected override void Seed(TransactionMVCContext ctx)
        {
            Initialize(ctx);
        }
    }
}
