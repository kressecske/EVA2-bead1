using Labyrinth.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Data
{
    interface IDataCommunication
    {
        ALevel loadLevel(String path);
    }
}
