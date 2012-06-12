using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsNPerices
{

    public class ClientOfTheAlogrithm
    {
        private TemplateMethodPattern templatePattern;

        public void UseItWithFirst()
        {
            templatePattern = new OneImplementationOfAlgorithm();

            templatePattern.DoAlgorithm();
        }
    }

    public abstract class TemplateMethodPattern
    {
        public void DoAlgorithm()
        {
            NoneConfigurable();
            Configurable();
        }

        private void NoneConfigurable()
        {
            Debug.WriteLine("none configurable step called");
        }

        public abstract void Configurable();
    }

    public class OneImplementationOfAlgorithm : TemplateMethodPattern
    {
        public override void Configurable()
        {
            Debug.WriteLine("Configurable stuff in alog one");
        }
    }
    public class TwoInplentationOfAloritgh : TemplateMethodPattern
    {
        public override void Configurable()
        {
            Debug.WriteLine("Configurable stuff in alog two");
        }
    }
}
