using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YouTubeClone.ViewModels
{
    public class ViewAViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public ViewAViewModel(INavigationService navigationService)
            :base(navigationService)
        {
            this.navigationService = navigationService;
            Title = "MyViewA";
        }
    }
}
