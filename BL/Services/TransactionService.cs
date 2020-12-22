using AutoMapper;
using BL.Models;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface ITransactionService
    {
        void Create(TransactionBLModel model);

        void DeleteById(int id);

        void Edit(TransactionBLModel model);

        TransactionBLModel GetById(int id);


        IEnumerable<TransactionBLModel> GetTransactions();
    }

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<BLAutoMapperProfile>());

            _mapper = new Mapper(mapperConfig);
        }

        public TransactionService()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<BLAutoMapperProfile>());
            _transactionRepository = new TransactionRepository();
            _mapper = new Mapper(mapperConfig);
        }

        public void Create(TransactionBLModel model)
        {
            var transaction = _mapper.Map<Transaction>(model);
            _transactionRepository.Create(transaction);
        }

        public void DeleteById(int id)
        {
            _transactionRepository.DeleteById(id);
        }

        public TransactionBLModel GetById(int id)
        {
            var transaction = _transactionRepository.GetById(id);

            return _mapper.Map<TransactionBLModel>(transaction);
        }

        public IEnumerable<TransactionBLModel> GetTransactions()
        {
            var transactions = _transactionRepository.GetTransactions();
            return _mapper.Map<IEnumerable<TransactionBLModel>>(transactions);
        }

        public void Edit(TransactionBLModel model)
        {
            var transaction = _mapper.Map<Transaction>(model);
            _transactionRepository.Edit(transaction);
        }
    }
}
