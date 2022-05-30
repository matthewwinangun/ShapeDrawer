using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    /// <summary>
    /// An interface that contains an "execute" method that all command object must implement.
    /// </summary>
    public interface Command
    {
        void Execute(Gui gui);
    }
}
