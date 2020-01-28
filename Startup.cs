using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GraphQL.Server.Ui.GraphiQL;
using GraphiQl;
using GraphQL;
using GraphQL.Types;

namespace dotnet_graphql
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<AuthorQuery>();
            services.AddSingleton<AuthorMutation>();
            services.AddSingleton<AuthorType>();
            services.AddSingleton<BookType>();
            //services.AddSingleton<AuthorSchema>();
            services.AddSingleton<AuthorInputType>();
            services.AddSingleton<BookInputType>();
            services.AddSingleton<AuthorData>();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            //services.AddSingleton<ISchema, AuthorSchema>();
            services.AddSingleton<ISchema>(
              s => new AuthorSchema(new FuncDependencyResolver(type => (IGraphType)s.GetRequiredService(type))));

            //services.AddSingleton<AuthorSchema>();
            //services.Configure<GraphQLSettings>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
            //app.UseGraphiQl("/graphiql");
            app.UseGraphiQLServer(new GraphiQLOptions()
            {
                GraphiQLPath = "/graphiql",
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // app.UseGraphiQLServer(new GraphiQLOptions
            // {
            //     //Path = "/ui/graphiql",
            //     GraphQLEndPoint = "/graphql",
            // });/

        }
    }
}
