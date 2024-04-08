using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.ModelAccessLayer.Model
{
    public class Feature
    {
        public string NameFilter { get; set; }
        public List<string> Parameters { get; set; }

        public Feature()
        {
            Parameters = new List<string>();
        }
    }
}
