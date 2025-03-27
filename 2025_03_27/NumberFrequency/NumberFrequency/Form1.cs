namespace NumberFrequency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int SIZE = 1000;
            int num;
            double frequency;
            Random random = new Random();
            int[] numbers = new int[SIZE];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 101);
            }
            if (int.TryParse(numbertextBox.Text, out num))
            {
                int count = frequencyOFNumber(numbers, num);
                frequency = (double)count / SIZE;
                MessageBox.Show("�Ʀr" + num + "�X�{�����v��:" + frequency.ToString("P"));
            }
            else
            {
                MessageBox.Show("���A���~:�п�J���!");
            }
        }

        private int frequencyOFNumber(int[] numbers, int num)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == num)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
