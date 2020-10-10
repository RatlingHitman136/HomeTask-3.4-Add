using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrangeTree
{
    class Program
    {
        static Dictionary<string, OneLeaf>[] Tree;

        static void Main(string[] args)
        {
            Tree = new Dictionary<string, OneLeaf>[22];
            for (int i = 0; i < 20; i++) Tree[i] = new Dictionary<string, OneLeaf>();


            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string telephone = Console.ReadLine();
                addNumber(telephone,true);
            }
            int ans = 0;
            for (int i = 1; i < 20; i++)
            {
                //foreach(OneLeaf leaf in Tree[i].Values)
                //    Console.Write("num: {0} /", leaf.num);
                //Console.WriteLine();
                ans += Tree[i].Count;
            }
            //calcSum(0,0);
            Console.WriteLine(ans);
            Console.ReadKey();
        }

        static void addNumber(string number, bool isOrigin)
        {
            int layer = number.Length;

            if (Tree[layer].ContainsKey(number))
            {
                return;
            }
                    

            if (layer == 0)
            {
                OneLeaf LastLeaf = new OneLeaf("",isOrigin);
                Tree[layer].Add("",LastLeaf);
                return ;
            }
            addNumber(number.Substring(0, number.Length - 1),false);
            OneLeaf curLeaf = new OneLeaf(number, isOrigin);
            Tree[layer].Add(number,curLeaf);
            return;
        }

        //static void calcSum(int index, int layer)
        //{

        //    foreach(int i in Tree[layer][index].indexexOfDownleaf)
        //    {
        //        calcSum(i, layer + 1);
        //        Tree[layer][index].sum += Tree[layer + 1][i].sum;
        //    }
        //    if (Tree[layer][index].sum != 0 || Tree[layer][index].isOrigin) Tree[layer][index].sum++;
        //}
    }
    class OneLeaf
    { 
        public int sum;
        public string num;
        public bool isOrigin;

        public OneLeaf( string n,bool isO)
        {
            isOrigin = isO;
            sum = 0;
            num = n;
        }
    }
}
