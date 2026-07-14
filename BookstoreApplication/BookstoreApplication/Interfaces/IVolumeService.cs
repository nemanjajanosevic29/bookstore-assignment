using BookstoreApplication.DTOs;

namespace BookstoreApplication.Interfaces
{
    public interface IVolumeService
    {
        Task<List<VolumeDto>> SearchVolumesByName(string filter);
    }
}