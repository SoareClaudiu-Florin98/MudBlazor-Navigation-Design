using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using Video.Streaming.Platform.Ui.Client.Services;
using Video.Streaming.Platform.Ui.Client.Themes;

namespace Video.Streaming.Platform.Ui.Client.Shared
{
    public partial class MainLayout
    {
        private bool _drawerOpen = true;
        private bool _isMobile = false;
        private bool _isLDarkMode = false;

        DrawerVariant _variant = DrawerVariant.Mini;
        private MudTheme? _currentTheme = ThemeHelper.GetTheme();
        private MudThemeProvider? _mudThemeProvider { get; set; } 

        [Inject]
        private  IBrowserWindowSizeProvider? BrowserWindowSizeProvider { get; set; }
        [Inject]
        private IUserPreferencesService? UserPreferencesService { get; set; }

        [Parameter]
        public EventCallback<MudTheme> OnThemeToggled { get; set; }

        private async Task<bool> CheckIfIsMobile()
        {
            if (BrowserWindowSizeProvider != null)
            {
                var browserWindowSize = await BrowserWindowSizeProvider.GetBrowserWindowSize();
                if (browserWindowSize.Width < 600)
                {
                    return true;
                }
            }
            return false;
        }
        private DrawerVariant GetDrawerVariant(bool isMobile)
        {
            if (isMobile)
            {
                return DrawerVariant.Responsive;
            }
            return DrawerVariant.Mini;
        }
        protected async override void OnInitialized()
        {
            if(UserPreferencesService != null)
            {
                var userPreferances = await UserPreferencesService.LoadUserPreferences();
                if (userPreferances!=null && userPreferances.DarkTheme)
                {
                    _isLDarkMode = true;
                }

            }

            _isMobile = await CheckIfIsMobile();
            _variant = GetDrawerVariant(_isMobile);
            StateHasChanged();
            base.OnInitialized();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && _mudThemeProvider != null && UserPreferencesService!= null)
            {
                var userPreferances = await UserPreferencesService.LoadUserPreferences();

                bool isDarkMode = await _mudThemeProvider.GetSystemPreference();
                if (isDarkMode && userPreferances ==null)
                {
                    _isLDarkMode = true;
                }
                StateHasChanged();            
            }
        }
        private void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }
        private void ToggleTheme(MudTheme changedTheme) => _currentTheme = changedTheme;
        private void ChangeDarkMode(bool isDarkMode) => _isLDarkMode = isDarkMode;

    }
}