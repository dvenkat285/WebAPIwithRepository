using WebAPIwithRepository.Data;
using WebAPIwithRepository.Models;
using WebAPIwithRepository.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace WebAPIwithRepository.Repositories.Implementations
{
    public class PatientRepository : IPatient
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext db)
        {
            _context = db;
        }

        // Create a new patient
        public int CreatePatient(Patient patient)
        {
            if (patient == null)
            {
                return 0; // Return 0 if the patient object is null.
            }

            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient.Id; // Return the ID of the newly created patient.
        }

        // Delete a patient by ID
        public int DeletePatient(int id)
        {
            var patient = _context.Patients.FirstOrDefault(x => x.Id == id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
                return id; // Return the ID of the deleted patient.
            }
            return -1; // Return -1 if the patient was not found.
        }

        // Get all patients
        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        // Get a specific patient by ID
        public Patient GetPatientById(int id)
        {
            return _context.Patients.FirstOrDefault(x => x.Id == id);
        }

        // Update an existing patient
        public int UpdatePatient(Patient patient)
        {
            if (patient == null)
            {
                return -1; // Return -1 if the patient object is null.
            }

            var existingPatient = _context.Patients.FirstOrDefault(x => x.Id == patient.Id);
            if (existingPatient != null)
            {
                existingPatient.FirstName = patient.FirstName;
                existingPatient.LastName = patient.LastName;
                existingPatient.Age = patient.Age;
                existingPatient.Address = patient.Address;
                existingPatient.PatientType = patient.PatientType;
                existingPatient.bednum = patient.bednum;
                existingPatient.diagnosis = patient.diagnosis;

                _context.SaveChanges();
                return existingPatient.Id; // Return the ID of the updated patient.
            }
            return -1; // Return -1 if the patient was not found.
        }

        // Dispose the context
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
