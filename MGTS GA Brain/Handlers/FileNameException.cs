using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGTS_GA_Brain.Handlers
{
    class FileNameException : Exception
    {
        public FileNameException() : base()
        {

        }

        public FileNameException(string message) : base(message)
        {

        }

        public FileNameException(string message, Exception inner) : base(message,inner)
        {

        }

    }
}
