﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Core.Messaging
{
    public interface IHandleCommand<TCommand>
    {
        void Handle(TCommand command);
    }
}