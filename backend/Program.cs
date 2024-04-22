using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

string JSONString = string.Empty;

using (var connection = new SqliteConnection("Data Source=searching.db"))
{
    connection.Open();

    var command = connection.CreateCommand();
    command.CommandText =
    @"
        SELECT  P.ProductId,
                P.ProductName,
                P.ProjectName,
                M.MetroAreaId,
                M.MetroAreaTitle,
                M.MetroAreaStateAbr,
                M.MetroAreaStateName,
                PG.FullName,
                PG.ProjectGroupId,
                PG.Status
        FROM 'Products' P
        INNER JOIN 'ProjectGroups' PG ON P.ProjectGroupId = PG.ProjectGroupId
        INNER JOIN 'MetroAreas' M ON PG.MetroAreaId = M.MetroAreaId
        ORDER BY P.ProductName
    ";
    //command.Parameters.AddWithValue("$id", id);

    using (var reader = command.ExecuteReader())
    {
        var dataTable = new DataTable();
        dataTable.Load(reader);
        JSONString = JsonConvert.SerializeObject(dataTable);
    }
}

app.MapGet("/search", () => JSONString)
.WithName("search")
.WithOpenApi();

app.Run();