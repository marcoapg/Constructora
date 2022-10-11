using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ConstructoraWPF.Models;
using ConstructoraWPF.Repositories;

namespace ConstructoraWPF.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount; 
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if(user!=null)
            {
                CurrentUserAccount.NombreUsuario = user.NombreUsuario;
                CurrentUserAccount.Nombre = $"Bienvenido {user.TrabajadorID} ; )";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.Nombre = "Usuario Invalido, inicia sesión porfavor";
            }
        }
    }
}
