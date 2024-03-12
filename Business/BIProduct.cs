using Entitys;

namespace Business
{
    public interface BIProduct
    {
        Task<bool> Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(int accion, int productId);
        Task<List<Product>> GetAll(int accion);
    }
}
