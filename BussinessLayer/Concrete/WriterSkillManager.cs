using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class WriterSkillManager : IWriterSkillService
    {
        IWriterSkillDAL _writerSkillDAL;

        public WriterSkillManager(IWriterSkillDAL WriterSkillDAL)
        {
            _writerSkillDAL = WriterSkillDAL;
        }

        public List<Skill> GetWriterSkills(int wid)
        {
            var ws=_writerSkillDAL.List(x => x.WriterID == wid);
            List<Skill> skilllist=new List<Skill>();
            foreach (WriterSkill item in ws)
            {
                skilllist.Add(item.Skill);
            }
            return skilllist;
        }
    }
}
