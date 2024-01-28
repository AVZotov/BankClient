using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientUI.Models
{
    internal class Worker : IWorker
    {
        public string GetAccess() => "worker";
    }
}
