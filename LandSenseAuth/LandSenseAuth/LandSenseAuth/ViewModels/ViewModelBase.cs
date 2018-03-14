//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ViewModelBase.cs" company="IIASA">
//    EOS
//  </copyright>
//  <summary>
//   ViewModelBase.cs
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace LandSenseAuth.ViewModels
{
    using Prism.Mvvm;
    using Prism.Navigation;

    /// <summary>
    /// </summary>
    /// <seealso cref="Prism.Mvvm.BindableBase" />
    /// <seealso cref="Prism.Navigation.INavigationAware" />
    /// <seealso cref="Prism.Navigation.IDestructible" />
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        /// <summary>
        ///     The title
        /// </summary>
        private string _title;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ViewModelBase" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        public ViewModelBase(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public string Title
        {
            get
            {
                return this._title;
            }

            set
            {
                this.SetProperty(ref this._title, value);
            }
        }

        /// <summary>
        ///     Gets the navigation service.
        /// </summary>
        /// <value>
        ///     The navigation service.
        /// </value>
        protected INavigationService NavigationService { get; private set; }

        /// <summary>
        ///     Destroys this instance.
        /// </summary>
        public virtual void Destroy()
        {
        }

        /// <summary>
        ///     Called when [navigated from].
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        /// <summary>
        ///     Called when [navigated to].
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        /// <summary>
        ///     Called when [navigating to].
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}