using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoserv
{
    public static class Tags
    {
        public static void AddTagInTable(AutoServiceEntities db, DataGridView table, int tag_id)
        {
            try
            {
                foreach (DataGridViewRow item in table.Rows)
                {
                    if (Convert.ToInt32(item.Cells[0].Value) == tag_id) return;
                }
                string name_tag = db.Tag.Where(p => p.ID == tag_id).FirstOrDefault().Title;
                table.Rows.Add(tag_id, name_tag);
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
            
        }

        public static void DelTagInTable(DataGridView table)
        {
            try
            {
                table.Rows.Remove(table.SelectedRows[0]);
                
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        public static void AddTagsInDB(AutoServiceEntities db, DataGridView table, int client_id)
        {
            try
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataGridViewRow item in table.Rows)
                    {
                        db.TagOfClient.Add(
                            new TagOfClient
                            {
                                ClientID = client_id,
                                TagID = Convert.ToInt32(item.Cells[0].Value)
                            });
                        db.SaveChanges();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }

        }

    }
}
