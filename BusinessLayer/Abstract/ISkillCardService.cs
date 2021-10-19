using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ISkillCardService
    {
        List<SkillCard> GetList();
        SkillCard GetById(int id);
        void AboutAdd(SkillCard skillCard);
        void AboutDelete(SkillCard skillCard);
        void AboutUpdate(SkillCard skillCard);
    }
}
