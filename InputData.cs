namespace BSSPaymentIntegration
{
    public class InputData
    {
        public Root MakeData(Input input)
        {

            Param[] obj = {
                new Param
                {
                    id = input.id,
                    value = input.p_value
                }
            };
            Dataset datasetObj = new Dataset
            {
                param = obj
            };
            Mode_Detail[] modelDetail =
            {
                new Mode_Detail
                {
                    key = input.key,
                    value = input.value
                }
            };
            Payment_Detail[] objPaymentDetail = {
                new Payment_Detail
                {
                    payment_mode = input.payment_mode,
                    reference_external_id =input.reference_external_id,
                    amount_paid = input.Payment_Detail_amount_paid,
                    amount_description = input.amount_description,
                    mode_detail = modelDetail
                }
            };
            Payment paymentObj = new Payment
            {
                                       // Removed profile_id = input.profile_id,
                account_id = input.account_id,
                amount = input.amount,
                amount_paid = input.amount_paid,
                order_type = input.order_type,
                collection_source_type = input.collection_source_type,
                collection_id = input.collection_id,
                comment = input.comment,
                currency_code = input.currency_code,
                card_number = input.card_number,
                invoice_amounts = input.invoice_amounts,
                payment_detail = objPaymentDetail
            };
            Order_Information orderInfoObj = new Order_Information
            {
                order_type = input.order_type,
                customer_name = input.customer_name,
                payment = paymentObj,
                dataset = datasetObj
            };

            Request requestObj = new Request
            {
                request_id = input.request_id,
                request_timestamp = input.request_timestamp,
                action = input.action,
                source_node = input.source_node,
                userid = input.userid,
                username = input.username,
                order_information = orderInfoObj
            };
            Root rootObj = new Root
            {
                Request = requestObj
            };

            return rootObj;
        }
    }
}