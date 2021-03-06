﻿using ExtendedMap.Forms.Plugin.Abstractions;
using PluginSampleApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PluginSampleApp.Pages
{
    public class ExtendedMapPage : ContentPage
    {
        public ExtendedMapPage()
        {
            BindingContext = new ExtendedViewModel();

            var grid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
                },
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                }
            };

            grid.Children.Add(CreateMapContentView(), 0, 0);

            Content = grid;
        }

        View CreateMapContentView()
        {
            //Coordinates for the starting point of the map
            const double latitude = 41.788081;
            const double longitude = -87.831573;

            var location = new Position(latitude, longitude);

            var _map = new global::ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(15))) { IsShowingUser = true };

            _map.StyleId = "CustomMap";

            _map.BindingContext = BindingContext;

            _map.SetBinding<ExtendedViewModel>(global::ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap.CustomPinsProperty, x => x.SamplePins);

            var createMapContentView = new CustomMapContentView(_map);
            
           
            return createMapContentView;
        }
    }
}