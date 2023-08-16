
using E_Commerce_Console_App.Controllers;

class program
{
    public async static Task Main()
    {
        await ProductController.Initialize();
    }
}
