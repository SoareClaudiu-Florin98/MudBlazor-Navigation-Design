using MudBlazor;

namespace Video.Streaming.Platform.Ui.Client.Themes
{
    public static class ThemeHelper
    {
        public static MudTheme GetTheme() =>
            new MudTheme
            {
                Palette = new Palette()
                {
                    Black = "#27272f",
                    AppbarBackground = "#B22222",
                    Primary = "#B22222",
                    DrawerIcon = "#B22222",
                    DrawerText = "#000000",
                    TextPrimary = "#000000",
                    TextSecondary = "#000000"

                },
                PaletteDark = new Palette()
                {
                    Black = "#27272f",
                    Background = "#32333d",
                    BackgroundGrey = "#27272f",
                    Surface = "#373740",
                    TextPrimary = "#ffffffb3",
                    TextSecondary = "rgba(255,255,255, 0.50)",
                    AppbarBackground = "#7C0A02",
                    AppbarText = "#ffffffb3",
                    DrawerBackground = "#27272f",
                    DrawerText = "#ffffffb3",
                    DrawerIcon = "#E6756D",
                    Primary = "#E6756D"
                },
                Typography = new Typography()
                {
                    Default = new Default()
                    {
                        FontFamily = new[] { "Poppins", "Helvetica", "Arial", "sans-serif" },
                    }
                }
            };
    }
}
