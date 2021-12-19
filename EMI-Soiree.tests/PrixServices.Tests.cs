using System;
using EMI_Soiree;
using Xunit;

namespace EMI_Soiree.tests
{
    public class PrixServices_Tests
    {
        [Fact]
        public void PrixServices_TesterGetALL()
        {
            var depot = new PrixService();

            var prix = depot.GetAll();

            Assert.NotNull(prix);

        }
        [Fact]
        public void Prix_TesterGetByIdSoirees()
        {
            var depot = new PrixService();
            var prix = depot.GetByIdSoiree(6)[0];

            Assert.NotNull(prix);
            Assert.Equal(6, prix.IdSoiree);
            Assert.IsType<Prix>(prix);
        }
        [Fact]
        public void Prix_TesterGetByIdParticipants()
        {
            var depot = new PrixService();
            var prix = depot.GetByIdParticipants(6)[0];

            Assert.NotNull(prix);
            Assert.Equal(6, prix.IdParticipants);
            Assert.IsType<Prix>(prix);
        }
        [Fact]
        public void Prix_TesterInsert()
        {
            var prix = new Prix(4,5,200);
            var depot = new PrixService();

            depot.Insert(prix);

            Assert.NotNull(prix);
            Assert.Equal(4,prix.IdSoiree);
            Assert.Equal(5,prix.IdParticipants);
            Assert.Equal(200,prix.Montant);
            Assert.IsType<Prix>(prix);

        }
        [Fact]
        public void Prix_TesterUpdate()
        {
            var prix = new Prix(6, 10, 200);
            var depot = new PrixService();

            depot.Insert(prix);
            depot.Update(prix);

            Assert.NotNull(prix);
            Assert.Equal(5, prix.IdSoiree);
            Assert.Equal(5, prix.IdParticipants);
            Assert.Equal(200, prix.Montant);
            Assert.IsType<Participants>(prix);
        }
       
    }
}
