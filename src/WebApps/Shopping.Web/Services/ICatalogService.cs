namespace Shopping.Web.Services
{
    public interface ICatalogService
    {
        [Get("/catalog-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
        Task<GetAllProductResponse> GetAllProductAsync(int? pageNumber = 1, int? pageSize = 10);
        
        [Get("/catalog-service/products/{id}")]
        Task<GetProductByIdResponse> GetProductByIdAsync(Guid id);
        
        [Get("/catalog-service/products/category/{category}")]
        Task<GetProductByCategoryResponse> GetProductByCategoryAsync(string category);
        
    }
}
