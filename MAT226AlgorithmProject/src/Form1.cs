using System;
using System.Windows.Forms;

namespace MAT226AlgorithmProject
{
    /// <summary>
    /// Windows form, designed to show the user what their adjacency matrix looks like
    /// in a cleaner fashion
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constructor, initializes the form with adjacency matrix data as well as the amount of verteces
        /// </summary>
        /// <param name="vertexCount">amount of vertices in graph</param>
        /// <param name="graph">the user defined adjacency matrix</param>
        public Form1(int vertexCount, int[,] graph)
        {
            InitializeComponent();

            this.dataGridView1.ColumnCount = vertexCount;

            for (int iter = 0; iter < vertexCount; iter++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);

                for (int secondIter = 0; secondIter < vertexCount; secondIter++)
                {
                    row.Cells[secondIter].Value = graph[iter, secondIter];
                }

                this.dataGridView1.Rows.Add(row);
            }
        }

        /// <summary>
        /// When the user clicks the OK button, the window will close and calculation
        /// of the Nearest Neighbor algorithm will continue
        /// </summary>
        /// <param name="sender">EventHandler var</param>
        /// <param name="e">EventHandler var</param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
