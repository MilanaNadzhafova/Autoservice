using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoserv
{
    public partial class AddClientForm : Form
    {
        AutoServiceEntities db = new AutoServiceEntities();
        string expansionImage;
        public AddClientForm()
        {
            InitializeComponent();
        }

        public string getFileExtension(string fileName) // Получение типа фотографии
        {
            return fileName.Substring(fileName.LastIndexOf(".") + 1);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Utils.CheckFIO(TxtName.Text) && Utils.CheckFIO(TxtLastName.Text))
            {
                if (Utils.CheckEmail(TxtEmail.Text))
                {
                    string filePath;
                    if (ImageBox.Image != null)
                    {
                        filePath = @"Image\\" + Guid.NewGuid() + "." + expansionImage;
                        ImageBox.Image.Save(filePath);
                    }
                    else
                        filePath = @"Image\\cat.png";

                    Client client = new Client
                    {
                        FirstName = TxtName.Text,
                        LastName = TxtLastName.Text,
                        Patronymic = TxtMiddle.Text,
                        Email = TxtEmail.Text,
                        GenderCode = CmbGender.SelectedValue.ToString(),
                        Birthday = TxtDate.Value,
                        RegistrationDate = DateTime.Now,
                        Phone = TxtPhone.Text,
                        PhotoPath = filePath
                    };
                    client = db.Client.Add(client);
                    db.SaveChanges();
                    Tags.AddTagsInDB(db, TagsTable, client.ID);
                    Refs.mainForm.UpdateTable();
                    MessageBox.Show("Вы успешно добавиили пользователя");
                    this.Close();
                }
                else MessageBox.Show("Проверьте корректность введенного email");
            }
            else MessageBox.Show("Проверьте корретность введенных данных в поля 'Фамилия' и 'Имя'");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddClientForm_Load(object sender, EventArgs e)
        {
            CmbGender.DataSource = db.Gender.ToList();
            CmbGender.DisplayMember = "Name";
            CmbGender.ValueMember = "Code";
            CmbTags.DataSource = db.Tag.ToList();
            CmbTags.DisplayMember = "Title";
            CmbTags.ValueMember = "ID";
            TagsTable.Columns.Add("id", "ID");
            TagsTable.Columns.Add("Name", "Наименование");
            TagsTable.Columns[0].Visible = false;
        }

        private void AddPhoto_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFile = new OpenFileDialog()){
                openFile.Filter = "File JPG|*.jpg|File png|*.png|All file |*.*";
                try
                {
                    if (openFile.ShowDialog(this) == DialogResult.OK)
                    {
                        ImageBox.Image = new Bitmap(openFile.FileName);
                        ImageBox.SizeMode = PictureBoxSizeMode.Zoom;
                        expansionImage = getFileExtension(openFile.FileName);
                    }
                }
                catch
                {
                    MessageBox.Show("Данный файл не является графическим объектом!");
                }
            }
            
        }

        private void AddTag_Click(object sender, EventArgs e)
        {
            Tags.AddTagInTable(db, TagsTable, Convert.ToInt32(CmbTags.SelectedValue));
        }

        private void DelTag_Click(object sender, EventArgs e)
        {
            Tags.DelTagInTable(TagsTable);
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
