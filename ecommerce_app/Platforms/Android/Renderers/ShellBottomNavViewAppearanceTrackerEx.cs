using Android.Graphics.Drawables;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.Platform.Compatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Platforms.Android.Renderers
{
    public class ShellBottomNavViewAppearanceTrackerEx : ShellBottomNavViewAppearanceTracker
    {
        private readonly IShellContext shellContext;

        public ShellBottomNavViewAppearanceTrackerEx(IShellContext shellContext, ShellItem shellItem) : base(shellContext, shellItem)
        {
            this.shellContext = shellContext;
        }

        public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            base.SetAppearance(bottomView, appearance);

            // Configuração para criar bordas arredondadas no topo do TabBar
            var backgroundDrawable = new GradientDrawable();
            backgroundDrawable.SetShape(ShapeType.Rectangle);
            backgroundDrawable.SetCornerRadii(new float[] { 150, 150, 150, 150, 150, 150, 150, 150 });
            bottomView.SetBackground(backgroundDrawable);

            var layoutParams = new MauiViewGroup.MarginLayoutParams(bottomView.LayoutParameters);
            layoutParams.SetMargins(120, 110, 120, 130);

            bottomView.Elevation = 90f; // Elevação para criar sombra

            //backgroundDrawable.SetColor)); // Cor branca como no exemplo
            //bottomView.SetBackground(backgroundDrawable);
        }
    }
}
