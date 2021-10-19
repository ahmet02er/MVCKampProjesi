using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SkillCard
    {
        [Key]
        public int SkillId { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string UserDescription { get; set; }
        public string UserImage { get; set; }
        [StringLength(30)]
        public string Skill1 { get; set; }
        public int SkillRatio1 { get; set; }
        [StringLength(30)]
        public string Skill2 { get; set; }
        public int SkillRatio2 { get; set; }
        [StringLength(30)]
        public string Skill3 { get; set; }
        public int SkillRatio3 { get; set; }
        [StringLength(30)]
        public string Skill4 { get; set; }
        public int SkillRatio4 { get; set; }
        [StringLength(30)]
        public string Skill5 { get; set; }
        public int SkillRatio5 { get; set; }
        [StringLength(30)]
        public string Skill6 { get; set; }
        public int SkillRatio6 { get; set; }
        [StringLength(30)]
        public string Skill7 { get; set; }
        public int SkillRatio7 { get; set; }
        [StringLength(30)]
        public string Skill8 { get; set; }
        public int SkillRatio8 { get; set; }
        [StringLength(30)]
        public string Skill9 { get; set; }
        public int SkillRatio9 { get; set; }
        [StringLength(30)]
        public string Skill10 { get; set; }
        public int SkillRatio10 { get; set; }
    }
}
