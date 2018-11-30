using System;
using System.Collections.Generic;

namespace TheHunt.Host
{
    public partial class JobLocation
    {
        public JobLocation()
        {
            JobPost = new HashSet<JobPost>();
        }

        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }

        public ICollection<JobPost> JobPost { get; set; }
    }
}
