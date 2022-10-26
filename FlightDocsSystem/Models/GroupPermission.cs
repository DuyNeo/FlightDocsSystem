using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightDocsSystem.Models
{
    public class GroupPermission
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime createdDate { get; set; }
        public string Note { get; set; }
        public List<Users> users { get; set; }
    }
}
