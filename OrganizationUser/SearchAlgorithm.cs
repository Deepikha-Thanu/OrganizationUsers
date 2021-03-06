using OrganizationUser.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser
{
    public class SearchAlgorithm
    {
        Dictionary<int, BusinessPeopleModel> RemovedPosPeople = new Dictionary<int, BusinessPeopleModel>();
        Dictionary<int, string> PeoplePosition = new Dictionary<int, string>();
        int j = 0;
        int Length;
        public SearchAlgorithm(List<BusinessPeopleModel> Peoples)
        {
            for (int i = 0; i < Peoples.Count; i++)
            {
                PeoplePosition.Add(i, Peoples[i].Fullname);
            }
            Length = Peoples.Count;
        }
        public static string ListToStringConvertion(List<BusinessPeopleModel> listToConvert)
        {
            int i;
            string ReportingToList = "";
            if (listToConvert.Count == 1)
            {
                ReportingToList = ReportingToList + listToConvert[0].ReportingToId.ToString();
                return ReportingToList;
            }
            for (i = 0; i < listToConvert.Count; i++)
            {
                if (!ReportingToList.Contains(listToConvert[i].ReportingToId + ","))
                {
                    if (i == 0)
                    {
                        ReportingToList = ReportingToList + listToConvert[i].ReportingToId.ToString();
                    }
                    else
                    {
                        ReportingToList = ReportingToList + ", " + listToConvert[i].ReportingToId.ToString();
                    }
                }
            }
            //if (!ReportingToList.Contains(listToConvert[i].ReportingToId + ","))
            //{
            //    ReportingToList = ReportingToList + listToConvert[i].ReportingToId.ToString();
            //}
            return ReportingToList;
        }
        public bool search(ObservableCollection<BusinessPeopleModel> Peoples,string data)
        {
            //bool res = false;
            //List<People> tempPeople = Peoples.ToList();
            //Peoples.Clear();
            //for(int i=0;i<tempPeople.Count;i++)
            //{
            //    if(tempPeople[i].Fullname.StartsWith(data))
            //    {
            //        res= true;
            //        Peoples.Add(tempPeople[i]);
            //    }
            //}
            //return res;
            bool res = true;
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
            if (Peoples.Count == 0)
            {
                res = false;
            }
            if (Peoples.Count > 0)
            {
                res = true;
            }
            return res;
        }
    }
}
