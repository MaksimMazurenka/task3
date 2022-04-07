using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Rules
    {
        Values values = new Values();
        public String getResult(int user, int pc)
        {
            if (user == pc)
            {
                return "Draw";
            }
            else
            {
                List<int> winMuvies = new List<int>();
                if (user + values.Half < values.Size)
                {
                    for(int i = user + 1; i <= user+values.Half; i++)
                    {
                        winMuvies.Add(i);
                    }
                }
                else
                {
                    for (int i = user + 1; i < values.Size; i++)
                    {
                        winMuvies.Add(i);
                    }
                    int curSize = winMuvies.Count;
                    for (int i = 0; i < values.Half-curSize; i++)
                    {
                        winMuvies.Add(i);
                    }
                }
                if(winMuvies.Contains(pc))
                {
                    return "You win";
                }
                else
                {
                    return "You loose";
                }
            }
        }
    }
}
