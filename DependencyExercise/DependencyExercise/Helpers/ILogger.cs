using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyExercise.BLL;

namespace DependencyExercise.Helpers
{
    public interface ILogger
    {
        void Log(string message);
    }
}
