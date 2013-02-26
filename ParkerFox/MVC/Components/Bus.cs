using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Components
{
    public class RegisterContorller
    {
        public void index()
        {
            
        }
    }


    public class Bus
    {
        //ninject.Bind<IHandleCommand<RegUserCommand>>().To<RegUserCommandHandler>();

        //public void Send<T>(T command)
        //{
        //    var handler = ninecjt.GetMyhandleFor(command);
        //    handler.Handlr(command);
        //}

        public void Handle(object command)
        {
            

        }
    }

    public class RegUserCommand
    {
    }

    public interface IHandleCommand<T>
    {
        void Handle(T command);
    }

    public class RegUserCommandHandler : IHandleCommand<RegUserCommand>
    {
        public void Handle(RegUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}