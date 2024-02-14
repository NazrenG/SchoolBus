using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Repository.Abstract
{
    public interface IStudentRepos : IBaseRepos<Student>
    {
        public int FindId(string name, string surname, int classId, int parentId);
    }
}
