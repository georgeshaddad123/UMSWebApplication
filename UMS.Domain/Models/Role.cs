using System.ComponentModel.DataAnnotations;
using Elasticsearch.Net;

namespace UMS.Domain.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter a name with at least 4 characters")]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}