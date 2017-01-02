using System.Collections.Generic;

namespace BakkalAPI.Models
{
    public class BucketModel
    {
        public string BakkalId { get; set; }

        public List<string> products { get; set; }
        
        public string TotalAmount { get; set; }
    }
}