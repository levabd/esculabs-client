using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibrosis
{
    using ModuleFramework;
    using System.Windows.Controls;
    using Repositories;
    using System.Windows;

    public partial class FibrosisProvider : IModuleProvider
    {
        private Window _owner;
        private IPatient _patient;

        public string Name
        {
            get
            {
                return "Fibrosis";
            }
        }

        public FibrosisProvider(Window owner, IPatient patient)
        {
            _owner = owner;
            _patient = patient;

            var f = ExaminesRepository.Instance.Find(1);
        }

        public FibrosisWidget GetWidget()
        {
            return new FibrosisWidget(_owner);
        }
    }
}
