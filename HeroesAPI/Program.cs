using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<HeroDbContext>(options=> 
    options.UseSqlServer(builder.Configuration.GetConnectionString("HeroDbConnection2"))
);

// Agregar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var heroes = new[] {
    new Hero(1,"Bruce Wayne", "Batman", "Vigilante de Gotham City, experto en artes marciales y tecnología"),
    new Hero(2,"Diana Prince", "Wonder Woman", "Princesa amazona con fuerza y habilidades extraordinarias."),
    new Hero(3,"Roberto Gomez Bolaños", "Chapulin Colorado", "Más ágil que una tortuga, más fuerte que un ratón, más noble que una lechuga, su escudo es un corazón")
};

app.MapGet("/", () =>
{
    return Results.Text("Welcome to the Tour of Heroes API", "text/html");
});

app.MapGet("/api/heroes", async (HeroDbContext ctx) =>
{
    return await ctx.Heroes.ToListAsync();
})
.WithName("GetHeroes")
.WithOpenApi();

// app.MapGet("/api/heroes", () =>
// {
//     return heroes;
// })
// .WithName("GetHeroes")
// .WithOpenApi();

app.MapPost("/api/heroes", async (HeroDbContext ctx, Hero hero) =>
{
    Console.WriteLine("", hero.name);
    ctx.Add(hero);
    await ctx.SaveChangesAsync();

    return Results.Created($"/api/heroes/{hero.id}", hero);
})
.WithName("SaveHero")
.WithOpenApi();

//Usar http://localhost:5049/openapi/v1.json para ver la documentacion

app.Run();


public class Hero
{
    public int id { get; set; }
    public string name { get; set; }
    public string alterego { get; set; }
    public string description { get; set; }

    public Hero(int id, string name, string alterego, string description)
    {
        this.id = id;
        this.name = name;
        this.alterego = alterego;
        this.description = description;
    }
}

public class HeroDbContext : DbContext
{
    public DbSet<Hero> Heroes { get; set; }
    public HeroDbContext(DbContextOptions<HeroDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Hero>().HasData(
            new Hero(1, "Bruce Wayne", "Batman", "Vigilante de Gotham City, experto en artes marciales y tecnología"),
            new Hero(2, "Diana Prince", "Wonder Woman", "Princesa amazona con fuerza y habilidades extraordinarias."),
            new Hero(3, "Hal Jordan", "Green Lantern", "Miembro del Green Lantern Corps con un anillo de poder.")
        );
    }
}