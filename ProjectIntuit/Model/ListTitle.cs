using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIntuit.Model
{
    public class ListTitle : ObservableCollection<Title>
    {
        DavidovEntities dataEntities = new DavidovEntities();

        public ListTitle()
        {

            var queryTitle = from Title in dataEntities.Title
                             select Title;
            foreach (Title titl in queryTitle)
            {
                this.Add(titl);
            }

        }
    }
}
