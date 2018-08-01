using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoProject
{
    class Algo
    {
        private List<Map> Folders;
        public Algo()
        {
            Folders = new List<Map>();
        }
        public List<Map> worst_fit(List<int> L , int X)
        {
            Folders.Clear();
            int N = L.Count;
            
            int c=0;
            for (int i = 0; i < N; i++)
            {
                if (L[i] <= X)
                {
                    if (Folders.Count == 0)
                    {
                        Map obj = new Map();
                        c++;
                        obj.name = "f"+c.ToString();
                        obj.reminder = X - L[i];
                        obj.L.Add(L[i]);
                        obj.index.Add(i + 1);
                        Folders.Add(obj);
                    }
                    else
                    {
                        int size=Folders.Count;
                        bool ch = false;
                        for (int j = 0; j <size ; j++)
                        {
                            if (L[i] <= Folders[j].reminder)
                            {
                                Folders[j].reminder -= L[i];
                                Folders[j].L.Add(L[i]);
                                Folders[j].index.Add(i + 1);
                                ch = true;
                                break;
                            }
                        }
                        if (ch == false)
                        {
                                Map obj = new Map();
                                c++;
                                obj.name = "f" + c.ToString();
                                obj.reminder = X - L[i];
                                obj.L.Add(L[i]);
                                obj.index.Add(i + 1);
                                Folders.Add(obj);
                        }
                    }
                }
            
            }

            return Folders;
        }
       
        public Dictionary<int ,Map> worst_fit_priority(List<int> L, int X)
        {
            //Folders.Clear();
            int N = L.Count;

            PriorityQueue pr = new PriorityQueue();
            Dictionary<int, Map> dic = new Dictionary<int, Map>();
            int c = 0;


            for (int i = 0; i < N; i++)
            {
                if (L[i] <= X)
                {
                    if (dic.Count == 0)
                    {
                        Map obj = new Map();
                        c++;
                        obj.name = "f" + c.ToString();
                        obj.reminder = X - L[i];
                        obj.L.Add(L[i]);
                        obj.index.Add(i + 1);
                        pr.Enqueue(obj.reminder);
                        dic.Add(obj.reminder, obj);
                       
                    }
                    else 
                    {
                        int z = Convert.ToInt16(pr.Peek());
                        if (L[i] <= z)
                        {
                            Map obj = dic[z];
                            dic.Remove(z);
                            obj.L.Add(L[i]);
                            obj.index.Add(i + 1);
                            obj.reminder -= L[i];
                            pr.Dequeue();
                            pr.Enqueue(obj.reminder);
                            dic.Add(obj.reminder, obj);

                        }
                        else 
                        {


                            Map obj = new Map();
                            c++;
                            obj.name = "f" + c.ToString();
                            obj.reminder = X - L[i];
                            obj.L.Add(L[i]);
                            obj.index.Add(i + 1);
                            pr.Enqueue(obj.reminder);
                            dic.Add(obj.reminder, obj);
                           
                        
                        
                        
                        }


                    }
                
                }
            
            }
                return dic;
        }


        public string converttosec(int num)
        { 
            int hour = 0;
            int min = 0 ;
            int sec = 0 ;
            if(num >= 3600)
            {

            hour = num / 3600;
            num = num % 3600;
            
            
            }
             if(num >= 60)
             {
             
                 min = num / 60 ;
                 num = num % 60 ;
             
             }
             sec = num;
        
        int [] arr = new int[3];
            arr[0] = hour;
            arr[1] = min ;
            arr[2] = sec ;
            string slo="";
            string clk = "";
            clk = hour.ToString();
            if (clk.Length == 1)
            {
                slo = "0" + clk;
            }
            else { slo += clk; }
            slo += ':';
            clk = min.ToString();
            if (clk.Length == 1)
            {
                slo += "0" + clk;
            }
            else { slo += clk; }
            slo += ':';
            clk = sec.ToString();
            if (clk.Length == 1)
            {
                slo += "0" + clk;
            }
            else { slo += clk; }
            return slo;
        }


        public List<Map> first_fit_decreasing_usinglinearsearch(List<int> L, int X , Dictionary<int , int> dict)
        {
            Folders.Clear();
            int N = L.Count;
            int ind ; //
            int count = dict.Count(); //
            int c = 0;
            for (int i = 0; i < N; i++)
            {
                if (L[i] <= X)
                {
                    if (Folders.Count == 0)
                    {
                        Map obj = new Map();
                        c++;
                        obj.name = "f" + c.ToString();
                        obj.reminder = X - L[i];
                        obj.L.Add(L[i]);

                        for (int k = 0; k < count; k++) // 
                        {
                            int val = dict[k + 1];    // 
                            if (val == L[i])        //
                            {
                                obj.index.Add(k+1); //
                            }
                        
                        }
                          
                        Folders.Add(obj);
                    }
                    else
                    {
                        int size = Folders.Count;
                        bool ch = false;
                        for (int j = 0; j < size; j++)
                        {
                            if (L[i] <= Folders[j].reminder)
                            {
                                Folders[j].reminder -= L[i];
                                Folders[j].L.Add(L[i]);
                                for (int k = 0; k < count; k++) //
                                {
                                    ind = k+1; //
                                    int val = dict[ind];//
                                    if (val == L[i]) //
                                    {
                                        for (int t = 0; t < Folders[j].index.Count; t++) //
                                        {
                                            if (ind != Folders[j].index[t]) //
                                                Folders[j].index.Add(ind);  //
                                        }
                                    }

                                }
                             
                                ch = true;
                                break;
                            }
                        }
                        if (ch == false)
                        {
                            Map obj = new Map();
                            c++;
                            obj.name = "f" + c.ToString();
                            obj.reminder = X - L[i];
                            obj.L.Add(L[i]);
                            for (int k = 0; k < count; k++) //
                            {
                                ind = k + 1; //
                                int val = dict[ind];//
                                if (val == L[i]) //
                                {
                                    obj.index.Add(ind);
                                }
                            }
                            
                            Folders.Add(obj);
                        }
                    }
                }

            }

            return Folders;
        }
        public List<int> get_sum(List<int> L, int val)
        {
            List<int> ret_list = new List<int>();
            int sum = 0;
            int N = L.Count();
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    sum = L[i] + L[j];
                    if (sum == val)
                    {
                        ret_list.Add(L[i]);
                        ret_list.Add(L[j]);
                    
                    
                    }
                    sum = 0;

                
                }
            
            }
            if (ret_list.Count == 0)
            {

                for (int i = 0; i < N; i++)
                {
                    for (int j = i + 1; j < N; j++)
                    {
                        sum = L[i] + L[j];
                        if (sum < val)
                        {
                            ret_list.Add(L[i]);
                            ret_list.Add(L[j]);


                        }
                        sum = 0;


                    }

                }
            
            }
            return ret_list;
        
        }
    }
}
