using Microsoft.Extensions.DependencyInjection;

namespace rtoapantaTareaS1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPrincipal());
        }
    }
}