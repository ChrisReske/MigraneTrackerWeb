using System;
using System.Threading.Tasks;
using MgMateWeb.Interfaces.PersistenceInterfaces;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Utils
{
    public class EntriesControllerUtils : IEntriesControllerUtils
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntriesControllerUtils(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> SaveEntryToDbAsync(Entry entry)
        {
            if (entry is null)
            {
                return false;
            }

            try
            {
                await _unitOfWork.Entries.AddAsync(entry);
                await _unitOfWork
                    .CompleteAsync()
                    .ConfigureAwait(false);

                return await Task
                    .FromResult(true)
                    .ConfigureAwait(false);

            }
            catch (Exception e)
            {
                // Todo: Add logging
                Console.WriteLine(e);
            }

            return false;
        }


        public async Task<AccompanyingSymptom> FindAccompanyingSymptomById(int selectedSymptom)
        {
            if (selectedSymptom <= 0)
            {
                return new AccompanyingSymptom();
            }

            var symptom = await _unitOfWork
                .AccompanyingSymptoms
                .GetAsync(selectedSymptom)
                .ConfigureAwait(false);

            return symptom;
        }

        public async Task<bool> EntryExists(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            return await _unitOfWork
                .Entries
                .CheckIfAnyAsync(e => e.Id == id)
                .ConfigureAwait(false);
        }

    }
}