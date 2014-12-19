using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTagger.EktronSample.Alchemy.Models
{
    public class AlchemyResponse
    {
        public string status { get; set; }
        public string language { get; set; }
        public string url { get; set; }
        public string statusInfo { get; set; }
        public List<AlchemyConcept> concepts { get; set; }

        public AlchemyResponse()
        {
            this.status = string.Empty;
            this.language = string.Empty;
            this.url = string.Empty;
            this.statusInfo = string.Empty;
            this.concepts = new List<AlchemyConcept>();
        }
    }
}
