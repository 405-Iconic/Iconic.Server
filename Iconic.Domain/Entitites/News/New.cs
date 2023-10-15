using Iconic.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Domain.Entitites.News
{
    public class New : Auditable
    {
        public int BannerId { get; set; }
        public Attachment Banner {  get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Gallery> Galleries { get; set; }
    }
}
