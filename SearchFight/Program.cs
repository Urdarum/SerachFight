using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchBase Base = new SearchBase();

            Console.Write("Please insert the number of terms to fight: ");
            int Num = Convert.ToInt16(Console.ReadLine());
            string[] Fighter = new string[Num];
            long[] Gresults = new long[Num];
            long[] Bresults = new long[Num];
            long[] Tresults = new long[Num];

            string GR;
            string BR;

            long temp;

            int Gwinner = 0;
            long GTop = 0;

            int Bwinner = 0;
            long BTop = 0;

            int Twinner = 0;
            long TTop = 0;

            for(int i = 0; i < Num; i++)
            {
                Console.Write("Please insert the first item to fight: ");
                Fighter[i] = Console.ReadLine();
            }

            for (int i=0; i < Num; i++)
            {
                GR = Base.GoogleQuery(Fighter[i]);
                Gresults[i] = Convert.ToInt64(GR);
                
                if (GTop<Gresults[i])
                {
                    GTop = Gresults[i];
                    Gwinner = i;
                }

                BR = Base.BingQuery(Fighter[i]);
                Bresults[i] = Convert.ToInt64(BR);

                if (BTop < Bresults[i])
                {
                    BTop = Bresults[i];
                    Bwinner = i;
                }

                temp = Gresults[i] + Bresults[i];

                if (TTop<temp)
                {
                    TTop = temp;
                    Twinner = i;
                }

                Console.WriteLine(Fighter[i] + ": Google: " + Gresults[i] + " Bing: " +Bresults[i]);
            }

            Console.WriteLine("Google winner is : " + Fighter[Gwinner] + " With :" + GTop);
            Console.WriteLine("Bing winner is : " + Fighter[Bwinner] + " With :" + BTop);
            Console.WriteLine("Total winner is : " + Fighter[Twinner] + " With :" + TTop);
            Console.ReadLine();
        }
    }
}
