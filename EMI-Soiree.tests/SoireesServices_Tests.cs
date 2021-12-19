using System;
using EMI_Soiree;
using Xunit;

namespace EMI_Soiree.tests
{
    public class SoireesServices_Tests
    {
        [Fact]
        public void SoireesServices_TesterGetALL()
        {
            var depot = new SoireesService();

            var soirees = depot.GetAll();

            Assert.NotNull(soirees);

        }
        [Fact]
        public void SoireesServices_TesterGetById()
        {
            var depot = new SoireesService();
            var soiree = depot.GetByID(6);

            Assert.NotNull(soiree);
            Assert.Equal(6, soiree.ID);
            Assert.NotEmpty(soiree.Lieu);
            Assert.IsType<Soirees>(soiree);
        }
        [Fact]
        public void Soirees_TesterInsert()
        {
            var soirees = new Soirees("EPSI");
            var depot = new SoireesService();

            depot.Insert(soirees);

            Assert.NotNull(soirees);
            Assert.Equal("EPSI", soirees.Lieu);
            Assert.IsType<Soirees>(soirees);

        }
        [Fact]
        public void Soirees_TesterUpdate()
        {
            var soirees = new Soirees("EPSI");
            var depot = new SoireesService();


            depot.Insert(soirees);
            depot.Update(soirees);

            Assert.NotNull(soirees);
            Assert.Equal("EPSI", soirees.Lieu);
            Assert.IsType<Soirees>(soirees);
        }
        [Fact]
        public void Soirees_TesterDelete()
        {
            var soirees = new Soirees("ESPI");
            var depot = new SoireesService();

            depot.Insert(soirees);
            depot.Delete(soirees);

            Assert.Throws<Exception>(() => depot.GetByID(soirees.ID));

        }
    }
}
