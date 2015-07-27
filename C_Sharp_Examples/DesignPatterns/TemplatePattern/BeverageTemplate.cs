using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples.DesignPatterns.TemplatePattern
{
    /// <summary>
    /// Template Pattern: Defines a skeleton of an algorithm in a method, 
    /// deferring some steps to the subclasses. Template Method lets subclasses 
    /// redefine certain steps of an algorithm without changing the algorithm’s 
    /// structure.
    /// </summary>
    public abstract class BeverageTemplate
    {
        protected StringBuilder outputs = new StringBuilder();
        /// <summary>
        /// PrepareRecipe contains the template for the algorithm
        /// </summary>
        public void PrepareRecipe()
        {
            Boilwater();
            Brew();
            PourInCup();
            AddCondiments();
            Hook();
        }

        /// <summary>
        /// A concrete algorithm for BoilWater; all subclasses will use this exact
        /// algorithm
        /// </summary>
        private void Boilwater()
        {
            outputs.AppendLine("Boiling Water");
        }

        /// <summary>
        /// Subclass will have to implement its own algorithm for Bew
        /// </summary>
        public abstract void Brew();

        private void PourInCup()
        {
            outputs.AppendLine("Pouring into Cup");
        }

        public abstract void AddCondiments();

        /// <summary>
        /// Hooks are optional methods that can be overridden in the subclass
        /// </summary>
        /// <returns></returns>
        public virtual bool Hook()
        { 
            return true;
        }

        public override string ToString()
        {
            return outputs.ToString();
        }
    }
}
