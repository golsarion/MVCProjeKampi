using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WriterSkill
    {
        [Key]
        [Column(Order =1)]
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }
        [Key]
        [Column(Order =2)]
        public int SkillID { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
