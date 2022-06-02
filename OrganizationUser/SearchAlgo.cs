using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser
{
    internal class SearchAlgo
    {
        Dictionary<int, People> RemovedPosPeople = new Dictionary<int, People>();
        Dictionary<int, string> PeoplePosition = new Dictionary<int, string>();
        int j = 0;
        int Length;
        public SearchAlgo(List<People> Peoples)
        {
            for (int i = 0; i < Peoples.Count; i++)
            {
                PeoplePosition.Add(i, Peoples[i].Fullname);
            }
            Length = Peoples.Count;
        }
        public bool search(ObservableCollection<People> Peoples,string data)
        {
            for (int i = 0; i < Peoples.Count; i++)
            {
                if (!Peoples[i].Fullname.StartsWith(data, StringComparison.OrdinalIgnoreCase))
                {
                    int pos = PeoplePosition.FirstOrDefault(x => x.Value == Peoples[i].Fullname).Key;
                    if (!RemovedPosPeople.Keys.Contains(pos))
                    {
                        RemovedPosPeople.Add(pos, Peoples[i]);
                    }
                    Peoples.RemoveAt(i);
                    i--;
                }
                j++;
                if(Peoples.Count==0)
                {
                    return false;
                }    
            }
            //int Length= Original.Count;
            for (int i = 0; i < Length; i++)
            {
                if (RemovedPosPeople.ContainsKey(i))
                {
                    if (RemovedPosPeople[i].Fullname.StartsWith(data, StringComparison.OrdinalIgnoreCase))
                    {
                        int pos = RemovedPosPeople.FirstOrDefault(x => x.Value == RemovedPosPeople[i]).Key;
                        if (pos < Peoples.Count)
                        {
                            Peoples.Insert(pos, RemovedPosPeople[i]);
                        }
                        else
                        {
                            Peoples.Add(RemovedPosPeople[i]);
                        }
                        RemovedPosPeople.Remove(i);
                    }
                }
            }
            return true;
        }
    }
}
