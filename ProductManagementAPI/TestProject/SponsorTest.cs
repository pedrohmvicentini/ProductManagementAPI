using System.Net;

namespace TestProject
{
    [TestClass]
    public class SponsorTest
    {
        private const string ENDPOINT = "https://localhost:7006/api/sponsor/";

        [TestMethod]
        public void AddTest()
        {
            Helper helper = new Helper();

            var data = new
            {
                id = 0,
                description = "Amazon " + DateTime.Now.ToString(),
                document = "15.743.732/0001-49",
                active = true,
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now,
                deletedAt = DBNull.Value,
                UserId = Guid.NewGuid()
            };

            var result = helper.execApiPost(true, ENDPOINT, "Add", data).Result;

            Assert.AreEqual(result, HttpStatusCode.OK);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Helper helper = new Helper();

            var data = new
            {
                id = 1,
                description = "Microsoft " + DateTime.Now.ToString(),
                document = "67.321.364/0001-44",
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
                description = "delete sponsor",
                document = "67.321.364/0001-44",
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
        public void ListActivesSponsorsTest()
        {
            Helper helper = new Helper();

            var result = helper.execApiPost(true, ENDPOINT, "ListActivesSponsors").Result;

            Assert.AreEqual(result, HttpStatusCode.OK);
        }

        [TestMethod]
        public void GetEntityByIdTest()
        {
            Helper helper = new Helper();

            var data = new
            {
                id = 1,
                description = "get sponsor",
                document = "67.321.364/0001-44",
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
