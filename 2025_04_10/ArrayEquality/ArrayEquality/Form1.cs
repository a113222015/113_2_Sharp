namespace ArrayEquality
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 2, 3, 4, 5,6 };

            // 檢查兩個陣列是否相等
            bool arraysEqual = isArraysEqual1(array1, array2);

            if (arraysEqual)
            {
                MessageBox.Show("兩個陣列相等");
            }
            else
            {
                MessageBox.Show("兩個陣列不相等");
            }
        }

        private bool isArraysEqual1(int[] array1, int[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
