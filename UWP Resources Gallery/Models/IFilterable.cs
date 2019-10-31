using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPResourcesGallery.Models
{
    public interface IFilterable
    {
        bool FitsFilter(string[] keywords);
    }
}
