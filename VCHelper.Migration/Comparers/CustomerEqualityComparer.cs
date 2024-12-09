using VCHelper.Migration.Entities;

namespace VCHelper.Migration.Comparers
{
    internal class CustomerEqualityComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer? x, Customer? y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x is null || y is null)
            {
                return false;
            }

            return x.Keyword == y.Keyword 
                && x.ShortName == y.ShortName 
                && x.LegalAddress == y.LegalAddress;
        }

        public int GetHashCode(Customer obj)
        {
            return obj.GetHashCode();
        }
    }
}
