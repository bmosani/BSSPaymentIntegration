using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSSPaymentIntegration
{
    public class ReversalData
    {
        public ReversalRoot MakeData(ReversalInput input)
        {

            Param[] obj = {
                new Param
                {
                    id = input.p_id,
                    value = input.p_value
                }
            };
            Datasets datasetObj = new Datasets
            {
                param = obj
            };
           
            Payments paymentObj = new Payments
            {
                account_id = input.account_id,
                order_type = input.order_type,
                payment_id = input.payment_id,
                void_type = input.void_type,
                reference_external_id = input.reference_external_id,
                                //Removed profile_id = input.profile_id
            };

            Order_Info orderInfoObj = new Order_Info
            {
                order_type = input.order_type,
                payment = paymentObj,
                dataset = datasetObj
            };

            ReversalRequest requestObj = new ReversalRequest
            {
                request_id = input.request_id,
                feature = input.feature,
                action = input.action,
                request_timestamp = input.request_timestamp,
                source_node = input.sourceNode,
                userid = input.userid,
                username = input.username,
                order_information = orderInfoObj
            };

            ReversalRoot rootObj = new ReversalRoot
            {
                Request = requestObj
            };

            return rootObj;
        }
    }
}
