using WebApplication2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // ������������� �������� ������
            services.AddDbContext<BooksContext>(options =>
           options.UseSqlServer(SqlConnectionIntegratedSecurity));
            services.AddControllers(); // ���������� ����������� ��� �������������
        }
        public static string SqlConnectionIntegratedSecurity
        {
            get
            {
                var sb = new SqlConnectionStringBuilder
                {
                    DataSource = "tcp:testserver666.database.windows.net,1433",
                    // ����������� ����� � ��������� ����������� ������������ Windows
                    IntegratedSecurity = false,
                    // �������� ������� ���� ������.
                    InitialCatalog = "Book",
                    UserID = "sophia",
                    Password = "almira@2004@"
                };
                return sb.ConnectionString;
            }
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // ���������� ������������� �� �����������
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }

    }
}
