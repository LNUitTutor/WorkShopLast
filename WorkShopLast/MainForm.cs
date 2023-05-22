using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkShopLast
{
    public partial class MainForm : Form
    {
        CancellationTokenSource source;
        IProgress<(string, int)> progress;
        public MainForm()
        {
            InitializeComponent();
            progress = new Progress<(string, int)>(
                value => {
                    label2.Text = value.Item1;
                    progressBar.Value = value.Item2;
                });
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void buttonRun_Click(object sender, EventArgs e)
        {
            buttonClear.Enabled = true;
            buttonRun.Enabled = false;

            source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            
            int result = await Task.Run(() =>
            {
                int i = 0;
                for (; i <= 100; ++i)
                {
                    progress.Report((i.ToString() + "%", i));
                    Thread.Sleep(200);
                    if (i % 20 == 0 && token.IsCancellationRequested) break;
                }
                return i;
            });
            MessageBox.Show($" The value returned by Thread is {result}", "Result");
        }

        private void buttonBreak_Click(object sender, EventArgs e)
        {
            //progressBar.Value -= 5;
            source.Cancel();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            buttonClear.Enabled = false;
            buttonRun.Enabled = true;

            label2.Text = "0%";
            progressBar.Value = 0;
        }
    }
}
