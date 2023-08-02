using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IWriterService
    {
        void AddWriter(Writer writer);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        List<Writer> GetAllWriters();
        Writer GetWriterById(int id);
      
    }
}
