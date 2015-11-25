using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsculabsCommon
{
    public enum PatientGender
    {
        Male,
        Female
    };

    public interface IPatient
    {
        int Id { get; }

        string FullNameString { get; }

        string FirstName { get; }

        string MiddleName { get; }

        string LastName { get; }

        DateTime Birthdate { get; }

        string Iin { get; }

        PatientGender Gender { get; }

        int? BloodGroup { get; }

        bool? RhFactor { get; }
    }
}
