using ClickMart.DataAccess.Interfaces.Products;
using ClickMart.DataAccess.Utils;
using ClickMart.DataAccess.ViewModels.Products;
using ClickMart.Domain.Entities.Products;
using Dapper;

namespace ClickMart.DataAccess.Repositories.Products;

public class ProductsRepository : BaseRepository, IProductRepository
{

    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from public.products";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Product entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.products(name, description, image_path," +
                " unit_price, category_id, company_id) " +
                "VALUES (@Name, @Description, @ImagePath, @UnitPrice, @CategoryId, @CompanyId);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {

            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM public.products WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        { 
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM public.products ORDER BY id desc offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var resProduct = (await _connection.QueryAsync<Product>(query)).ToList();
            return resProduct;

        }
        catch
        {
            return new List<Product>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Product?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string qeury = $"SELECT * FROM public.products where id=@Id";
            var res = await _connection.QuerySingleAsync<Product>(qeury, new { Id = id });
            return res;

        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Product>> GetCarsByCategory(string category)
    {
        string query = "SELECT * FROM products WHERE category = @Category";
        var parameters = new { Category = category };
        var products = await _connection.QueryAsync<Product>(query, parameters);
        return products.ToList();
    }

    public async Task<IList<Product>> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM public.products WHERE name ILIKE '%{search}%'" +
                $" ORDER BY id DESC OFFSET {@params.GetSkipCount()} " +
                $"LIMIT {@params.PageSize}";
            var products = await _connection.QueryAsync<ProductViewModel>(query);

            return (IList<Product>)products;
        }
        catch
        {
            return new List<Product>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> SearchCountAsync(string search)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT COUNT(*) FROM public.products WHERE name ILIKE '%{search}%'";
            var count = await _connection.ExecuteScalarAsync<int>(query);
            return count;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Product entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.products SET name=@Name, description=@Description," +
                $" image_path=@ImagePath, unit_price=@UnitPrice, category_id=@CategoryId, " +
                $"company_id=@CompanyId WHERE id {id};";
            var resUp = await _connection.ExecuteAsync(query, entity);
            return resUp;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
