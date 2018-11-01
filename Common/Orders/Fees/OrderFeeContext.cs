/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using QuantConnect.Securities;

namespace QuantConnect.Orders.Fees
{
    /// <summary>
    /// Defines the parameters for <see cref="IFeeModel.GetOrderFee"/>
    /// </summary>
    public class OrderFeeContext
    {
        /// <summary>
        /// Gets the security
        /// </summary>
        public Security Security { get; }

        /// <summary>
        /// Gets the order
        /// </summary>
        public Order Order { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFeeContext"/> class
        /// </summary>
        /// <param name="security">The security</param>
        /// <param name="order">The order</param>
        public OrderFeeContext(Security security, Order order)
        {
            Security = security;
            Order = order;
        }

        /// <summary>
        /// Creates the result representing zero fee
        /// </summary>
        /// <returns>The order fee</returns>
        public OrderFee Zero()
        {
            return new OrderFee(0m);
        }

        /// <summary>
        /// Creates the result using the specified fee denominated in the specified currency
        /// </summary>
        /// <param name="fee">The computed order fee</param>
        /// <param name="currency">The fee currency units</param>
        /// <returns>The order fee</returns>
        public OrderFee Result(decimal fee, string currency)
        {
            // TODO : Account for fee currency units
            return new OrderFee(fee);
        }

        /// <summary>
        /// Creates the result using the specified fee denominated in the account currency
        /// </summary>
        /// <param name="fee">The computed order fee</param>
        /// <returns>The order fee in units of the account currency</returns>
        public OrderFee ResultInAccountCurrency(decimal fee)
        {
            return new OrderFee(fee);
        }
    }
}