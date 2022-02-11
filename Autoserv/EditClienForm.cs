using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Autoserv
{
    public partial class EditClienForm : Form
    {
        Client client;
        string expansionImage;
        bool addPhoto = false;
        int id = 0;
        AutoServiceEntities db = new AutoServiceEntities();
        public EditClienForm(int client_id)
        {
            InitializeComponent();
            client = db.Client.Where(p => p.ID == client_id).FirstOrDefault();
            id = client_id;
        }

        private void EditClienForm_Load(object sender, EventArgs e)
        {
            CmbGender.DataSource = db.Gender.ToList();
            CmbGender.DisplayMember = "Name";
            CmbGender.ValueMember = "Code";
            CmbGender.SelectedValue = client.GenderCode;
            CmbTags.DataSource = db.Tag.ToList();
            CmbTags.DisplayMember = "Title";
            CmbTags.ValueMember = "ID";
            TagsTable.Columns.Add("id", "ID");
            TagsTable.Columns.Add("Name", "Наименование");
            List<TagOfClient> list = client.TagOfClient.ToList();
            foreach (TagOfClient item in list)
                Tags.AddTagInTable(db, TagsTable, item.TagID);

            TagsTable.Columns[0].Visible = false;
            TxtName.Text = client.FirstName;
            TxtLastName.Text = client.LastName;
            TxtEmail.Text = client.Email;
            TxtDate.Value = client.Birthday;
            TxtMiddle.Text = client.Patronymic;
            TxtPhone.Text = client.Phone;
            try
            {
                ImageBox.Image = new Bitmap(client.PhotoPath);
                ImageBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { }
            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddTag_Click(object sender, EventArgs e)
        {
            Tags.AddTagInTable(db, TagsTable, Convert.ToInt32(CmbTags.SelectedValue));
        }

        private void DelTag_Click(object sender, EventArgs e)
        {
            Tags.DelTagInTable(TagsTable);
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
                    Client cl = db.Client.Where(p => p.ID == id).FirstOrDefault(); 
                    string filePath;
                    if (addPhoto)
                    {
                        if (ImageBox.Image != null)
                        {
                            filePath = @"Image\\" + Guid.NewGuid() + "." + expansionImage;
                            ImageBox.Image.Save(filePath);
                        }
                        else
                            filePath = @"Image\\cat.png";
                    }
                    else filePath = cl.PhotoPath;


                   
                    cl.FirstName = TxtName.Text;
                    cl.LastName = TxtLastName.Text;
                    cl.Patronymic = TxtMiddle.Text;
                    cl.Email = TxtEmail.Text;
                    cl.GenderCode = CmbGender.SelectedValue.ToString();
                    cl.Birthday = TxtDate.Value;
                    cl.RegistrationDate = DateTime.Now;
                    cl.Phone = TxtPhone.Text;
                    cl.PhotoPath = filePath;
                    Tags.AddTagsInDB(db, TagsTable, cl.ID);
                    Refs.mainForm.UpdateTable() ;
                    db.SaveChanges();

                    MessageBox.Show("Вы успешно обновили данные пользователя");
                    this.Close();
                }
                else MessageBox.Show("Проверьте корректность введенного email");
            }
            else MessageBox.Show("Проверьте корретность введенных данных в поля 'Фамилия' и 'Имя'");
        }

        private void AddPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "File JPG|*.jpg|File png|*.png|All file |*.*";
                try
                {
                    if (openFile.ShowDialog(this) == DialogResult.OK)
                    {
                        ImageBox.Image = new Bitmap(openFile.FileName);
                        ImageBox.SizeMode = PictureBoxSizeMode.Zoom;
                        expansionImage = getFileExtension(openFile.FileName);
                        addPhoto = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Данный файл не является графическим объектом!");
                }
            }
        }

        private void TagsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CmbTags_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
