using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationUser.Manager
{
    interface ISearchDataManager
    {
        void GetSearchedEmployees(SearchRequest req, IUsecaseCallback<SearchResponse> callBack);
    }
}
