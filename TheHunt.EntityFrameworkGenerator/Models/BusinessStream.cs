using System;
using System.Collections.Generic;

namespace TheHunt.EntityFrameworkGenerator.Models
{
    public partial class BusinessStream
    {
        public BusinessStream()
        {
            Company = new HashSet<Company>();
        }

        public int Id { get; set; }
        public string BusinessStreamName { get; set; }

        public ICollection<Company> Company { get; set; }
    }
}
