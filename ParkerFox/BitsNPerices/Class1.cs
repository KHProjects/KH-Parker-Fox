using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsNPerices
{


  public class Person
  {
    private DoSomething doSomething;
  }

  public abstract class DoSomething
  {

    public void DoAlgorithm()
    {
      NonConfigurable();
      Configurable();
    }

    private void NonConfigurable()
    {
      Debug.WriteLine("non configurable step called");
    }

    public abstract void Configurable();

  }

  public class OneImplementationOfDoSomething : DoSomething
  {
    public override void Configurable()
    {
      Debug.WriteLine("Configurable stuff in implementation one");
    }
  }
  public class AnotherImplentationOfDoSomething : DoSomething
  {
    public override void Configurable()
    {
      Debug.WriteLine("Configurable stuff in a implementation two");
    }
  }




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
            NonConfigurable();
            Configurable();
        }

        private void NonConfigurable()
        {
            Debug.WriteLine("non configurable step called");
        }

        public abstract void Configurable();
    }

    public class OneImplementationOfAlgorithm : TemplateMethodPattern
    {
        public override void Configurable()
        {
            Debug.WriteLine("Configurable stuff in implementation one");
        }
    }
    public class TwoInplentationOfAloritgh : TemplateMethodPattern
    {
        public override void Configurable()
        {
          Debug.WriteLine("Configurable stuff in implementation two");
        }
    }
}
