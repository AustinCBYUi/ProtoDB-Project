using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src
{
    /// <summary>
    /// Primary planner / parent class. Controls all primary behaviors.
    /// </summary>
    internal class ProgramPlanner
    {
        private string _programName;
        private bool _isInheritedClass;
        private List<ProgramClasses> _classes = new List<ProgramClasses>();
        private string _frameWorkUsed;
        private string _featuresText;
        private List<string> _applicationType = new List<string>();
    }
}
