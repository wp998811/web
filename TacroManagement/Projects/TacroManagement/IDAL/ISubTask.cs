using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace IDAL
{
    public interface ISubTask
    {
        int InsertSubTask(SubTaskInfo subTaskInfo);
        int DeleteSubTask(int taskId);
        int UpdateSubTask(SubTaskInfo subTaskInfo);

        IList<SubTaskInfo> GetSubTasks();
        SubTaskInfo GetSubTaskById(int taskId);
        IList<SubTaskInfo> GetSubTasksByProjectNum(string projectNum);
        IList<SubTaskInfo> GetSubTasksByUserId(int userId);
    }
}
