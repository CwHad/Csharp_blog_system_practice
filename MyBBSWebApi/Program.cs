using MyBBSWebApi.BLL;
using MyBBSWebApi.BLL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*
 *  这是依赖注入的实例创建
builder.Services.AddSingleton(); // 单例 只要实例创建以后 一直在内存中保留 不再注销
builder.Services.AddScoped();   // 单例 在一次请求中 实例化请求的对象不被注销
builder.Services.AddTransient;  // 瞬时 使用完这个实例后 就会被立马注销掉

*/
builder.Services.AddCors(c => c.AddPolicy("any", p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

builder.Services.AddSingleton<IUserBll, UserBll>();
builder.Services.AddSingleton<IPostsBLL, PostsBLL>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
