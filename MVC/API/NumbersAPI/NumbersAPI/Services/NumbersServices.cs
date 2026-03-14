using NumbersAPI.Services;
namespace NumbersAPI.Services
{
    public class NumbersServices : INumbersServices
    {


        public List<int> ODDs()
        {
            List<int> nums = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 != 0)
                {
                    nums.Add(i);
                }

            }
            return nums;

        }
        public List<int> EVENs()
        {
            List<int> nums = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0)
                {
                    nums.Add(i);
                }

            }
            return nums;

        }
    }
}

