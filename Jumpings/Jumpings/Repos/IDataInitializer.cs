using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpings.Repos
{
    public interface IDataInitializer
    {
        void InitializeData(JumpingsContext context);
    }
}
