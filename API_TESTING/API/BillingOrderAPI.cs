using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_TESTING.API
{
    class BillingOrderAPI
    {

        private readonly string baseUrl = "http://localhost:8181";
      
        public IRestResponse GetAllOrdersById(string id)
        {
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.GET);
            

            // Execution
            IRestResponse response = client.Execute(request);

            return response;
        }


        public IRestResponse GetAllOrders()
        {
            var client = new RestClient($"{baseUrl}/BillingOrder");
            var request = new RestRequest(Method.GET);
       

            // Execution
            IRestResponse response = client.Execute(request);

            return response;
        }

            public IRestResponse DeleteOrderById( string id )
        {
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Accept", "application/json");

            // Execution
            IRestResponse response = client.Execute(request);

            return response;
        }

        public IRestResponse PostOrder( string body )
        {
            var client = new RestClient($"{baseUrl}/BillingOrder/");
            var request = new RestRequest(Method.POST);

            
            //header

            request.AddHeader("Content-Type", "application/json");

            //post
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            // Execution
            IRestResponse response = client.Execute(request);

            return response;
        }

       
       

        public IRestResponse putOrder( string id, string body )

        {
            var client = new RestClient($"{baseUrl}/BillingOrder/{id}");
            var request = new RestRequest(Method.PUT);          
            //header
            request.AddHeader("Content-Type", "application/json");         
            //post 
            request.AddParameter("application/json", body, ParameterType.RequestBody); IRestResponse response = client.Execute(request); return response;
        }


    }


}