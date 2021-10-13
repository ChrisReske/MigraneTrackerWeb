using System;
using System.Linq;
using System.Threading.Tasks;
using MgMateWeb.Interfaces.PersistenceInterfaces;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;
using MgMateWeb.Models.RelationshipModels;
using MgMateWeb.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MgMateWeb.Utils
{
    public class EntriesControllerUtils : IEntriesControllerUtils
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;


        public EntriesControllerUtils(
            ApplicationDbContext context, 
            IUnitOfWork unitOfWork)
        {
            _context = context;
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
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Entry> ReloadEntryAsync()
        {
            var entryReloaded = await _context.Entries
                .OrderByDescending(entry => entry.CreationDate)
                .FirstOrDefaultAsync().ConfigureAwait(false);
            return entryReloaded;
        }

        public async Task<AccompanyingSymptom> FindAccompanyingSymptomById(int selectedSymptom)
        {
            if (selectedSymptom <= 0)
            {
                return new AccompanyingSymptom();
            }

            var symptom = await _context.AccompanyingSymptoms
                .FindAsync(selectedSymptom)
                .ConfigureAwait(false);
            return symptom;
        }

        public async Task<EntryAccompanyingSymptom> CreateEntryAccompanyingSymptom(
            Entry entryReloaded,
            AccompanyingSymptom symptom)
        {
            if (entryReloaded is null
                || symptom is null)
            {
                return new EntryAccompanyingSymptom();
            }

            var entryAccompanyingSymptom = new EntryAccompanyingSymptom
            {
                Entry = entryReloaded,
                EntryId = entryReloaded.Id,
                AccompanyingSymptom = symptom,
                AccompanyingSymptomId = symptom.Id
            };

            return await Task
                .FromResult(entryAccompanyingSymptom)
                .ConfigureAwait(false);
        }


        public async Task<Entry> CreateInitialEntryAsync(CreateEntryFormModel createEntryFormModel)
        {
            if (createEntryFormModel is null)
            {
                return new Entry();
            }

            var entry = new Entry()
            {
                CreationDate = DateTime.Now,
                HoursOfActivity = createEntryFormModel.HoursOfActivity,
                HoursOfIncapacitation = createEntryFormModel.HoursOfIncapacitation,
                HoursOfPain = createEntryFormModel.HoursOfPain,
                WasPainIncreasedDuringPhysicalActivity = createEntryFormModel.WasPainIncreasedDuringPhysicalActivity
            };
            return await Task
                .FromResult(entry)
                .ConfigureAwait(false);
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