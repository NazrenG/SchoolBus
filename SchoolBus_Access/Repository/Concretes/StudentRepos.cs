using SchoolBus_Access.Repository.Abstract;
using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Repository.Concretes
{
    public class StudentRepos : BaseRepos<Student>, IStudentRepos
    {
        public int FindId(string name, string surname, int classId, int parentId)
        {
            var student = _context.Students.FirstOrDefault(b => b.Name == name && b.LastName==surname && b.ClassId==classId && b.ParentId==parentId);
            return student != null ? student.Id : 0;
        }
    }
}
