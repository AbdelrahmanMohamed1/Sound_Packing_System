using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AlgoProject
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<int> arr = new List<int>();
        public List<int> indexx = new List<int>();
        Dictionary<int, int> dict = new Dictionary<int, int>();
          int c = 1;

        public async void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        // store final seconeds of the mp3 file
                        List<string> line = new List<string>();  // split the mp3 file to lines
                        List<string> strs = new List<string>();    // split the line file to strings




                        string str;
                        str = sr.ReadLine();
                        while (str != null)
                        {
                            line.Add(str);                           //store the mp3 file lines in list of lines
                            str = sr.ReadLine();

                        }

                        //*******************************************************************************************************
                        // should be a method
                        int line_count = line.Count();
                        for (int i = 1; i < line_count; i++)
                        {
                            string l = line[i];
                            char ss = l[0];
                            string st = "";
                            st += ss;
                            int N = 0;
                            N = int.Parse(st);
                            indexx.Add(N);
  
                         }


                        for (int i = 1; i < line_count; i++)
                        {
                            string l = line[i];
                            string ss = "";
                            int l_len = l.Length;
                            for (int j = 0; j < l_len; j++)
                            {
                                if (l[j] != ' ')
                                    ss += l[j];

                            }
                            string st = "";
                            int k = 0;
                            while (ss[k] != 'p')
                            {
                                k++;
                            }
                            int s_len = ss.Length;
                            for (int j = k + 2; j < s_len; j++)
                            {
                                st += ss[j];
                            }

                            string s = "";
                            int st_len = st.Length;
                            for (int j = 0; j < st_len; j++)
                            {
                                if (st[j] == ':') { strs.Add(s); s = ""; }
                                else
                                {
                                    s += st[j];
                                }
                                if (j == st.Length - 1) strs.Add(s);
                            }

                            int total = 0;
                            int N = 0;
                            N = int.Parse(strs[0]);
                            total += N * 60 * 60;
                            N = int.Parse(strs[1]);
                            total += N * 60;
                            N = int.Parse(strs[2]);
                            total += N;
                            arr.Add(total);
                            strs.Clear();
                           
                        }
                        
                        for (int i = 0; i < line_count - 1; i++)
                        {
                            //MessageBox.Show(indexx[i].ToString());
                            dict.Add(indexx[i], arr[i]);
                            //MessageBox.Show(dict[indexx[i]].ToString());

                        }
                       
                        sr.Close();
                    }

                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {

            Algo obj = new Algo();
            int maxsize = Convert.ToInt16(textBox1.Text);
            List<Map> folders = new List<Map>(obj.worst_fit(arr, maxsize));
            string filename = "";
            string foldername = @"C:\Users\SherifMounir\Documents";
            string filePath = System.IO.Path.Combine(foldername, "worst_fit" + c.ToString());
            int total = 0;
            for (int j = 0; j < folders.Count; j++)
            {
                filename = "f" + c.ToString();
                FileInfo fileusername = new FileInfo(filename);
                StreamWriter namewriter = fileusername.CreateText();
                //namewriter.WriteLine(folders[j].L.Count.ToString());
                namewriter.WriteLine(folders[j].name);
                 for (int k = 0; k < folders[j].L.Count; k++)
                            {
                                total += folders[j].L[k];
                                namewriter.Write(folders[j].index[k]);
                               namewriter.Write("." +"mp3 ");
                               
                                namewriter.WriteLine(obj.converttosec(folders[j].L[k]));
                            }
               //  namewriter.Write("total size : ");
                 namewriter.WriteLine(obj.converttosec(total));
                 total = 0;
                 namewriter.Close();
                 System.IO.File.Move(filename, filePath);
                 c++;
                 filePath = System.IO.Path.Combine(foldername, "worst_fit" + c.ToString());

               
            }
                MessageBox.Show("saved");

            }
            
        

        private void button3_Click(object sender, EventArgs e)
        {

            Algo obj = new Algo();
            int maxsize = Convert.ToInt16(textBox1.Text);
             arr.Sort();
            Dictionary<int, Map> pr = obj.worst_fit_priority(arr, maxsize);

            List<int> keyList = new List<int>(pr.Keys);
            string filename = "";
            string foldername = @"C:\Users\SherifMounir\Documents";
            string filePath = System.IO.Path.Combine(foldername, "worst_fit_priority" + c.ToString());
            int total = 0;
            for (int j = 0; j < keyList.Count; j++)
            {
                int z = keyList[j];
                filename = "f" + c.ToString();
                FileInfo fileusername = new FileInfo(filename);
                StreamWriter namewriter = fileusername.CreateText();
                 //namewriter.WriteLine(pr[z].L.Count);
                 namewriter.WriteLine(pr[z].name);
                 
                   for (int k = 0; k < pr[z].L.Count; k++)
                            {
                                total += pr[z].L[k];
                                namewriter.Write(pr[z].index[k]);
                                namewriter.Write("." + "mp3 ");
                                namewriter.WriteLine(obj.converttosec(pr[z].L[k]));
                            }
                  // namewriter.Write("total size : ");
                   namewriter.WriteLine(obj.converttosec(total));
                   total = 0;
                namewriter.Close();
                System.IO.File.Move(filename, filePath);
                c++;
                filePath = System.IO.Path.Combine(foldername, "worst_fit_priority" + c.ToString());

                
                }
                MessageBox.Show("saved");
            
            
            
            }

        private void button3_Click_1(object sender, EventArgs e)
        {

            Algo obj = new Algo();
            int maxsize = Convert.ToInt16(textBox1.Text);
            arr.Sort();
            arr.Reverse();
            List<Map> folders = new List<Map>(obj.worst_fit(arr, maxsize));
            string filename = "";
            string foldername = @"C:\Users\SherifMounir\Documents";
            string filePath = System.IO.Path.Combine(foldername, "worst_fit_decreasing" + c.ToString());
            int total = 0;
            for (int j = 0; j < folders.Count; j++)
            {
                filename = "f" + c.ToString();
                FileInfo fileusername = new FileInfo(filename);
                StreamWriter namewriter = fileusername.CreateText();
                //namewriter.WriteLine(folders[j].L.Count.ToString());
                namewriter.WriteLine(folders[j].name);
                for (int k = 0; k < folders[j].L.Count; k++)
                {
                    total += folders[j].L[k];
                    namewriter.Write(folders[j].index[k]);
                    namewriter.Write("." + "mp3 ");

                    namewriter.WriteLine(obj.converttosec(folders[j].L[k]));
                }
                //  namewriter.Write("total size : ");
                namewriter.WriteLine(obj.converttosec(total));
                total = 0;
                namewriter.Close();
                System.IO.File.Move(filename, filePath);
                c++;
                filePath = System.IO.Path.Combine(foldername, "worst_fit_decreasing" + c.ToString());


            }
            MessageBox.Show("saved");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Algo obj = new Algo();
            int maxsize = Convert.ToInt16(textBox1.Text);
            arr.Sort();
            arr.Reverse();
            Dictionary<int, Map> pr = obj.worst_fit_priority(arr, maxsize);

            List<int> keyList = new List<int>(pr.Keys);
            string filename = "";
            string foldername = @"C:\Users\SherifMounir\Documents";
            string filePath = System.IO.Path.Combine(foldername, "worst_fit_priority_dec" + c.ToString());
            int total = 0;
            for (int j = 0; j < keyList.Count; j++)
            {
                int z = keyList[j];
                filename = "f" + c.ToString();
                FileInfo fileusername = new FileInfo(filename);
                StreamWriter namewriter = fileusername.CreateText();
                //namewriter.WriteLine(pr[z].L.Count);
                namewriter.WriteLine(pr[z].name);

                for (int k = 0; k < pr[z].L.Count; k++)
                {
                    total += pr[z].L[k];
                    namewriter.Write(pr[z].index[k]);
                    namewriter.Write("." + "mp3 ");
                    namewriter.WriteLine(obj.converttosec(pr[z].L[k]));
                }
                // namewriter.Write("total size : ");
                namewriter.WriteLine(obj.converttosec(total));
                total = 0;
                namewriter.Close();
                System.IO.File.Move(filename, filePath);
                c++;
                filePath = System.IO.Path.Combine(foldername, "worst_fit_priority_dec" + c.ToString());


            }
            MessageBox.Show("saved");
            
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Algo obj = new Algo();
            int maxsize = Convert.ToInt16(textBox1.Text);
            arr.Sort();
            arr.Reverse();
           // dict = dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            
            List<Map> folders = new List<Map>(obj.first_fit_decreasing_usinglinearsearch(arr, maxsize , dict));
            string filename = "";
            string foldername = @"C:\Users\SherifMounir\Documents";
            string filePath = System.IO.Path.Combine(foldername, "FirstFitDecreasingOrder" + c.ToString());
            int total = 0;
            
            for (int j = 0; j < folders.Count; j++)
            {
                filename = "f" + c.ToString();
                FileInfo fileusername = new FileInfo(filename);
                StreamWriter namewriter = fileusername.CreateText();
                //namewriter.WriteLine(folders[j].L.Count.ToString());
                namewriter.WriteLine(folders[j].name);
                for (int k = 0; k < folders[j].L.Count; k++)
                {
                    total += folders[j].L[k];
             
                    namewriter.Write(folders[j].index[k]);
                    namewriter.Write("." + "mp3 ");
                    namewriter.WriteLine(obj.converttosec(folders[j].L[k]));
                }
                //  namewriter.Write("total size : ");
                namewriter.WriteLine(obj.converttosec(total));
                total = 0;
                namewriter.Close();
                System.IO.File.Move(filename, filePath);
                c++;
                filePath = System.IO.Path.Combine(foldername, "FirstFitDecreasingOrder" + c.ToString());


            }
            MessageBox.Show("saved");
        }

        }

    }

