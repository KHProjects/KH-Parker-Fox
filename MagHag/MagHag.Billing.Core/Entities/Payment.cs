using MagHag.Billing.Core.Events;
using MagHag.Core.Entities;
using System;

namespace MagHag.Billing.Core.Entities
{
    public class Payment : Aggregate
    {
        private PaymentStatuses _paymentStatus;

        public Payment()
        {
            Apply(new PaymentCreated(Guid.NewGuid()));
        }

        public PaymentStatuses PaymentStatus
        {
            get { return _paymentStatus; }
        }

        public void Accept()
        {
            if (_paymentStatus == PaymentStatuses.Pending)
            {
                Apply(new PaymentAccepted());
            }
            else
            {
                throw new InvalidOperationException("Payment status not valid to accept");
            }
        }

        public void Reject()
        {
            if (_paymentStatus == PaymentStatuses.Pending)
            {
                Apply(new PaymentRejected());
            }
            else
            {
                throw new InvalidOperationException("Payment status not valid to accept");
            }
        }

        private void UpdateFrom(PaymentCreated paymentCreated)
        {
            Id = paymentCreated.PaymentId;
            _paymentStatus = PaymentStatuses.Pending;
        }

        private void UpdateFrom(PaymentAccepted paymentAccepted)
        {
            _paymentStatus = PaymentStatuses.Accepted;
        }

        private void UpdateFrom(PaymentRejected paymentRejected)
        {
            _paymentStatus = PaymentStatuses.Rejected;
        }
    }
}
