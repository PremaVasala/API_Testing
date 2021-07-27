using API_TESTING.API;
using API_TESTING.Model;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;

namespace API_TESTING
{
    public class Tests
    {
        BillingOrderAPI billingOrder;
        [SetUp]
        public void Setup()

        {
            billingOrder = new BillingOrderAPI();
        }


        [Test]

        public void CreateOrderTestCases()
        {

            var expectedOrder = new BillingOrder
            {
                addressLine1 = "test1",
                addressLine2 = "test",
                city = "AK",
                comment = "test",
                email = "prema.star@gmail.com",
                firstName = "prema1",
                lastName = "latha",
                phone = "0437875766",
                zipCode = "123123",
                itemNumber = 1,
                state = "AL"

            };

            string jsonbody = JsonConvert.SerializeObject(expectedOrder);

            IRestResponse response = billingOrder.PostOrder(jsonbody);
            BillingOrder actualOrder = JsonConvert.DeserializeObject<BillingOrder>(response.Content);
          

                       // clean up

          
         expectedOrder.Should().BeEquivalentTo(actualOrder, Options => Options.Excluding(o => o.id));
           //ssert.AreEqual(response.StatusCode, "Ok");
            Assert.True(response.IsSuccessful);

        }

        [Test]
        public void TC_GetOrders()

        {
            BillingOrderAPI billingOrder = new BillingOrderAPI();
            IRestResponse response = billingOrder.GetAllOrdersById("1");
            TestContext.WriteLine(response.Content);

            // Assertions are pending

        }

        [Test]
        public void TC_DeleteOrder()

        {
            BillingOrderAPI billingOrder = new BillingOrderAPI();
            IRestResponse response = billingOrder.DeleteOrderById("2");
            TestContext.WriteLine(response.Content);

            // Assertions are pending

        }

        [Test]
        public void TC_PostOrders()
        {


            var expectedOrder = new BillingOrder
            {
                addressLine1 = "kelsalsreet",
                addressLine2 = "test",
                city = "AK",
                comment = "test",
                email = "prema.star@gmail.com",
                firstName = "prema1",
                lastName = "latha",
                phone = "0437875766",
                zipCode = "123123",
                itemNumber = 1,
                state = "AL"

            };

            string jsonbody = JsonConvert.SerializeObject(expectedOrder);

            BillingOrderAPI billingOrder = new BillingOrderAPI();
            IRestResponse response = billingOrder.PostOrder(jsonbody);

            // Assertion 
            BillingOrder actualOrder = JsonConvert.DeserializeObject<BillingOrder>(response.Content);

           
            expectedOrder.Should().BeEquivalentTo(actualOrder,
                options => options.Excluding(o => o.id));
                

        }




        [Test]
        public void TC_GetAllRecords()

        {

            BillingOrderAPI billingOrder = new BillingOrderAPI();
            IRestResponse response = billingOrder.GetAllOrders();

            TestContext.WriteLine(response.Content);

            // Assertions are pending

        }


        [Test]
        public void TC_PutOrders()
        {
            for (int i = 1; i <= 100; i++)
            {
                string body = $"{{\"addressLine1\": \"kelsal1\", \"addressLine2\": \"kelsal2\",\"city\": \"Brisbane\", \"comment\": \"APITEST\",\"email\": \"prma@gmail.com\",\"firstName\": \"prema9\",\"lastName\": \"latha\", \"phone\": \"0437875745\", \"state\": \"AL\",\"zipCode\": \"123123\"}}";

                BillingOrderAPI billingOrder = new BillingOrderAPI();
                IRestResponse response = billingOrder.putOrder("100", body);
                TestContext.WriteLine(response.Content);
            }
        }
    }
}