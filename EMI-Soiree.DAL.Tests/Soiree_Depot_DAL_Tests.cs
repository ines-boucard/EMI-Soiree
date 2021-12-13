using EMI_Soiree.DAL;
using System;
using Xunit;

namespace EMI_Soiree.DAL.Tests
{
    public class Soiree_Depot_DAL_Tests
    {
        [Fact]
        public void Soiree_Depot_DAL_TesterGetAll()
        {
            var depot = new Soirees_Depot_DAL();

            var soirees = depot.GetAll();

            Assert.NotNull(soirees);
        }

        [Fact]
        public void Soiree_Depot_DAL_TesterGetByID()
        {
            var depot = new Soirees_Depot_DAL();

            var soiree = depot.GetByID(1);

            Assert.NotNull(soiree);
            Assert.Equal(1, soiree.ID);
            Assert.NotEmpty(soiree.Lieu);
           
        }

        [Fact]
        public void Soiree_Depot_DAL_TesterInsert()
        {

            var soiree = new Soirees_DAL("Paris");

            var depot = new Soirees_Depot_DAL();

            depot.Insert(soiree);

            Assert.NotNull(soiree);
            //on vérifie si on a un lieu 
            Assert.NotNull(soiree.Lieu);
        }

        [Fact]
        public void Soiree_Depot_DAL_TesterUpdate()
        {
            var soiree = new Soirees_DAL("Paris");
            var depot = new Soirees_Depot_DAL();

            depot.Insert(soiree);
            depot.Update(soiree);

            Assert.NotNull(soiree);
            Assert.NotNull(soiree.Lieu); 
        }

        [Fact]
        public void Soiree_Depot_DAL_TesterDelete()
        {

            var soiree = new Soirees_DAL("Paris");

            var depot = new Soirees_Depot_DAL();

            depot.Insert(soiree);

            depot.Delete(soiree);

            Assert.Throws<Exception>(() => depot.GetByID(soiree.ID)); //si je le récupère bien null c'est bon
        }



    }
}
