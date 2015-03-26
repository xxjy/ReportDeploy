using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ReportDeploy.ReportService;

namespace ReportDeploy
{
    public partial class Form1 : Form
    {
        public static DeployModel Model;

        public Form1()
        {
            InitializeComponent();
            Model = GetDeployList();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtConsole.AppendText("Currently Choose Deploy Report：\r\n");

                foreach (string fileName in openFileDialog1.SafeFileNames)
                {
                    txtConsole.AppendText(fileName);
                    txtConsole.AppendText("\r\n");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Model.Corps.Count; i++)
            {
                Corp corp = Model.Corps[i];

                var checkBox = new CheckBox();
                checkBox.AutoSize = true;
                //checkBox.Width = 130;
                //checkBox.Name = corp.CorpName;
                checkBox.Text = corp.CorpName;
                checkBox.Location = new Point(i/15*150 + 10, i%15*25 + 20);
                groupBox1.Controls.Add(checkBox);
            }
        }


        private DeployModel GetDeployList()
        {
            DeployModel model;
            try
            {
                var serializer = new XmlSerializer(typeof (DeployModel));
                using (Stream stream = new FileStream(Environment.CurrentDirectory + "\\Corp.xml", FileMode.Open))
                {
                    model = serializer.Deserialize(stream) as DeployModel;
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            return model;
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAll.Checked)
            {
                foreach (object control in groupBox1.Controls)
                {
                    if (control is CheckBox)
                    {
                        (control as CheckBox).Checked = true;
                    }
                }
            }
            else
            {
                foreach (object control in groupBox1.Controls)
                {
                    if (control is CheckBox)
                    {
                        (control as CheckBox).Checked = false;
                    }
                }
            }
        }

        private void btnDeploy_Click(object sender, EventArgs e)
        {
            if (!(radioTest.Checked || radioTrue.Checked))
            {
                MessageBox.Show("Please Choose test Oractual", "Tip");
                return;
            }

            List<CheckBox> checkBoxs = GetCheckedBox();
            if (checkBoxs.Count <= 0)
            {
                MessageBox.Show("Please Choose Deploy Corp", "Tip");
                return;
            }

            if (!openFileDialog1.FileNames.Any())
            {
                MessageBox.Show("Please Choose  Deploy Report Files", "Tip");
                return;
            }

            //try
            //{

            //}
            //catch (Exception exception)
            //{
            //    txtConsole.Select(txtConsole.TextLength,);
            //}


            new TaskFactory().StartNew(RunsOnWorkerThread);
        }

        private void RunsOnWorkerThread()
        {
            try
            {
                btnSelectFile.Enabled = false;
                btnDeploy.Enabled = false;
                Deploy();
                btnSelectFile.Enabled = true;
                btnDeploy.Enabled = true;
            }
            catch (Exception exception)
            {
                btnDeploy.Enabled = true;
                WriteError(exception.Message + "\r\n" + exception.StackTrace);
            }
            //new Action(Deploy).Invoke();
        }

        private void Deploy()
        {
            var failure = new Dictionary<string, List<string>>();

            List<CheckBox> checkBoxs = GetCheckedBox();
            var reporting = new ReportingService2010();
            if (radioTest.Checked)
            {
                Server server = Model.Servers.FirstOrDefault(a => a.ServerName == "test");
                reporting.Url = server.ServerUrl;
                reporting.Credentials = new NetworkCredential(server.UserName, server.Password);
            }

            txtConsole.AppendText("\r\n");
            List<Corp> corps =
                checkBoxs.Select(checkBox => Model.Corps.First(a => a.CorpName == checkBox.Text)).ToList();
            foreach (Corp corp in corps)
            {
                txtConsole.AppendText("Begin DeployCorp：" + corp.CorpName + "\r\n");
                if (radioTrue.Checked)
                {
                    Server server = Model.Servers.FirstOrDefault(a => a.ServerName == corp.ServerName);
                    reporting.Url = server.ServerUrl;
                    reporting.Credentials = new NetworkCredential(server.UserName, server.Password);
                }

                string itemParentPath = corp.DefaultPath;
                var list = new List<string>();
                foreach (string file in openFileDialog1.FileNames)
                {
                    byte[] fileBytes = File.ReadAllBytes(file);
                    string fileFullName = Path.GetFileName(file);
                    string fileExtension = Path.GetExtension(fileFullName);

                    string fileName = fileFullName.Substring(0, fileFullName.Length - fileExtension.Length);
                    //var fileName = file.Substring(file.LastIndexOf("\\"), file.LastIndexOf(".") - file.LastIndexOf("\\"));

                    //txtConsole.AppendText("Begin DeployReport：" + fileFullName + "\r\n");

                    Property[] properties = null;

                    Warning[] warnings = null;

                    try
                    {
                        reporting.CreateCatalogItem("Report", fileName, itemParentPath, true, fileBytes, properties,
                                                    out warnings);
                        txtConsole.AppendText(fileFullName + "Deploy Finish\r\n");
                    }
                    catch (Exception exception)
                    {
                        WriteError(fileFullName + "Deploy Error：" + exception.Message);
                        list.Add(fileFullName);
                    }
                    //Warning[] warnings= reporting.SetItemDefinition(itemPath, fileBytes, properties);

                    //if (warnings != null)
                    //{
                    //    var sb = new StringBuilder();
                    //    sb.AppendLine("Warning：");
                    //    foreach (var warning in warnings)
                    //    {
                    //        sb.AppendLine(warning.Message);
                    //    }
                    //    WriteError(sb.ToString());
                    //}
                }
                txtConsole.AppendText(corp.CorpName + "Deploy Finish\r\n\r\n");

                if (list.Count > 0)
                {
                    failure.Add(corp.CorpName, list);
                }
            }

            if (failure.Count > 0)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Current Deploy Error Report：");
                foreach (var f in failure)
                {
                    sb.AppendLine(f.Key);
                    foreach (string report in f.Value)
                    {
                        sb.AppendLine(report);
                    }
                    sb.AppendLine();
                }
                WriteError(sb.ToString());
            }
        }

        private void WriteError(string error)
        {
            int oldLength = txtConsole.TextLength;
            txtConsole.AppendText(error + "\r\n");
            txtConsole.Select(oldLength, error.Length);
            txtConsole.SelectionColor = Color.Red;
        }

        private List<CheckBox> GetCheckedBox()
        {
            var checkBoxs = new List<CheckBox>();
            foreach (object control in groupBox1.Controls)
            {
                var con = control as CheckBox;
                if (con != null && con.Checked)
                {
                    checkBoxs.Add(con);
                }
            }
            return checkBoxs;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtConsole.ResetText();
        }
    }
}