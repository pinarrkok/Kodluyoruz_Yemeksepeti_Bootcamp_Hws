using Logging.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Entities.Concrete
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
