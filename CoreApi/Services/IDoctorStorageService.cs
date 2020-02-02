using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiModels;

namespace CoreApi.Services
{
    public interface IDoctorStorageService
    {
        Task<bool> Add(DoctorModel model);

        Task<bool> Delete(DoctorModel model);

        Task<bool> Update(DoctorModel model);


    }
}
