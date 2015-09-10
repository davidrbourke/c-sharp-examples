using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples
{
    public class ConstructorExamples
    {

        public void SimpleSubClassExample()
        {
            // The base class constructor is called first
            // The sub class constructor is called second
            BSub bsub = new BSub();

            // Calling a base class ctr and passing the ctr parameter
            BSubWithData bsubWithData = new BSubWithData("hello world");

            // Calling the member hidding method that uses the new keyword
            int valueIsTwoFromSubClassMethod = bsub.BaseMethodOne();
            // Cast to sub class
            int valueChangesToOneFromBaseClassMethod = ((ABase)bsub).BaseMethodOne();

            // Calling the override method (base class has virtual keyword)
            int valueIsFourFromSubClassMethod = bsub.BaseMethodTwo();
            // Cast to sub class
            int valueIsStillFourFromSubClassMethod = ((ABase)bsub).BaseMethodTwo();


        }
        
    }

    public class ABase
    {
        public ABase()
        {
            int i = 0;
        }

        public int BaseMethodOne()
        {
            return 1;
        }

        public virtual int BaseMethodTwo()
        {
            return 3;
        }
    }
    public class BSub : ABase
    {
        public BSub()
        {
            int i = 1;
        }

        public new int BaseMethodOne()
        {
            return 2;
        }

        public override int BaseMethodTwo()
        {
            return 4;
        }


    }


    public class ABaseWithData
    {
        private string _myData;

        public ABaseWithData(string data)
        {
            _myData = data;
        }
    }
    public class BSubWithData : ABaseWithData
    {
        private string _myData;

        public BSubWithData() : this("hi")
        {
        }

        public BSubWithData(string data) : base(data)
        {
            _myData = data;
        }
    }

    public interface ICInterface
	{
		int DoSomething();
	}

    public class CClass<T> where T : ICInterface
    {
        private T _t;
        public CClass (T t)
    	{
            _t = t;
    	}
    }
}
