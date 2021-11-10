using System;
using System.Collections.Generic;

#nullable disable

namespace FrameworkProject.Models
{
    public partial class Notification
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string NotifiableType { get; set; }
        public long NotifiableId { get; set; }
        public string Data { get; set; }
        public DateTime? ReadAt { get; set; }
    }
}
