using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoserv
{
    class Pagination <T>
    {
        protected int totalPages = 0;
        protected int  currentIndexPage = 1;
        protected int pageSize = 10;
        private List<T> data;
        public int TotalPages { get { return totalPages;}}

        public List<T> GetData(int page)
        {
            // Функция служит для получения даннх для определенной страницы

            CalculateTotalPages();
            GetCurrentRecords(page);
            return this.data;
        }

        public void SetData(List <T> data)
        {
            // Метод служаит для установки list, по которому необходимо произвести пагинацию
            this.data = data;
        }

        public void SetPageSize(int size)
        {
            this.pageSize = size;
        }

        private void CalculateTotalPages()
        {
            // Метод пересчитывает количество страниц
            int rowCount;
            rowCount = Convert.ToInt32(this.data.Count());
            this.totalPages = rowCount / this.pageSize;
            if (rowCount % this.pageSize > 0)
                this.totalPages += 1;
        }

        private void GetCurrentRecords(int page)
        {
            // Метод устанавливает содержание страницы по нужному номеру

            if (page == 1) this.data = this.data.Take(page).ToList();
            else
            {
                int previousPageOffSet = (page - 1) * this.pageSize;
                List<T> excludeData = this.data.Take(previousPageOffSet).ToList();
                this.data = this.data.Where(p => !excludeData.Contains(p)).Take(this.pageSize).ToList();
            }
        }

        public void NextPage()
        {
            if (this.currentIndexPage < TotalPages)
            {
                this.currentIndexPage++;
                GetCurrentRecords(this.currentIndexPage);
            }
        }

        public void PrevPage()
        {
            if (this.currentIndexPage > 1)
            {
                this.currentIndexPage--;
                GetCurrentRecords(this.currentIndexPage);
            }
        }



    }
}
