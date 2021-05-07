using System;
using System.Net.Http;
using Xunit;
using System.Threading.Tasks;

namespace CustomerAPIProject
{
    public class CustomerUnitTests
    {
        [Fact]
        public async Task<bool> GetByIDTest()
        {
		    var client = new HttpClient();
            using (var getCall = await client.GetAsync("http://localhost:5000/customer/1"))
            {
                var testresponse = "{\"creationDate\":\"2021-05-07T12:49:41.3594195-04:00\",\"id\":1,\"name\":\"Frank\"}";
                Assert.True(getCall.Content.ReadAsStringAsync().Equals(testresponse));
            }
            
            return true;
        }
        [Fact]
        public void GetAllTest()
        {
		    var client = new HttpClient();
            var getCall = client.GetAsync("http://localhost:5000/customer/");
            Assert.True(getCall.IsCompletedSuccessfully);
        }
        [Fact]
        public void GetByNameTest()
        {
		    var client = new HttpClient();
            var getCall = client.GetAsync("http://localhost:5000/customer/dan");
            //var data = getCall.GetAwaiter.C
            Assert.True(getCall.IsCompletedSuccessfully);
        }
    }
}
