using Android.Content;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Platforms.Android.Renderers
{
    public partial class ShellHandlerEx : ShellRenderer
    {
        public ShellHandlerEx(Context context) : base(context)
        {
        }

        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new ShellBottomNavViewAppearanceTrackerEx(this, shellItem.CurrentItem);
        }
    }
}
