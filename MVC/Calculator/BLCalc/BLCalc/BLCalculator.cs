using System.Runtime.CompilerServices;
using System.Text;
using DALCalc;
namespace BLCalc
{
    public class BLCalculator
    {
          
        List<string> li = DalCalculator.list.ToList();
        public List<string> reverse()
        {
            List<string> res = new List<string>();
            
            foreach (string item in li)
            {
                string str = item;
                StringBuilder st = new();
                for(int i=str.Length-1;i>=0;i--)
                {
                    st.Append(str[i]);
                }
                res.Add(st.ToString());
            }
            return res;
        }

        
    }
}
