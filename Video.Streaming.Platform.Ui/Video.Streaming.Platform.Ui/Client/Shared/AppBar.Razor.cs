using Microsoft.AspNetCore.Components;
using MudBlazor;
using Video.Streaming.Platform.Ui.Client.Services;

namespace Video.Streaming.Platform.Ui.Client.Shared
{
    public partial class AppBar
    {

        [Parameter]
        public bool IsDarkMode { get; set; }
        [Parameter]
        public bool IsMobile { get; set; }
        public bool IsNotMobile { get { return !IsMobile; } }


        [Parameter]
        public EventCallback OnSidebarToggled { get; set; }
        [Parameter]
        public EventCallback<bool> OnDarkModeChanged { get; set; }
        
        [Parameter]
        public EventCallback<MudTheme> OnThemeToggled { get; set; }
        [Inject]
        private IUserPreferencesService? UserPreferencesService { get; set; }
        private async Task ToggleTheme()
        {

            IsDarkMode = !IsDarkMode;
            if (UserPreferencesService != null)
            {
                await UserPreferencesService.SaveUserPreferences(new UserPreferences { DarkTheme = IsDarkMode });
            }
            await OnDarkModeChanged.InvokeAsync(IsDarkMode);

        }

    }
}
