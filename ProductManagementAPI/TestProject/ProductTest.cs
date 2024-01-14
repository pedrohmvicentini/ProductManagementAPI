using System.Net;

namespace TestProject
{
    [TestClass]
    public class ProductTest
    {
        private const string ENDPOINT = "https://localhost:7006/api/product/";

        [TestMethod]
        public void AddTest()
        {
            Helper helper = new Helper();

            var data = new
            {
                id = 0,
                description = "test product " + DateTime.Now.ToString(),
                BestBeforeAt = DateTime.Now.AddMonths(3),
                ManufacturingDate = DateTime.Now,
                active = true,
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now,
                deletedAt = DBNull.Value,
                SponsorId = 1,
                UserId = Guid.NewGuid()
            };

            var result = helper.execApiPost(true, ENDPOINT, "Add", data).Result;

            Assert.AreEqual(result, HttpStatusCode.OK);
        }

        [TestMethod]
        public void AddBestBeforeAtSmallerThanTestManufacturingDate()
        {
            Helper helper = new Helper();

            var data = new
            {
                id = 0,
                description = "test product " + DateTime.Now.ToString(),
                BestBeforeAt = DateTime.Now,
                ManufacturingDate = DateTime.Now.AddMonths(3),
                active = true,
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now,
                deletedAt = DBNull.Value,
                SponsorId = 1,
                UserId = Guid.NewGuid()
            };

            var result = helper.execApiPost(true, ENDPOINT, "Add", data).Result;

            Assert.AreEqual(result, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Helper helper = new Helper();

            var data = new
            {
                id = 1,
                description = "test product update" + DateTime.Now.ToString(),
                BestBeforeAt = DateTime.Now.AddMonths(5),
                ManufacturingDate = DateTime.Now.AddDays(-1),
                active = true,
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now,
                deletedAt = DBNull.Value,
                UserId = Guid.NewGuid()
            };

            var result = helper.execApiPost(true, ENDPOINT, "Update", data).Result;

            Assert.AreEqual(result, HttpStatusCode.OK);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Helper helper = new Helper();

            var data = new
            {
                id = 1,
                description = "delete product",
                BestBeforeAt = DateTime.Now,
                ManufacturingDate = DateTime.Now,
                active = false,
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now,
                deletedAt = DateTime.Now,
                UserId = Guid.NewGuid()
            };

            var result = helper.execApiPost(true, ENDPOINT, "Delete", data).Result;

            Assert.AreEqual(result, HttpStatusCode.OK);
        }

        [TestMethod]
        public void ListTest()
        {
            Helper helper = new Helper();

            var result = helper.execApiPost(true, ENDPOINT, "List").Result;

            Assert.AreEqual(result, HttpStatusCode.OK);
        }

        [TestMethod]
        public void ListActivesProductsTest()
        {
            Helper helper = new Helper();

            var result = helper.execApiPost(true, ENDPOINT, "ListActivesProducts").Result;

            Assert.AreEqual(result, HttpStatusCode.OK);
        }

        [TestMethod]
        public void GetEntityByIdTest()
        {
            Helper helper = new Helper();

            var data = new
            {
                id = 1,
                description = "get product",
                BestBeforeAt = DateTime.Now,
                ManufacturingDate = DateTime.Now,
                active = true,
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now,
                deletedAt = DateTime.Now,
                UserId = Guid.NewGuid()
            };

            var result = helper.execApiPost(true, ENDPOINT, "GetEntityById", data).Result;

            Assert.AreEqual(result, HttpStatusCode.OK);
        }
    }
}
