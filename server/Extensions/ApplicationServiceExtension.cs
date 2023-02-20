using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interfaces;
using server.Services;

namespace server.Extensions
{
    public static class ApplicationServiceExtension
    {
        // this เป็นการบอกว่า method จะเป็น extension เสริมเข้าไปใน class ที่ระบุ
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            /*
                AddTransient    -> ถูกสร้างขึ้นเมื่อมีการ Req และถูกเมื่อ Res
                AddSingleton    -> ถูกสร้างขึ้นเมื่อแอบเริ่มทำงานและถูกทำงายเมื่อแอพหยุดการทำงาน โดยปกติจะใช้ใน Catch Services
            */
            services.AddTransient<ITokenService, TokenService>();
            services.AddCors();
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}