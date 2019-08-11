using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entities
{
    [Table("StorageIdentities")]
    public class StorageIdentityEF
    {
        public int Id { get; set; }
        public int BlockType { get; set; }
        public int ParticipantType { get; set; }
        public int ParticipantId { get; set; }
    }
}
