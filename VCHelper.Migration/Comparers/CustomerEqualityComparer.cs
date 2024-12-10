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

            return x.ShortName == y.ShortName;
        }

        public int GetHashCode(Customer obj)
        {
            if (obj is null == true)
            {
                return 0;
            }

            return obj.ShortName.GetHashCode();
        }
    }
}
