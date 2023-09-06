using MyBBSWebApi.BLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*
 *  ��������ע���ʵ������
builder.Services.AddSingleton(); // ���� ֻҪʵ�������Ժ� һֱ���ڴ��б��� ����ע��
builder.Services.AddScoped();   // ���� ��һ�������� ʵ��������Ķ��󲻱�ע��
builder.Services.AddTransient;  // ˲ʱ ʹ�������ʵ���� �ͻᱻ����ע����

*/

builder.Services.AddSingleton<IUserBll, UserBll>();

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

app.MapControllers();

app.Run();
