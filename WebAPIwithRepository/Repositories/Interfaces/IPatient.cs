using WebAPIwithRepository.Models;

namespace WebAPIwithRepository.Repositories.Interfaces
{
    public interface IPatient : IDisposable
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int id);
        int CreatePatient(Patient patient);
        int UpdatePatient(Patient patient);
        int DeletePatient(int id);
    }
}
