using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accentdesign.AA.Share.Model.Startup
{
    public interface IDatabaseSeeder 

    {
    public Task Seed (int count);
    }
}
