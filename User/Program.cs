using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using User.Application; // For ServiceExtensions
using User.Application.Interfaces;
using User.Infrastructure.Configurations; // For EmailConfig
using User.Infrastructure.Data;
using User.Infrastructure.Repositories;
using User.Infrastructure.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5150", "https://0.0.0.0:7150");

// Rest of the file remains unchanged...
// [Previous content of Program.cs here]
