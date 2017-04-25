using Notepad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Data
{
    public interface ITextSaver
    {
        Result Save(bool isNew, Content content);
        Content Load();
    }
}
