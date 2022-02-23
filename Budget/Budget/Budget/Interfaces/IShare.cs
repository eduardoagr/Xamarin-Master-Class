using System.Threading.Tasks;

namespace Budget.Interfaces {
    public interface IShare {

        Task Show(string title, string messge, string filePath);
    }
}
