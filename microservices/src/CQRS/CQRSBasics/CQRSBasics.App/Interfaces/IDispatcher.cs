using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSBasics.App.Interfaces
{
    public interface IDispatcher
    {
        void Send<T>(T Command) where T : ICommand;
    }
}
