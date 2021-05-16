using System;
using System.Windows.Forms;
using System.Xml;

namespace Lab1
{
    public partial class Форма_теста : Form
    {

        public static XmlDocument doc = new XmlDocument();
        public static XmlDocument doc1 = new XmlDocument();


        public Форма_теста()
        {
            InitializeComponent();
            LoadXmlDocument();


        }

        public void LoadXmlDocument()
        {
            doc.Load("Тест1.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {

                string name = node.Attributes[0].Value;
                string identifier = node["Identifier"].InnerText;
                string priority = node["Priority"].InnerText;
                string requirement = node["Requirement"].InnerText;
                string module = node["Module"].InnerText;
                string subModule = node["SubModule"].InnerText;
                string titleAndSteps = node["TitleAndSteps"].InnerText;
                string requiredStepresult = node["RequiredStepResult"].InnerText;


                listBox1.Items.Add(new XMLDocument1(name, identifier, priority, requirement, module,
                    subModule, titleAndSteps, requiredStepresult));

            }

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                propertyGrid1.SelectedObject = listBox1.SelectedItem;
            }
        }

        //Кнопка перехода на форму добавления
        private void button2_Click(object sender, EventArgs e)
        {
            Форма_добавления addDlg = new Форма_добавления();
            addDlg.Show(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
