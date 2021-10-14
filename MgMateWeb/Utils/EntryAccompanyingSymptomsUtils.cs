using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MgMateWeb.Interfaces.MapperInterfaces;
using MgMateWeb.Interfaces.PersistenceInterfaces;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.RelationshipModels;

namespace MgMateWeb.Utils
{
    
    public class EntryAccompanyingSymptomsUtils : IEntryAccompanyingSymptomsUtils
    {
        #region Fields and constants

        private readonly IEntriesControllerUtils _entriesControllerUtils;
        private readonly IEntryAccompanyingSymptomMapper _entryAccompanyingSymptomMapper;
        private readonly IUnitOfWork _unitOfWork;

        public EntryAccompanyingSymptomsUtils(
            IEntriesControllerUtils entriesControllerUtils, 
            IEntryAccompanyingSymptomMapper entryAccompanyingSymptomMapper, 
            IUnitOfWork unitOfWork)
        {
            _entriesControllerUtils = entriesControllerUtils 
                                      ?? throw new ArgumentNullException(nameof(entriesControllerUtils));
            _entryAccompanyingSymptomMapper = entryAccompanyingSymptomMapper 
                                              ?? throw new ArgumentNullException(nameof(entryAccompanyingSymptomMapper));
            _unitOfWork = unitOfWork 
                          ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        #endregion


        public async Task<List<EntryAccompanyingSymptom>> CreateEntryAccompanyingSymptomAsync(
            IEnumerable<int> selectedSymptoms,
            Entry entryReloaded)
        {
            var entryAccompanyingSymptoms = new List<EntryAccompanyingSymptom>();

            foreach (var selectedSymptom in selectedSymptoms)
            {
                var symptom = await _entriesControllerUtils
                    .FindAccompanyingSymptomById(selectedSymptom)
                    .ConfigureAwait(false);

                var entryAccompanyingSymptom =
                    await _entryAccompanyingSymptomMapper
                        .MapEntryAccompanyingSymptomAsync(entryReloaded, symptom)
                        .ConfigureAwait(false);

                await _unitOfWork.EntryAccompanyingSymptoms
                    .AddAsync(entryAccompanyingSymptom)
                    .ConfigureAwait(false);

                await _unitOfWork
                    .CompleteAsync()
                    .ConfigureAwait(false);

                entryAccompanyingSymptoms.Add(entryAccompanyingSymptom);
            }

            return await Task.FromResult(entryAccompanyingSymptoms);
        }

    }
}