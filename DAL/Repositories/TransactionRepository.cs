using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAL.Repositories
{
    public interface ITransactionRepository
    {
        void Create(Transaction model);

        void DeleteById(int id);

        Transaction GetById(int id);
        void Edit(Transaction model);
        IEnumerable<Transaction> GetTransactions();
    }

    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionMVCContext _ctx;

        public TransactionRepository()
        {
            _ctx = new TransactionMVCContext();
        }

        public void Create(Transaction model)
        {
            _ctx.Transactions.Add(model);

            _ctx.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = _ctx.Transactions.FirstOrDefault(x => x.Id == id);
            _ctx.Transactions.Remove(entity);

            _ctx.SaveChanges();
        }

        public void Edit(Transaction model)
        {
            _ctx.Entry(model).State = System.Data.Entity.EntityState.Modified;

            _ctx.SaveChanges();
        }

        public Transaction GetById(int id)
        {
            var transaction = _ctx.Transactions.FirstOrDefault(x => x.Id == id);

            return transaction;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _ctx.Transactions.Include(x=>x.Category).ToList();
        }
    }
}
