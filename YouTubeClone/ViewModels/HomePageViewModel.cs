using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using YouTubeClone.Interfaces;
using YouTubeClone.Models;

namespace YouTubeClone.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IGetAll<Video> _getAllVideoRepo;
        public bool IsDarkModeOn { get; set; }
        public List<Video> Videos { get; set; }
        public HomePageViewModel(INavigationService navigationService, IGetAll<Video> getAllVideoRepo)
            :base(navigationService)
        {
            this._navigationService = navigationService;
            this._getAllVideoRepo = getAllVideoRepo;
            Title = "Home";
            Videos = _getAllVideoRepo.GetAll();
            IsDarkModeOn = (App.Current.Resources.Source.OriginalString == "Themes/DarkTheme.xaml");


        }
    }
}
