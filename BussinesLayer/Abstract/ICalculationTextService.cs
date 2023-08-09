using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface ICalculationTextService
    {
        void AddCalculationText(CalculationText calculationText);
        void CalculationTextDelete(CalculationText calculationText);
        void CalculationTextUpdate(CalculationText calculationText);
        List<CalculationText> GetAllCalculationText();
        CalculationText GetCalculationTextById(int id);
        List<CalculationText> GetCalculationTextByTextId(int id);
      
    }
}
