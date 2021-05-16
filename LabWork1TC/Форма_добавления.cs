using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Lab1
{
    public partial class Форма_добавления : Form
    {
        XmlDocument doc = new XmlDocument();

        public Форма_добавления()
        {
            InitializeComponent();
            LoadXMLDoc();
        }


        public void LoadXMLDoc()
        {
            //путь к внутреннему месту xml-файла
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            doc.Load(path + @"\New XML document.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node["Name"].InnerText;
                string identifier = node["Identifier"].InnerText;
                string priority = node["Priority"].InnerText;
                string requirement = node["Requirement"].InnerText;
                string module = node["Module"].InnerText;
                string submodule = node["Submodule"].InnerText;
                string titleAndSteps = node["TitleAndSteps"].InnerText;
                string requiredStepresult = node["RequiredStepResult"].InnerText;

                listBox1.Items.Add(new XMLDocument1(name, identifier, priority, requirement, module,
                    submodule, titleAndSteps, requiredStepresult));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                propertyGrid1.SelectedObject = listBox1.SelectedItem;
            }
        }




        //Сохранить как
        private void button3_Click(object sender, EventArgs e)
        {
            string name1 = Название_тест_кейса.Text;
            string identifier1 = Идентификатор.Text;
            string priority1 = Приоритет.Text;
            string requirement1 = Требование_тест_кейса.Text;
            string module1 = Модуль.Text;
            string submodule1 = Подмодуль.Text;
            string titleAndSteps1 = Название_и_шаги.Text;
            string requiredStepResult1 = Ожидаемый_результат_шага.Text;

            try
            {

                DataSet ds = new DataSet(); //Создайте пустой кэш таблицы
                DataTable dt = new DataTable(); //Пустая таблица 
                dt.TableName = "Autotest";
                dt.Columns.Add("Name");
                dt.Columns.Add("Identifier");
                dt.Columns.Add("Priority");
                dt.Columns.Add("Requirement");
                dt.Columns.Add("Module");
                dt.Columns.Add("Submodule");
                dt.Columns.Add("TitleAndSteps");
                dt.Columns.Add("RequiredStepResult");

                ds.Tables.Add(dt);

                //Строка заголовка
                DataRow row = ds.Tables["Autotest"].NewRow();
                row["Name"] = "Название кейса";
                row["Identifier"] = "Идентификатор";
                row["Priority"] = "Приоритет";
                row["Requirement"] = "Требование";
                row["Module"] = "Модуль";
                row["Submodule"] = "Подмодуль";
                row["TitleAndSteps"] = "Заглавие тест-кейса";
                row["RequiredStepResult"] = "Ожидаемый результат";
                ds.Tables["Autotest"].Rows.Add(row);

                //Строка набранных значений
                DataRow row1 = ds.Tables["Autotest"].NewRow();
                row1["Name"] = name1;
                row1["Identifier"] = identifier1;
                row1["Priority"] = priority1;
                row1["Requirement"] = requirement1;
                row1["Module"] = module1;
                row1["Submodule"] = submodule1;
                row1["TitleAndSteps"] = titleAndSteps1;
                row1["RequiredStepResult"] = requiredStepResult1;
                ds.Tables["Autotest"].Rows.Add(row1);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML-File | *.xml";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ds.WriteXml(saveFileDialog.FileName);
                }

                MessageBox.Show("Файл сохранен", "Успешно");
            }
            catch
            {
                MessageBox.Show("Файл не был сохранен", "ошибка сохранения");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
