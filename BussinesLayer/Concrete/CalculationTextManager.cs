using BussinesLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class CalculationTextManager : ICalculationTextService
    {
        ICalculationTextDal _calculationTextDal;

        public CalculationTextManager(ICalculationTextDal calculationTextDal)
        {
            _calculationTextDal = calculationTextDal;
        }

        public void AddCalculationText(CalculationText calculationText)
        {
            _calculationTextDal.Insert(calculationText);
        }

        public void CalculationTextDelete(CalculationText calculationText)
        {
            _calculationTextDal.Delete(calculationText);
        }

        public void CalculationTextUpdate(CalculationText calculationText)
        {
            _calculationTextDal.Update(calculationText);
        }

        public List<CalculationText> GetAllCalculationText()
        {
            return _calculationTextDal.GetAll();
        }

        public List<CalculationText> GetCalculationTextById(int id)
        {
            return _calculationTextDal.GetListAll(x =>x.CalculationTextID==id); ;
        }

      
    }
}
