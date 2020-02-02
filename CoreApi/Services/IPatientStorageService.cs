using CoreApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Services
{
    public interface IPatientStorageService
    {
        Task<bool> Add(PatientModel model);

        Task<bool> Delete(PatientModel model);

        Task<bool> Update(PatientModel model);
        
    }
}
