﻿using CDC.WebNotes.Application.Contracts;
using CDC.WebNotes.Application.Services;
using CDC.WebNotes.Data.Contracts;
using CDC.WebNotes.Data.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;

namespace CDC.WebNotes.Host.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProblemDetailsConfig(this IServiceCollection services)
        {
            services.AddProblemDetails(problemDetailsConfig =>
            {
                problemDetailsConfig.MapToStatusCode<KeyNotFoundException>(StatusCodes.Status404NotFound);
                problemDetailsConfig.MapToStatusCode<ValidationException>(StatusCodes.Status400BadRequest);

            });

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<INotesService, NotesService>();
            services.AddScoped<INoteCheckListItemsService, NoteCheckListItemsService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<INotesRepository, NotesRepository>();
            services.AddScoped<INoteCheckListItemsRepository, NoteCheckListItemsRepository>();
            services.AddScoped<IFilesRepository, FilesRepository>();
            services.AddScoped<IAttachmentsRepository, AttachmentsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            return services;
        }

        public static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
        {
            services.AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblyContaining<Api.Validators.Notes.CreateNoteValidator>();
            });

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-US");

            return services;
        }
    }
}
