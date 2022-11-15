using EmailGenerator.Services;
using Microsoft.AspNetCore.Components;

namespace EmailGenerator.Components.Emails
{
    public partial class WelcomeEmail : ComponentBase
    {
        [Inject]
        private RandomWordProvider _RandomWordProvider { get; set; } = default!;

        [Parameter]
        public string? QueryParamString { get; set; }

        public DateTime Now => DateTime.Now;

        public int A { get; set; }
        public int B { get; set; }
        public int C => A + B;

        public string? RandomWord { get; set; }

        public WelcomeEmail()
        {
            var random = new Random();
            A = random.Next(1, 101);
            B = random.Next(1, 101);
        }

        protected override void OnInitialized()
        {
            RandomWord = _RandomWordProvider.GetRandomWord();
            base.OnInitialized();
        }
    }
}
