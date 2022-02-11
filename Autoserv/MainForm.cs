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
    public partial class MainForm : Form
    {
        int TotalPages;
        int CurrentIndexPage = 1;
        int PageSize;
        AutoServiceEntities db = new AutoServiceEntities();
        string SearchStr = null;

        public MainForm()
        {
            InitializeComponent();
            Refs.mainForm = this;
        }

        private void CalculateTotalPages()
        {
            int RowCount = 0;
            List<Client> list = new List<Client>();
            if (CmbGenderFilter.SelectedIndex == 0)
                list = db.Client.ToList();
            else if (CmbGenderFilter.SelectedIndex == 1)
                list = db.Client.Where(p => p.GenderCode == "м").ToList();

            else if (CmbGenderFilter.SelectedIndex == 2)
                list = db.Client.Where(p => p.GenderCode == "ж").ToList();

            if (SearchStr != null)
                list = SearchList(list);

            if (CheckBirthday.Checked)
                list = ShowCurrentMonthBirthday(list);

            RowCount = Convert.ToInt32(list.Count()); ;
            if (PageSize != 0)
            {
                TotalPages = RowCount / PageSize;
                if (RowCount % PageSize > 0)
                    TotalPages += 1;
            }
            else
                TotalPages = 0;
        }

        public string PrintLabText(bool check, int page = 1)
        {
            int PreviousPageOffSet = (page - 1) * PageSize;
            if (check)
            {
                
                if (CmbGenderFilter.SelectedIndex == 0)
                {
                    if (CheckBirthday.Checked)
                    {
                        var before = db.Client.Where(p=>p.Birthday.Month == DateTime.Now.Month).Select(p => p.ID).Take(PreviousPageOffSet).Count();
                        var NoProviders = db.Client.Where(p => p.Birthday.Month == DateTime.Now.Month).Select(p => p.ID).Take(PreviousPageOffSet).ToArray();
                        var after = db.Client.Where(p => !NoProviders.Contains(p.ID) && p.Birthday.Month == DateTime.Now.Month).Take(PageSize).Count();
                        return (before + after).ToString() + " из " + db.Client.Count().ToString();
                    }
                    else
                    {
                        var before = db.Client.Select(p => p.ID).Take(PreviousPageOffSet).Count();
                        var NoProviders = db.Client.Select(p => p.ID).Take(PreviousPageOffSet).ToArray();
                        var after = db.Client.Where(p => !NoProviders.Contains(p.ID)).Take(PageSize).Count();
                        return (before + after).ToString() + " из " + db.Client.Count().ToString();
                    }
                    
                }
                else if (CmbGenderFilter.SelectedIndex == 1)
                {
                    var before = db.Client.Where(p => p.GenderCode == "м" && p.Birthday.Month == DateTime.Now.Month).Select(p => p.ID).Take(PreviousPageOffSet).Count();
                    var NoProviders = db.Client.Where(p => p.GenderCode == "м" && p.Birthday.Month == DateTime.Now.Month).Select(p => p.ID).Take(PreviousPageOffSet).ToArray();
                    var after = db.Client.Where(p => !NoProviders.Contains(p.ID) && p.GenderCode =="м" && p.Birthday.Month == DateTime.Now.Month).Take(PageSize).Count();
                    return (before + after).ToString() + " из " + db.Client.Where(p => p.GenderCode == "м" && p.Birthday.Month == DateTime.Now.Month).Count().ToString();
                }

                else if (CmbGenderFilter.SelectedIndex == 2)
                {
                    var before = db.Client.Where(p => p.GenderCode == "ж" && p.Birthday.Month == DateTime.Now.Month).Select(p => p.ID).Take(PreviousPageOffSet).Count();
                    var NoProviders = db.Client.Where(p => p.GenderCode == "ж" && p.Birthday.Month == DateTime.Now.Month).Select(p => p.ID).Take(PreviousPageOffSet).ToArray();
                    var after = db.Client.Where(p => !NoProviders.Contains(p.ID) && p.GenderCode == "ж" && p.Birthday.Month == DateTime.Now.Month).Take(PageSize).Count();
                    return (before + after).ToString() + " из " + db.Client.Where(p => p.GenderCode == "ж" && p.Birthday.Month == DateTime.Now.Month).Count().ToString();
                }

                return "";
            }
            else
            {
                if (CmbGenderFilter.SelectedIndex == 0)
                {
                    if (CheckBirthday.Checked)
                        return db.Client.OrderBy(p => p.ID).Where(p => p.Birthday.Month == DateTime.Now.Month).Take(PageSize).Count().ToString() + " из " + db.Client.Count().ToString();
                    else
                        return db.Client.OrderBy(p => p.ID).Take(PageSize).Count().ToString() + " из " + db.Client.Count().ToString();
                }
                else if (CmbGenderFilter.SelectedIndex == 1)
                {
                    if (CheckBirthday.Checked)
                        return db.Client.OrderBy(p => p.ID).Where(p => p.Birthday.Month == DateTime.Now.Month && p.GenderCode == "м").Take(PageSize).Count().ToString() + " из " + db.Client.Count().ToString();
                    else
                        return db.Client.OrderBy(p => p.ID).Where(p => p.GenderCode == "м").Take(PageSize).Count().ToString() + " из " + db.Client.Where(p => p.GenderCode == "м").Count().ToString();
                }
                else if (CmbGenderFilter.SelectedIndex == 2)
                {
                    if (CheckBirthday.Checked)
                        return db.Client.OrderBy(p => p.ID).Where(p => p.Birthday.Month == DateTime.Now.Month && p.GenderCode == "ж").Take(PageSize).Count().ToString() + " из " + db.Client.Count().ToString();
                    else
                        return db.Client.OrderBy(p => p.ID).Where(p => p.GenderCode == "ж").Take(PageSize).Count().ToString() + " из " + db.Client.Where(p => p.GenderCode == "ж").Count().ToString();
                }
                return "";
            }

                
        }

        public List <Client> SearchList( List <Client> list)
        {
            List<Client> new_list = new List<Client>();
            foreach (Client cl in list)
            {
                if (cl.FirstName.Contains(SearchStr) ||cl.LastName.Contains(SearchStr) || cl.Patronymic.Contains(SearchStr) || cl.Phone.Contains(SearchStr) || cl.Email.Contains(SearchStr))
                {
                    new_list.Add(cl);
                }
            }
            return new_list;
        }

        private List<Client> GetCurrentRecords(int page)
        {
            List<Client> list = new List<Client>();

            if (page == 1)
            {
                if (CmbGenderFilter.SelectedIndex == 0)
                {
                    if (CheckBirthday.Checked)
                        list = db.Client.OrderBy(p => p.ID).Where(p => p.Birthday.Month == DateTime.Now.Month).Take(PageSize).ToList();
                    else
                        list = db.Client.OrderBy(p => p.ID).Take(PageSize).ToList();
                }
                else if (CmbGenderFilter.SelectedIndex == 1)
                {
                    if (CheckBirthday.Checked) 
                        list = db.Client.OrderBy(p => p.ID).Where(p => p.GenderCode == "м" && p.Birthday.Month == DateTime.Now.Month).Take(PageSize).ToList();
                    else
                        list = db.Client.OrderBy(p => p.ID).Where(p => p.GenderCode == "м").Take(PageSize).ToList();
                }
                    
                    
                else if (CmbGenderFilter.SelectedIndex == 2)
                {
                    if (CheckBirthday.Checked)
                        list = db.Client.OrderBy(p => p.ID).Where(p => p.GenderCode == "ж" && p.Birthday.Month == DateTime.Now.Month).Take(PageSize).ToList();
                    else
                        list = db.Client.OrderBy(p => p.ID).Where(p => p.GenderCode == "ж").Take(PageSize).ToList();
                }
                PageLab.Text = PrintLabText(false, page);
            }
            else
            {
                int PreviousPageOffSet = (page - 1) * PageSize;
                int[] NoProviders = null;
                if (CmbGenderFilter.SelectedIndex == 0)
                {
                    if (CheckBirthday.Checked)
                    {
                        NoProviders = db.Client.Where(p=>p.Birthday.Month == DateTime.Now.Month).Select(p => p.ID).Take(PreviousPageOffSet).ToArray();
                        list = db.Client.Where(p => !NoProviders.Contains(p.ID) && p.Birthday.Month == DateTime.Now.Month).Take(PageSize).ToList();
                    }
                    else
                    {
                        NoProviders = db.Client.Select(p => p.ID).Take(PreviousPageOffSet).ToArray();
                        list = db.Client.Where(p => !NoProviders.Contains(p.ID)).Take(PageSize).ToList();
                    }

                }
                else if (CmbGenderFilter.SelectedIndex == 1)
                {
                    if (CheckBirthday.Checked)
                    {
                        NoProviders = db.Client.Where(p => p.Birthday.Month == DateTime.Now.Month && p.GenderCode == "м").Select(p => p.ID).Take(PreviousPageOffSet).ToArray();
                        list = db.Client.Where(p => !NoProviders.Contains(p.ID) && p.Birthday.Month == DateTime.Now.Month && p.GenderCode == "м").Take(PageSize).ToList();
                    }
                    else
                    {
                        NoProviders = db.Client.Where(p => p.GenderCode == "м").Select(p => p.ID).Take(PreviousPageOffSet).ToArray();
                        list = db.Client.Where(p => !NoProviders.Contains(p.ID) && p.GenderCode == "м").Take(PageSize).ToList();
                    }
                   
                }
                    
                else if (CmbGenderFilter.SelectedIndex == 2)
                {
                    if (CheckBirthday.Checked)
                    {
                        NoProviders = db.Client.Where(p => p.Birthday.Month == DateTime.Now.Month && p.GenderCode == "ж").Select(p => p.ID).Take(PreviousPageOffSet).ToArray();
                        list = db.Client.Where(p => !NoProviders.Contains(p.ID) && p.Birthday.Month == DateTime.Now.Month && p.GenderCode == "ж").Take(PageSize).ToList();
                    }
                    else
                    {
                        NoProviders = db.Client.Where(p => p.GenderCode == "ж").Select(p => p.ID).Take(PreviousPageOffSet).ToArray();
                        list = db.Client.Where(p => !NoProviders.Contains(p.ID) && p.GenderCode == "ж").Take(PageSize).ToList();
                    }
                }

                PageLab.Text = PrintLabText(true, page);
            }
            if (SearchStr != null)
                list = SearchList(list);
            if (CheckBirthday.Checked)
                list = ShowCurrentMonthBirthday(list);

            list = SortTable(list);

            return list;
        }

        public void RemoveClient()
        {
            if (ClientTable.SelectedRows.Count > 0)
            {
                int client_id = Convert.ToInt32(ClientTable.SelectedRows[0].Cells[0].Value);
                if(!db.ClientService.Any(p => p.ClientID == client_id))
                {
                    string message = "Вы уверены, что хотите удалить клиента?";
                    string caption = "";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.Yes)
                    {
                        Client client = db.Client.Where(p => p.ID == client_id).FirstOrDefault();
                        db.Client.Remove(client);
                        db.SaveChanges();
                        MessageBox.Show("Клиент успешно удален!");
                        UpdateTable();
                    }

                }else MessageBox.Show("Вы не можете удалить этого клиента, так как он связан с таблицей ClientService!");
            }
            else MessageBox.Show("Вы не выбрали клиента!");
        }

        public List<Client> ShowCurrentMonthBirthday(List<Client> list)
        {
            List<Client> new_list = new List<Client>();
            foreach (Client cl in list)
                if (cl.Birthday.Date.Month == DateTime.Now.Month) new_list.Add(cl);
            return new_list;
        }

        public List<Client> SortTable(List<Client> list)
        {
            List<Client> new_list = new List<Client>();

            if (CmbSort.SelectedIndex == 0) return list;
            if (CmbSort.SelectedIndex == 1)
                new_list = list.OrderBy(x => x.LastName).ToList();
            if(CmbSort.SelectedIndex == 2)
                new_list = list.OrderByDescending(x => x.Quantity).ToList();
            if (CmbSort.SelectedIndex == 3)
                new_list = list.OrderBy(x => x.LastDate).ToList();
            return new_list;
        }

        public void UpdateTable()
        {
            if (CmbPagesCount.SelectedIndex == -1)
            CmbPagesCount.SelectedIndex = 0;
            if (CmbGenderFilter.SelectedIndex == -1)
            CmbGenderFilter.SelectedIndex = 0;
            if (CmbSort.SelectedIndex == -1)
                CmbSort.SelectedIndex = 0;
            List<Client> clients = new List<Client>();
            string check = null;
            if (CmbGenderFilter.SelectedIndex == 0) check = "Все";
            if (CmbGenderFilter.SelectedIndex == 1) check = "м";
            if (CmbGenderFilter.SelectedIndex == 2) check = "ж";
            foreach (Client client in db.Client.ToList())
            {
                if (client.GenderCode != check && check != "Все") continue;
                client.Quantity = db.ClientService.Where(p => p.ClientID == client.ID).Count();
                DateTime LastTime = DateTime.MinValue;
                foreach (ClientService clientService in db.ClientService.ToList())
                    if (clientService.StartTime > LastTime) LastTime = clientService.StartTime;
                client.LastDate = LastTime;
                foreach (TagOfClient tagOfClient in db.TagOfClient.ToList())
                    if (client.ID == tagOfClient.ClientID) client.Tags += tagOfClient.Tag.Title + ";";
                clients.Add(client);
            }
            if (SearchStr != null)
                clients = SearchList(clients);

            clients = SortTable(clients);

            if (CheckBirthday.Checked)
                clients = ShowCurrentMonthBirthday(clients);

            PageSize = Convert.ToInt32(clients.Count());
            CalculateTotalPages();
            PageLab.Text = PrintLabText(false,1);
            ClientTable.DataSource = clients;
            ClientTable.Columns[9].Visible = false;
            ClientTable.Columns[13].Visible = false;
            ClientTable.Columns[14].Visible = false;
            ClientTable.Columns[15].Visible = false;
            ClientTable.Columns[0].HeaderText = "ID";
            ClientTable.Columns[1].HeaderText = "Имя";
            ClientTable.Columns[2].HeaderText = "Фамилия";
            ClientTable.Columns[3].HeaderText = "Отчество";
            ClientTable.Columns[4].HeaderText = "Дата рождения";
            ClientTable.Columns[5].HeaderText = "Дата добавления";
            ClientTable.Columns[6].HeaderText = "Email";
            ClientTable.Columns[7].HeaderText = "Телефон";
            ClientTable.Columns[8].HeaderText = "Пол";
            ClientTable.Columns[10].HeaderText = "Последнее посещение";
            ClientTable.Columns[11].HeaderText = "Количество посещений";
            ClientTable.Columns[12].HeaderText = "Список тегов";
        }

       

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            UpdateTable();
        }

        private void CmbPagesCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbPagesCount.SelectedIndex == 0) UpdateTable();
            else
            {
                PageSize = Convert.ToInt32(CmbPagesCount.SelectedItem);
                CalculateTotalPages();
                ClientTable.DataSource = GetCurrentRecords(1);

            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (CurrentIndexPage < TotalPages)
            {
                CurrentIndexPage++;
                ClientTable.DataSource =
                GetCurrentRecords(CurrentIndexPage);
            }
        }

        private void BtnPreviosPage_Click(object sender, EventArgs e)
        {
            if (CurrentIndexPage > 1)
            {
                CurrentIndexPage--;
                ClientTable.DataSource =
                GetCurrentRecords(CurrentIndexPage);
            }
        }

        private void CmbGenderFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbGenderFilter.SelectedIndex == 0 || CmbPagesCount.SelectedIndex == 0 ) UpdateTable();
            else
            {
                PageSize = Convert.ToInt32(CmbPagesCount.SelectedItem);
                CalculateTotalPages();
                ClientTable.DataSource = GetCurrentRecords(1);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchStr = TxtSearch.Text;

            if (CmbGenderFilter.SelectedIndex == 0 || CmbPagesCount.SelectedIndex == 0) UpdateTable();
            else
            {
                PageSize = Convert.ToInt32(CmbPagesCount.SelectedItem);
                CalculateTotalPages();
                ClientTable.DataSource = GetCurrentRecords(1);
            }

        }

        private void CmbSortDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbGenderFilter.SelectedIndex == 0 || CmbPagesCount.SelectedIndex == 0) UpdateTable();
            else
            {
                PageSize = Convert.ToInt32(CmbPagesCount.SelectedItem);
                CalculateTotalPages();
                ClientTable.DataSource = GetCurrentRecords(1);
            }
        }

        private void CheckBirthday_CheckedChanged(object sender, EventArgs e)
        {
            if (CmbGenderFilter.SelectedIndex == 0 || CmbPagesCount.SelectedIndex == 0) UpdateTable();
            else
            {
                PageSize = Convert.ToInt32(CmbPagesCount.SelectedItem);
                CalculateTotalPages();
                ClientTable.DataSource = GetCurrentRecords(1);
            }
        }

        private void DelClient_Click(object sender, EventArgs e)
        {
            RemoveClient();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            new AddClientForm().ShowDialog();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            new EditClienForm(Convert.ToInt32(ClientTable.SelectedRows[0].Cells[0].Value)).ShowDialog();
        }
    }
}
