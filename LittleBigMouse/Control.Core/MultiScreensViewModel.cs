﻿/*
  LittleBigMouse.Control.Core
  Copyright (c) 2017 Mathieu GRENET.  All right reserved.

  This file is part of LittleBigMouse.Control.Core.

    LittleBigMouse.Control.Core is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    LittleBigMouse.Control.Core is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with MouseControl.  If not, see <http://www.gnu.org/licenses/>.

	  mailto:mathieu@mgth.fr
	  http://www.mgth.fr
*/
using System;
using System.Collections.ObjectModel;
using System.Windows;
using HLab.Mvvm;
using HLab.Notify;
using LittleBigMouse.ScreenConfigs;

namespace LittleBigMouse.Control.Core
{
    public class MultiScreensViewModel : NotifierObject, IPresenterViewModel
    {
        public MultiScreensViewModel() : base(false)
        {
            this.SubscribeNotifier();
        }

        public MainViewModel MainViewModel
        {
            get => this.Get<MainViewModel>();
            set => this.Set(value);
        }

        public Type ViewMode
        {
            get => this.Get(() => typeof(ViewModeDefault/*ViewModeScreenLocation*/));
            set => this.Set(value);
        }

        public ViewModeContext Context => this.Get(
            () => new ViewModeContext(nameof(MultiScreensViewModel))
            .AddCreator<ScreenFrameViewModel>(vm => vm.Presenter = this ));

        public Size Size { get => this.Get<Size>(); set => this.Set(value); }


        public ScreenConfig Config
        {
            get => this.Get<ScreenConfig>();
            set => this.Set(value);
        }


        public ObservableCollection<ScreenFrameViewModel> ScreenFrames = new ObservableCollection<ScreenFrameViewModel>();


    }
}
