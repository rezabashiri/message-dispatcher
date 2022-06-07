using Api.Faker.MinimalApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

var eventNames = new[]
{
    "C# for beginners", "Look over docker", "How to have a neat organized code", ".Net6 after party", "Micro services in next level"
};

app.MapGet("/api/events/{appKey}", (string appKey) =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new Event
                (
                    index,
                    DateTime.Now.AddDays(index),
                    DateTime.Now.AddDays(index +1),
                    eventNames[index -1 ],
                    "2fdfg428b1c30ffa26hbfgh"
                ))
            .Where(x=>x.AppKey == appKey).ToList();
        return forecast;
    })
    .WithName("GetEventList").Produces<List<Event>>();

app.Run();