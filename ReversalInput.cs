namespace BSSPaymentIntegration
{
    public class ReversalInput
    {
        //Request
        public string request_id { get; set; }
        public string feature { get; set; }
        public string action { get; set; }
        public string request_timestamp { get; set; }
        public string timeStamp { get; set; }
        public string sourceNode { get; set; }
        public string userid { get; set; }
        public string username { get; set; }

        //Order_Information
        public string o_order_type { get; set; }
        

        //Payment
        public string account_id { get; set; }
        public string order_type { get; set; }
        public string payment_id { get; set; }
        public string void_type { get; set; }
        public string reference_external_id { get; set; }


        //Param
        public string p_id { get; set; }
        public string p_value { get; set; }
    }

    public class ReversalRoot
    {
        public ReversalRequest Request { get; set; }
    }

    public class ReversalRequest
    {
        public string request_id { get; set; }
        public string feature { get; set; }
        public string action { get; set; }
        public string request_timestamp { get; set; }
        public string timeStamp { get; set; }
        public string source_node { get; set; }
        public string userid { get; set; }
        public string username { get; set; }
        public Order_Info order_information { get; set; }
    }

    public class Order_Info
    {
        public string order_type { get; set; }
        public string customer_name { get; set; }
        public Datasets dataset { get; set; }
        public Payments payment { get; set; }
    }

    public class Payments
    {
        public string account_id { get; set; }
        public string order_type { get; set; }
        public string payment_id { get; set; }
        public string void_type { get; set; }
        public string reference_external_id { get; set; }
    }

    public class Datasets
    {
        public Param[] param { get; set; }
    }

    public class Params
    {
        public string id { get; set; }
        public string value { get; set; }
    }
}