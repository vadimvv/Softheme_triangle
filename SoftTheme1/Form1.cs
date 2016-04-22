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

namespace SoftTheme1
{
    public partial class Form1 : Form
    {
        string numbers = "";
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.Filter = "Файл txt|*.txt";
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                numbers = File.ReadAllText(FileDialog.FileName);
            }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region Знаходження масиву масивів
            int rowCount = 0;
            string[] row = numbers.Split('\n');
            foreach (var item in row)
            {
                rowCount++;
            }

            int[][] f = new int[rowCount][]; //масив рядків
            #endregion

            #region Заповнення елементами
            for (int i = 0; i < f.Length; i++)
            {
                string[] m = row[i].Split(' ');
                f[i] = new int[m.Count()];

                for (int j = 0; j < f[i].Length; j++)
                {
                    f[i][j] = Convert.ToInt32(m[j]);
                }
            }
            #endregion

            #region Знаходження потрібних елементів

            int Max_Sumijne = f[0][0];
            List<int> all_max = new List<int>();
            all_max.Add(Max_Sumijne);
            int position = 0;
            
            for (int i = 1; i < f.Length; i++)
            {

                #region POSITION =  0
                if (position == 0)
                {
                    if (f[i][0] >= f[i][1])
                    {
                        Max_Sumijne = f[i][0];
                        position = 0;
                    }
                    else
                    {
                        Max_Sumijne = f[i][1];
                        position = 1;
                    }

                }
                #endregion
                #region POSITION != 0
                else
                {
                    int[] ar = { f[i][position - 1], f[i][position], f[i][position + 1] };
                    Array.Sort(ar);

                    Max_Sumijne = ar[ar.Length - 1];
                    position = Array.IndexOf(f[i], Max_Sumijne);
                }
                #endregion
                all_max.Add(Max_Sumijne);


            }
            #endregion

            #region Знаходження суми
            int finalSum = 0;
            foreach (var item in all_max)
            {
                finalSum += item;
            }
            MessageBox.Show(finalSum + "");
            #endregion

        }
    }
}
