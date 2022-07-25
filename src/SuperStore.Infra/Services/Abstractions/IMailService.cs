using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore.Infra.Services.Abstractions
{
    public interface IMailService
    {
        void Send(string email);
    }
}
