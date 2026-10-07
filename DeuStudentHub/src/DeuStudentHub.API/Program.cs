using DeuStudentHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using DeuStudentHub.Application.Interfaces;
using DeuStudentHub.Infrastructure.Repositories;
using DeuStudentHub.Application.Courses.GetCourses;
using DeuStudentHub.Application.Courses.CreateCourse;
using DeuStudentHub.Application.Courses.GetCourseById;
using DeuStudentHub.Application.Courses.UpdateCourse;
using DeuStudentHub.Application.Courses.DeleteCourse;
using DeuStudentHub.Application.Faculties.GetFaculties;
using DeuStudentHub.Application.Departments.GetDepartmentsByFaculty;
using DeuStudentHub.Application.Courses.GetCoursesByDepartment;
using DeuStudentHub.Application.CourseSections.GetCourseSections;
using DeuStudentHub.Application.Teachers.GetTeachers;
using DeuStudentHub.Application.Teachers.GetTeacherById;
using DeuStudentHub.Application.Teachers.GetTeacherDetails;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
//_______________________________________________our code____________________________________________________
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
// Repositories
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ICourseSectionRepository, CourseSectionRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

// Course services
builder.Services.AddScoped<GetCoursesService>();
builder.Services.AddScoped<CreateCourseService>();
builder.Services.AddScoped<GetCourseByIdService>();
builder.Services.AddScoped<UpdateCourseService>();
builder.Services.AddScoped<DeleteCourseService>();
builder.Services.AddScoped<GetCoursesByDepartmentService>();
builder.Services.AddScoped<GetCourseSectionsService>();

// Faculty services
builder.Services.AddScoped<GetFacultiesService>();
// Department services
builder.Services.AddScoped<GetDepartmentsByFacultyService>();
// Teacher services
builder.Services.AddScoped<GetTeachersService>();
builder.Services.AddScoped<GetTeacherByIdService>();
builder.Services.AddScoped<GetTeacherDetailsService>();
//_______________________________________________our code____________________________________________________
var app = builder.Build();  

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
