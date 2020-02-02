using Jering.Javascript.NodeJS;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace NodeJSNetFXTest
{
    class Program
    {
        static void Main()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddNodeJS();
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            INodeJSService nodeJSService = serviceProvider.GetRequiredService<INodeJSService>();

            int result = nodeJSService.InvokeFromStringAsync<int>("module.exports = (callback) => callback(null, 1)").GetAwaiter().GetResult();

            Console.WriteLine(result);
        }
    }
}
