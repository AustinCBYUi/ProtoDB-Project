using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src
{
    /// <summary>
    /// An abstract class that stores a few methods to organize potential polymorphism practices.
    /// </summary>
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


        /// <summary>
        /// Poly class that is used to create a new attribute as a field editor
        /// </summary>
        /// <param name="attrName">Name of the attribute</param>
        /// <returns>A ProgramFields object</returns>
        protected abstract ProgramFields CreateNewAttribute(string attrName);


        /// <summary>
        /// Poly class that is used to create a new constructor as a field editor with optional parameters.
        /// </summary>
        /// <param name="conName">Name of the constructor</param>
        /// <param name="optionalparam">Optional parameters for constructor</param>
        /// <returns>A ProgramFields Object</returns>
        protected abstract ProgramFields CreateNewConstructor(string conName, string optionalparam = "None");


        /// <summary>
        /// Poly class that is used to create a new method as a field editor with optional parameters and return type.
        /// </summary>
        /// <param name="methName">Name of the method</param>
        /// <param name="optionalparam">Optional parameters for the method</param>
        /// <param name="optionalreturn">Optional return type for the method</param>
        /// <returns>A ProgramFields Object</returns>
        protected abstract ProgramFields CreateNewMethod(string methName, string optionalparam = "None", string optionalreturn = "void");
    }
}
