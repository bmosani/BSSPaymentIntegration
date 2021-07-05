using Newtonsoft.Json;
using PostData.Models;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Net;

namespace BSSPaymentIntegration
{
    public class Program
    {
        private static readonly string BaseUrl = ConfigurationManager.AppSettings["BaseURL"];

        public static void Main(string[] args)
        {
            //Input input = new Input
            //{
            //    request_id = "1490045399869",
            //    request_timestamp = "21032017210259",
            //    action = "MakePayment",
            //    source_node = "CRM",
            //    userid = "1",
            //    username = "superAdmin",

            //    //Order_Information
            //    order_type = "billpayment",
            //    customer_name = "",

            //    //Payment
                                                               // Removed   profile_id = "500157825",
            //    account_id = "1000066614",
            //    amount = "28.978570",
            //    amount_paid = "20.978570",
            //    payment_order_type = "billpayment",
            //    collection_source_type = "NORMAL",
            //    collection_id = "12",
            //    comment = "null",
            //    currency_code = "OMR",
            //    card_number = "4535435",
            //    invoice_amounts = "28.9",

            //    //Payment_Detail
            //    payment_mode = "3",
            //    reference_external_id = "4604",
            //    Payment_Detail_amount_paid = "24.0",
            //    amount_description = "payable",

            //    //Mode_Detail
            //    key = "payment_subscriber_id",
            //    value = "cus_Dw3ki2DzVqciKV",

            //    //Param
            //    id = "entity_id",
            //    p_value = "200"
            //};



            //Input[] inputs = { input };

            ////ReversalInput ReversalInput = new ReversalInput
            ////{
            ////    request_id = "1490045399869",
            ////    request_timestamp = "21032017210259",
            ////    action = "VoidPayment",
            ////    userid = "1",
            ////    username = "superAdmin",

            ////    //Order_Information
            ////    order_type = "billpayment",

            ////    //Payment
            ////                                        // Removed  profile_id = "500157825",
            ////    account_id = "1000066614",
            ////    feature = "none",
            ////    void_type = "none",
                
            ////    sourceNode = "none",
            ////    payment_id = "none",
            ////    o_order_type = "none",
            ////    timeStamp = "none",
               
            ////    reference_external_id = "4604",

            ////    //Param
            ////    p_id = "entity_id",
            ////    p_value = "200"
            ////};

            ////ReversalInput[] ReversalInputs = { ReversalInput };


            ///InputData inputData = new InputData();

            //var data = inputData.MakeData(input);

            //var client = new RestClient(BaseUrl);
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");

            //var json = JsonConvert.SerializeObject(data);

            //request.AddParameter("application/json", json, ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            //MakePayment(inputs);

            //VoidPayment(ReversalInputs);


        }

        #region MakePayment
        public static Response MakePayment(Input[] input)
        {
            var response = new Response();

            if (input.Length > 0)
            {
                try
                {
                    InputData inputData = new InputData();

                    foreach (var element in input)
                    {
                        var data = inputData.MakeData(element);
                        var client = new RestClient(BaseUrl);
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Content-Type", "application/json");

                        var json = JsonConvert.SerializeObject(data);
                        request.AddParameter("application/json", json, ParameterType.RequestBody);
                        IRestResponse respnse = client.Execute(request);
                        //return response.Message = "true";

                        response.Message = respnse.Content.ToString();
                        response.Status = respnse.IsSuccessful;
                    }
                }
                catch (WebException ex)
                {
                    response.Message = ex.Message;
                    response.Status = false;
                }

            }
            else
            {
                response.Message = "Input List Is Null";
                response.Status = false;
            }

            return response;
        }
        #endregion


        #region PaymentReversal
        public static IEnumerable<Response> VoidPayment(ReversalInput[] input)
        {
            //var response = new Response();
            //var response = new ResponseList();
            var response = new List<Response>();

            if (input.Length > 0)
            {
                try
                {
                    ReversalData inputData = new ReversalData();

                    foreach (var element in input)
                    {
                        var data = inputData.MakeData(element);
                        var client = new RestClient(BaseUrl);
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Content-Type", "application/json");

                        var json = JsonConvert.SerializeObject(data);
                        request.AddParameter("application/json", json, ParameterType.RequestBody);
                        IRestResponse respnse = client.Execute(request);
                        //return response.Message = "true";

                        var resnse = new Response()
                        {
                            Message = respnse.Content.ToString(),
                            Status = respnse.IsSuccessful
                        };
                        response.Add(resnse);


                    };
                }
                catch (WebException ex)
                {
                    var resnse = new Response()
                    {
                        Message = ex.Message,
                        Status = false
                    };
                    response.Add(resnse);
                }

            }
            else
            {
                var resnse = new Response()
                {
                    Message = "Input List Is Null",
                    Status = false
                };
                response.Add(resnse);
            }

            return response;
        }
        #endregion
    }
}