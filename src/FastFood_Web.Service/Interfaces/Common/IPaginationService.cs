namespace FastFood_Web.Service.Interfaces.Common
{
    public interface IPaginationService
    {

        public Task<IList<T>> ToPagedAsync<T>(IList<T> items, int pageNumber, int pageSize);
    }
}
