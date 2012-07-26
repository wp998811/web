using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IProjectDoc
    {
        int InsertProjectDoc(ProjectDocInfo projectDocInfo);
        int DeleteProjectDoc(int projectDocId);
        int UpdateProjectDoc(ProjectDocInfo projectDocInfo);

        IList<ProjectDocInfo> GetProjectDocs();
        ProjectDocInfo GetProjectDocById(int projectId);
        IList<ProjectDocInfo> GetProjectDocsByTaskId(int taskId);
        IList<ProjectDocInfo> GetProjectDocsByUpLoadUserId(int userId);
        IList<ProjectDocInfo> GetProjectDocs(int projectDocCate, string projectDocName, string projectDocKey
            , int projectDocTaskId, int uploadUserId, string uploadTime);

    }
}
