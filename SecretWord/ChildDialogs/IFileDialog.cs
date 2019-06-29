using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretWord.ChildDialogs
{
    interface IFileDialog
    {
        string Save();
        string Load();
    }
}
