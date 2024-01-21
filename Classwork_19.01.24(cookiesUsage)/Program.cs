using Classwork_19._01._24_cookiesUsage_.Interfaces;
using Classwork_19._01._24_cookiesUsage_.Models;
using Classwork_19._01._24_cookiesUsage_.Repositories;

namespace Classwork_19._01._24_cookiesUsage_
{
    public class Program
    {
        //���������� ��� � ��� ���� ������ ����. ��� �������� �����, �� ������ ������� ������ (List<News>) �������� � ������ ������� �� �� ��������, ��� �� �����������
        //������������ ������.  

        //���������� �������� "��������� ������", �� ������� ������������ ����� ������� �������������� ������ ������ �����: ������� ��� ������ ����.����� ������������
        //�������� ���� ������ ������ � ��������� ���������, ��� ����������� � Cookie, ����� ��� ����� ���� ������������ ��� ��������� ��������� �����.

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<NewsRepository>();
            builder.Services.AddSingleton<UserRepository>();
            builder.Services.AddScoped<IUserPreferences, UserPreferenceService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}