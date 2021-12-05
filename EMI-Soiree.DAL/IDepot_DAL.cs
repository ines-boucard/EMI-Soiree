using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMI_Soiree.DAL
{
    interface IDepot_DAL<Type_DAL>
    {
        string ChaineDeConnexion { get; set; }

        List<Type_DAL> GetAll();

        Type_DAL GetByID(int ID);

        Type_DAL Insert(Type_DAL item);

        Type_DAL Update(Type_DAL item);

        void Delete(Type_DAL item);

    }
}
