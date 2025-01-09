using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IS3Repository
    {
        Task<string> UploadFileAsync(Stream fileStream, string fileName);
        Task<Stream> GetFileAsync(string fileName);
    }
}
