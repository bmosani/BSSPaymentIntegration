namespace BSSPaymentIntegration
{
    public class Input
    {
        //Request
        public string request_id { get; set; }
        public string request_timestamp { get; set; }
        public string action { get; set; }
        public string source_node { get; set; }
        public string userid { get; set; }
        public string username { get; set; }

        //Order_Information
        public string order_type { get; set; }
        public string customer_name { get; set; }

        //Payment
        public string account_id { get; set; }
        public string amount { get; set; }
        public string amount_paid { get; set; }
        public string payment_order_type { get; set; }
        public string collection_source_type { get; set; }
        public string collection_id { get; set; }
        public string comment { get; set; }
        public string currency_code { get; set; }
        public string card_number { get; set; }
        public string invoice_amounts { get; set; }

        //Param
        public string id { get; set; }
        public string p_value { get; set; }

        //Payment_Detail
        public string payment_mode { get; set; }
        public string reference_external_id { get; set; }
        public string Payment_Detail_amount_paid { get; set; }
        public string amount_description { get; set; }

        //Mode_Detail
        public string key { get; set; }
        public string value { get; set; }

        
    }

    public class Root
    {
        public Request Request { get; set; }
    }

    public class Request
    {
        public string request_id { get; set; }
        public string request_timestamp { get; set; }
        public string action { get; set; }
        public string source_node { get; set; }
        public string userid { get; set; }
        public string username { get; set; }
        public Order_Information order_information { get; set; }
    }

    public class Order_Information
    {
        public string order_type { get; set; }
        public string customer_name { get; set; }
        public Payment payment { get; set; }
        public Dataset dataset { get; set; }
    }

    public class Dataset
    {
        public Param[] param { get; set; }
    }

    public class Param
    {
        public string id { get; set; }
        public string value { get; set; }
    }

    public class Payment
    {
        public string account_id { get; set; }
        public string amount { get; set; }
        public string amount_paid { get; set; }
        public string order_type { get; set; }
        public string collection_source_type { get; set; }
        public string collection_id { get; set; }
        public string comment { get; set; }
        public string currency_code { get; set; }
        public string card_number { get; set; }
        public string invoice_amounts { get; set; }
        public Payment_Detail[] payment_detail { get; set; }
    }

    public class Payment_Detail
    {
        public string payment_mode { get; set; }
        public string reference_external_id { get; set; }
        public string amount_paid { get; set; }
        public string amount_description { get; set; }
        public Mode_Detail[] mode_detail { get; set; }
    }

    public class Mode_Detail
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}