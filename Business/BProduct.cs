using Datas;
using Entitys;

namespace Business
{
    public class BProduct : BIProduct
    {
        readonly IData Repo;
        readonly string SP = "DBO.CRUD_Productos";
        public BProduct(IData repo)
        {
            Repo = repo;
        }
        public async Task<bool> Create(Product product)
        {
            object obj = new 
            {
                @Accion = 1,
                @Nombre = product.Nombre,
                @Id = product.Id
            };
            return await Repo.SqlQuerySpBoolAsync(SP, obj);
        }
        public async Task<bool> Update(Product product)
        {
            object obj = new
            {
                @Accion = 2,
                @Nombre = product.Nombre,
                @Id = product.Id
            };
            return await Repo.SqlQuerySpBoolAsync(SP, obj);
        }
        public async Task<bool> Delete(int accion,int productId)
        {
            object obj = new
            {
                @Accion = 3,
                @Nombre = DBNull.Value,
                @Id = productId
            };
            return await Repo.SqlQuerySpBoolAsync(SP, obj);
        }
        public async Task<List<Product>> GetAll(int accion)
        {
            object obj = new
            {
                @Accion = accion,
                @Nombre = DBNull.Value,
                @Id = DBNull.Value
            };
            return await Repo.SqlQuerySpListAsync<Product>(SP, obj);
        }
    }
}
