
using AutoMapper;
using DevNot21.Entities;
using DevNot21.Entities.DbContexts;
using DevNot21.Model;
using DevNot21.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
/// <summary>
/// https://medium.com/geekculture/end-to-end-project-with-minimal-api-in-asp-net-core-6-0-f32eaca9334d
/// </summary>
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SQLDBConnection");
builder.Services.AddDbContext<ABYS_PRODContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IZipService, ZipService>();

builder.Services.AddDataProtection();
builder.Services.AddCors();

var serviceProvider = builder.Services.BuildServiceProvider();
var provider = serviceProvider.GetService<IDataProtectionProvider>();

var protector = provider.CreateProtector(builder.Configuration["Protector_Key"]);

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new DevNotMapper(protector));
});

IMapper autoMapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(autoMapper);

builder.Services.AddAuthorization();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Issuer"],
        ValidAudience = builder.Configuration["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SigningKey"]))
    };
});

builder.Services.AddSingleton<ITokenService>(new TokenService(builder));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id ="Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});



var app = builder.Build();

app.UseAuthorization();
app.UseAuthentication();
app.UseCors(p =>
{
    p.AllowAnyOrigin();
    p.WithMethods("GET");
    p.AllowAnyHeader();
});

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/GetRoles", (Func<List<DevNot21.Model.Role>>)(() => new()
{
    new(1, "Admin", 1),
    new(2, "User", 1),
    new(2, "Worker", 1)
}));

app.MapGet("/GetTop5UserPermisions", async (ABYS_PRODContext context, IZipService service) =>
{
    var userList = await context.DbUsers.Where(du => du.IdSecurityRole != null).Select(u => $"{u.Name} {u.LastName}").Take(5).ToListAsync();

    var roleList = await (from role in context.DbSecurityRoles join user in context.DbUsers on role.IdSecurityRole equals user.IdSecurityRole
                          select role.SecurityRoleName).Take(5).ToListAsync();

    var IdUserList = await context.DbUsers.Where(du => du.IdSecurityRole != null).Select(db => db.IdUser.ToString()).Take(5).ToListAsync();

    var elementList = await context.DbSecurityUserActions.Where(a => a.IdSecurityController == 2).Select(u => u.ActionNumberTotal).ToListAsync();

    var numberCount = elementList.Count();

    List<long?> actionList;

    if (numberCount > 0)
    {
        actionList = await context
            .DbSecurityUserActions.Where(a => a.IdSecurityController == 2 && a.IdUser != null && IdUserList.Contains(a.IdUser.ToString())).Select(u => u.ActionNumberTotal).Take(5).ToListAsync();
    }
    else
    {
        actionList = new List<long?>();
    }
    

    return service.ZipResult(userList, roleList, actionList);
});

app.MapPost("/InsertUser", async (ABYS_PRODContext context, DevNot21.Model.User user, IMapper mapper) =>
{
    //var model = autoMapper.Map<DbUser>(user);
    var model = mapper.Map<DbUser>(user);
    context.DbUsers.Add(model);
     
    await context.SaveChangesAsync();
    return new OkResult();
});

app.MapGet("/GetAllUsersByName/{name}",
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] async (HttpContext http, ABYS_PRODContext context, string name) =>
{
    var model = await context.DbUsers.Where(u =>
    u.Name.Contains(name)).ToListAsync(); var result = autoMapper.Map<List<DevNot21.Model.User>>(model);
    return result;
}).RequireAuthorization();

app.MapPost("/login", [AllowAnonymous] async (ABYS_PRODContext _context, HttpContext http, ITokenService service, Login login) =>
{
    if (!string.IsNullOrEmpty(login.UserName) && !string.IsNullOrEmpty(login.Password))
    {
        var userModel = await _context.DbUsers.Where(u => u.UserName == login.UserName && u.Password == login.Password)
            .FirstOrDefaultAsync(); 
        
        if (userModel == null)
        {
            http.Response.StatusCode = 401;
            await http.Response.WriteAsJsonAsync(new { Message = "Yor Are Not Authorized!" });
            return;
        }

        var token = service.GetToken(userModel);
        await http.Response.WriteAsJsonAsync(new { token = token });
        return;
    }
});

//app.Urls.Add("https://localhost:7214");

app.Run();
