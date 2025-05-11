using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Diagnostics;

namespace TeorVer1
{
    public partial class Form1 : Form
    {
        const int sizeArr = 10000;
        int K = 0, N = 0, k = 0;
        double sum = 0, m = 0.5, sigma = 0.28;
        double[] arr = new double[sizeArr];
        double[] arrSum = new double[sizeArr];
        double[] randomNumbers = new double[sizeArr];
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("hello");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            N = Convert.ToInt32(textBox2.Text);

            for (int i = 0; i < N; i++)
            {
                arr[i] = r.NextDouble();
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 20; j++) sum += r.NextDouble();
                arrSum[i] = sum;
                sum = 0;
            }

            for (int i = 0; i < N; i++)
            {
                double v = 0;
                for (int j = 0; j < N; j++)
                {
                    v += r.NextDouble();
                }
                double z = (v - (N / 2)) / Math.Sqrt(N / 12);

                randomNumbers[i] = m + z * sigma;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void uniformDist(int N, double[] arr)
        {
            int count;
            double index, interval, max, min;
            K = Convert.ToInt32(textBox1.Text);

            if (K == 0 || N == 0) return;

            min = arr.Min();
            max = arr.Max();

            interval = (max - min) / K;
            index = min;
            count = 0;

            chart1.Series[0].Points.Clear();
            for (int j = 0; j < K; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    if (arr[i] < (index + interval) && arr[i] > index) count++;
                }
                chart1.Series[0].Points.AddXY(index, count / (N * interval));
                index += interval;
                count = 0;
            }
        }

        public void normalDist(int N, double[] arrSum)
        {
            int count;
            double index, interval, max, min;
            K = Convert.ToInt32(textBox1.Text);

            if (K == 0 || N == 0) return;

            min = arrSum.Min();
            max = arrSum.Max();

            interval = (max - min) / K;
            index = min;
            count = 0;

            chart2.Series[0].Points.Clear();
            for (int j = 0; j < K; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    if (arrSum[i] < (index + interval) && arrSum[i] > index) count++;
                }
                chart2.Series[0].Points.AddXY(index, count / (N * interval));
                index += interval;
                count = 0;
            }

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        // Функция для вычисления медианы 2 способом
        public double CalculateMedianFromFrequencies(int[] frequencies, double min, double interval, int N)
        {
            double cumulativeFrequency, medianIntervalEnd, medianIntervalStart, totalFrequency;
            int medianIntervalIndex;

            totalFrequency = frequencies.Sum();

            cumulativeFrequency = 0;
            medianIntervalIndex = -1;
            for (int i = 0; i < frequencies.Length; i++)
            {
                cumulativeFrequency += frequencies[i];

                if (cumulativeFrequency >= totalFrequency / 2)
                {
                    medianIntervalIndex = i;
                    break;
                }
            }

            if (medianIntervalIndex == -1)
            {
                throw new Exception("Не удалось найти медианный интервал.");
            }

            medianIntervalStart = min + medianIntervalIndex * interval;
            medianIntervalEnd = medianIntervalStart + interval;

            return (medianIntervalStart + medianIntervalEnd) / 2.0;
        }


        // Функция для вычисления медианы 1 способом
        public double CalculateMedian(double[] data, int N)
        {
            int n;
            double mid1, mid2;

            var selectedData = data.Take(N).ToArray();
            var sortedData = selectedData.OrderBy(x => x).ToArray();

            n = sortedData.Length;

            if (n % 2 != 0)
            {
                return sortedData[n / 2];
            }
            else
            {
                mid1 = sortedData[(n / 2) - 1];
                mid2 = sortedData[n / 2];
                return (mid1 + mid2) / 2.0;
            }
        }

        public double CalculateModa2(double min, double interval, int[] frequence)
        {
            int frequencyLeft, frequencyRight, maxFrequency, modalIndex;
            double L, mode;

            maxFrequency = frequence.Max();
            modalIndex = Array.IndexOf(frequence, maxFrequency);

            if (modalIndex <= 0 || modalIndex >= frequence.Length - 1)
            {
                return min + (modalIndex + 0.5) * interval;
            }

            frequencyLeft = frequence[modalIndex - 1];
            frequencyRight = frequence[modalIndex + 1];

            L = min + modalIndex * interval;
            mode = L + (maxFrequency - frequencyLeft) * interval / (2 * maxFrequency - frequencyLeft - frequencyRight);

            return mode;
        }
        public void normalDist2(int N)
        {
            double y, max, min, interval, index, maxfrequence = 0, median1, median2, d, sum = 0, m2, maxY = 0, count, sum2, moda1 = 0, moda2;
            int[] frequencies = new int[K];

            k = Convert.ToInt32(textBox3.Text);

            if (K == 0 || N == 0 || k == 0) return;

            min = m - sigma * k;
            max = m + sigma * k;

            chart3.Series[0].Points.Clear();
            interval = (max - min) / K;
            index = min;

            for (int i = 0; i < K; i++)
            {
                y = 0;
                for (int j = 0; j < N; j++)
                {
                    sum2 = 0;
                    count = 0;
                    if (randomNumbers[j] >= index && randomNumbers[j] < index + interval)
                    {
                        y += (1 / (sigma * Math.Sqrt(2 * Math.PI))) * Math.Exp(-(Math.Pow(randomNumbers[j] - m, 2) / (2 * Math.Pow(sigma, 2))));
                        sum += randomNumbers[j];
                        sum2 += randomNumbers[j];
                        frequencies[i]++;
                        count++;
                    }

                    //мода 1 способ
                    if (maxY < y)
                    {
                        maxY = y;
                        moda1 = sum2 / count;
                    }

                }
                chart3.Series[0].Points.AddXY(index, y / (N * interval));
                index += interval;
                if (frequencies[i] > maxfrequence) 
                { 
                    maxfrequence = frequencies[i];
                }
            }

            //мат ожидание
            m2 = sum / N;
            label9.Text = Convert.ToString(m2);

            sum = 0;

            //Дисперсия
            for (int i = 0; i < N; i++) sum += Math.Pow((randomNumbers[i] - m2), 2);
            d = sum / N;
            label10.Text = Convert.ToString(d);

            // медиана 1 способ
            median1 = CalculateMedian(randomNumbers, N);
            label11.Text = median1.ToString();

            // медиана 2 способ
            median2 = CalculateMedianFromFrequencies(frequencies, min, interval, N);
            label14.Text = median2.ToString();

            label17.Text = moda1.ToString();

            //мода 2 способ
            moda2 = CalculateModa2(min,interval,frequencies);
            label18.Text = moda2.ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            uniformDist(N, arr);
            normalDist(N, arrSum);
            normalDist2(N);
        }
    }
}

