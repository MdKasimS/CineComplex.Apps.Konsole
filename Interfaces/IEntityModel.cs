using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsole.Interfaces
{
    public interface IEntityModel
    {
        public void NewFromSqlRow(DataRow row);

        public void SaveAsANewVersion(IEntityModel modelObject);

        public void CreateNew();
    }
}
