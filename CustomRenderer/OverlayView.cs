﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomRenderer
{
    public enum OverlayShape
    {
        Circle,
        Heart,
        Oval
    }

    public class OverlayView : View
    {

        public static readonly BindableProperty ShowOverlayProperty = BindableProperty.Create(
        propertyName: nameof(ShowOverlay),
        returnType: typeof(bool),
        declaringType: typeof(OverlayView),
        defaultValue: true,
        defaultBindingMode: BindingMode.TwoWay);

        public bool ShowOverlay
        {
            get { return (bool)GetValue(ShowOverlayProperty); }
            set { SetValue(ShowOverlayProperty, value); }
        }

        public static readonly BindableProperty OverlayOpacityProperty = BindableProperty.Create(
        propertyName: nameof(OverlayOpacity),
        returnType: typeof(float),
        declaringType: typeof(OverlayView),
        defaultValue: 1.0f,
        defaultBindingMode: BindingMode.TwoWay);

        public float OverlayOpacity
        {
            get { return (float)GetValue(OverlayOpacityProperty); }
            set { SetValue(OverlayOpacityProperty, value); }
        }

        public static readonly BindableProperty OverlayBackgroundColorProperty = BindableProperty.Create(
            propertyName: nameof(OverlayBackgroundColor),
            returnType: typeof(Color),
            declaringType: typeof(OverlayView),
            defaultValue: Color.Gray,
            defaultBindingMode: BindingMode.TwoWay);

        public Color OverlayBackgroundColor
        {
            get { return (Color)GetValue(OverlayBackgroundColorProperty); }
            set { SetValue(OverlayBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty ShapeProperty = BindableProperty.Create(
           propertyName: nameof(Shape),
           returnType: typeof(OverlayShape),
           declaringType: typeof(OverlayView),
           defaultValue: OverlayShape.Oval,
           defaultBindingMode: BindingMode.TwoWay);

        public OverlayShape Shape
        {
            get { return (OverlayShape)GetValue(ShapeProperty); }
            set { SetValue(ShapeProperty, value); }
        }

        public static readonly BindableProperty ShapeScaleProperty = BindableProperty.Create(
            propertyName: nameof(ShapeScale),
            returnType: typeof(double),
            declaringType: typeof(OverlayView),
            defaultValue: 1.0,
            defaultBindingMode: BindingMode.TwoWay);

        public double ShapeScale
        {
            get { return (double)GetValue(ShapeScaleProperty); }
            set { SetValue(ShapeScaleProperty, value); }
        }
    }
}
