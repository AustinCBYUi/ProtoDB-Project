using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src
{
    internal abstract class PlannerParent
    {

        /// <summary>
        /// Poly class that is used to create a new class.
        /// </summary>
        protected abstract ProgramClass CreateNewClass(string className);


        /// <summary>
        /// Poly class that is used to create a new inherited class.
        /// </summary>
        protected abstract ProgramClass CreateNewInheritedClass(string parentClass, string childClass);
    }
}
