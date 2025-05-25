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
        double sum = 0, m = 0;
        double[] arr = new double[sizeArr];
        double[] arrSum = new double[sizeArr];
        double[] randomNumbers = new double[sizeArr];
        Random r = new Random();
        Microsoft.Office.Interop.Excel.Application _ex = new Microsoft.Office.Interop.Excel.Application();
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

            medianIntervalStart = min + medianIntervalIndex * interval;
            medianIntervalEnd = medianIntervalStart + interval;

            return (medianIntervalStart + medianIntervalEnd) / 2.0;
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            normalDist2(N);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

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

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

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
        public double normalDistDensity(double m, double x, double sigma)
        {
            return (1.0 / (sigma * Math.Sqrt(2 * Math.PI))) * Math.Exp(-(Math.Pow(x - m, 2) / (2 * Math.Pow(sigma, 2))));
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        public double CDF(double x, double m, double sigma)
        {
            return _ex.WorksheetFunction.NormDist(x, m, sigma, true);
        }

        public void normalDist2(int N)
        {
            double alpha = 0, y = 0, max, min, interval, index, maxfrequence = 0, median1, median2, d, sum = 0, m2, maxY = 0, sum2, moda1 = 0, moda2, sigma = 1;
            int[] frequencies = new int[K];
            int count = 0;

            double HiSquare = 0;

            alpha = Convert.ToDouble(textBox6.Text);

            k = Convert.ToInt32(textBox3.Text);

            m = Convert.ToInt32(textBox4.Text);

            sigma = Convert.ToInt32(textBox5.Text);

            if (K == 0 || N == 0 || k == 0 || sigma < 0 || alpha < 0 || alpha > 1) return;

            min = m - sigma * k;
            max = m + sigma * k;

            double[] arr = new double[N];
            double[] arrP = new double[K];
            double[] midIntervals = new double[K];
            double[] zi = new double[K];
            double[] ni = new double[K];
            double x, r1, r2, ym, fx, midInterval, sampleMean = 0;

            for (int i = 0; i < N; i++)
            {
                r1 = r.NextDouble();
                r2 = r.NextDouble();
                x = min + r1 * (max - min);
                ym = normalDistDensity(m, m, sigma);
                fx = normalDistDensity(m, x, sigma);
                y = r2 * ym;
                if (y < fx)
                {
                    arr[i] = x;
                }
                else
                {
                    i--;
                    continue;
                }
            }

            for (int i = 0; i < N; i++) sum += arr[i];

            //мат ожидание
            m2 = sum / N;
            label9.Text = Convert.ToString(m2);
            chart3.Series[0].Points.Clear();
            min = arr.Min();
            max = arr.Max();
            interval = (max - min) / K;
            index = min;
            for (int i = 0; i < K; i++)
            {
                sum2 = 0;
                for (int j = 0; j < N; j++)
                {
                    if (arr[j] < (index + interval) && arr[j] > index)
                    {
                        count++;
                        sum2 += arr[j];
                    }
                }
                chart3.Series[0].Points.AddXY(index, count / (N * interval));

                arrP[i] = CDF(index + interval, m, sigma) - CDF(index, m, sigma); 

                midIntervals[i] = (index + interval) / 2;
                frequencies[i] = count;

                sampleMean += midIntervals[i] * frequencies[i];

                index += interval;

                if (maxY < count)
                {
                    maxY = count;
                    moda1 = sum2 / count; //мода 1 способ
                }

                if (frequencies[i] > maxfrequence)
                {
                    maxfrequence = frequencies[i];
                }
                count = 0;
            }

            sampleMean /= N;


            for (int i = 0; i < K; i++)
            {
                HiSquare += Math.Pow(frequencies[i] - N * arrP[i], 2) / (arrP[i] * N);
            }

            label20.Text = HiSquare.ToString();

            if (K == 5 && alpha == 0.01 && HiSquare < 13.2767)
            {
                label25.Text = "H0";
            }
            else if (K == 5 && alpha == 0.025 && HiSquare < 11.14329)
            {
                label25.Text = "H0";
            }
            else if (K == 5 && alpha == 0.05 && HiSquare < 9.48773)
            {
                label25.Text = "H0";
            }
            else if (K == 10 && alpha == 0.01 && HiSquare < 21.66599)
            {
                label25.Text = "H0";
            }
            else if (K == 10 && alpha == 0.025 && HiSquare < 19.02277)
            {
                label25.Text = "H0";
            }
            else if (K == 10 && alpha == 0.05 && HiSquare < 16.91898)
            {
                label25.Text = "H0";
            }
            else if (K == 20 && alpha == 0.01 && HiSquare < 36.19087)
            {
                label25.Text = "H0";
            }
            else if (K == 20 && alpha == 0.025 && HiSquare < 32.85233)
            {
                label25.Text = "H0";
            }
            else if (K == 20 && alpha == 0.05 && HiSquare < 30.14353)
            {
                label25.Text = "H0";
            }
            else
            {
                label25.Text = "H1";
            }


            sum = 0;

            //Дисперсия
            for (int i = 0; i < N; i++) sum += Math.Pow((arr[i] - m2), 2);
            d = sum / N;
            label10.Text = Convert.ToString(d);

            //медиана 1 способ
            median1 = CalculateMedian(arr, N);
            label11.Text = median1.ToString();

            // медиана 2 способ
            median2 = CalculateMedianFromFrequencies(frequencies, min, interval, N);
            label14.Text = median2.ToString();

            label17.Text = moda1.ToString();

            //мода 2 способ
            moda2 = CalculateModa2(min, interval, frequencies);
            label18.Text = moda2.ToString();

            for (int i = 0; i < K; i++)
            {
                double sampleSigma = Math.Sqrt(d);
                zi[i] = (midIntervals[i] - sampleMean) / sampleSigma;
                ni[i] = (interval * N) * normalDistDensity(m, zi[i], 1);
            }

            for (int i = 0; i < K; i++)
            {
                HiSquare += Math.Pow(frequencies[i] - ni[i], 2) / (ni[i]);
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            uniformDist(N, arr);
            normalDist(N, arrSum);
        }
    }
}
