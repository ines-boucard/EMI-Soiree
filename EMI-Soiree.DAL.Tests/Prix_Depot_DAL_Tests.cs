using EMI_Soiree.DAL;
using System;
using Xunit;

namespace EMI_Soiree.DAL.Tests
{
    public class Prix_Depot_DAL_Tests
    {
        [Fact]
        public void Prix_Depot_DAL_TesterGetAll()
        {
            var depot = new Prix_Depot_DAL();

            var prix = depot.GetAll();

            Assert.NotNull(prix);
        }

        [Fact]
        public void Prix_Depot_DAL_TesterGetByIdSoiree()
        {
            var depot = new Prix_Depot_DAL();

            var prix = depot.GetByIdSoiree(1);

            Assert.NotNull(prix);
        }

        [Fact]
        public void Prix_Depot_DAL_TesterGetByIdParticipants()
        {
            var depot = new Prix_Depot_DAL();

            var prix = depot.GetByIdParticipants(1);

            Assert.NotNull(prix);
           
        }


        [Fact]
        public void Prix_Depot_DAL_TesterInsert()
        {

            var prix = new Prix_DAL(2,2, 20);

            var depot = new Prix_Depot_DAL();

            depot.Insert(prix);

            Assert.NotNull(prix);
            
        }

    }
}
