using System;
using System.Collections.Generic;
using System.Text;

namespace OPM.OPMEnginee
{
    interface IListExpDP
    {
        public int InsertListExpDP(IListExpDP lstExpDP, string strInsertQuery);
        public int GetDetailListExpDP(ref IListExpDP lstExpDP, string strQueryOne);
        public int GetAllListExpDP(ref List<IListExpDP> lstExpDPs);
    }
}
