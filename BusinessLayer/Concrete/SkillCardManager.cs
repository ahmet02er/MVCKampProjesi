using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class SkillCardManager : ISkillCardService
    {
        ISkillCardDal _skillCardDal;

        public SkillCardManager(ISkillCardDal skillCardDal)
        {
            _skillCardDal = skillCardDal;
        }

        public void AboutAdd(SkillCard skillCard)
        {
            _skillCardDal.Insert(skillCard);
        }

        public void AboutDelete(SkillCard skillCard)
        {
            _skillCardDal.Delete(skillCard);
        }

        public void AboutUpdate(SkillCard skillCard)
        {
            _skillCardDal.Update(skillCard);
        }

        public SkillCard GetById(int id)
        {
            return _skillCardDal.Get(x => x.SkillId == id);
        }

        public List<SkillCard> GetList()
        {
            return _skillCardDal.List();
        }
    }
}
