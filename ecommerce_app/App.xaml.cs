﻿using ecommerce_app.View;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace ecommerce_app;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        //Entry sem borda
        #if ANDROID
        EntryHandler.Mapper.ModifyMapping("NoUnderline", (h, v, a) =>
        {
            h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
        });

        PickerHandler.Mapper.ModifyMapping("NoUnderline", (h, v, a) =>
        {
            h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
        });
        DatePickerHandler.Mapper.ModifyMapping("NoUnderline", (h, v, a) =>
        {
            h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
        });
        EditorHandler.Mapper.ModifyMapping("NoUnderline", (h, v, a) =>
        {
            h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
        });
        #endif
    }
}
