﻿using CineVerse.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineVerse.Views.UserControls
{
    public partial class PasswordResetPage : UserControlComponent
    {
        private readonly AuthenticationService _authenticationService;

        public PasswordResetPage(AuthenticationService authenticationService)
        {
            InitializeComponent();

            _authenticationService = authenticationService;

            inpGrpNewPassword.Label = "New Password";
            inpGrpNewPassword.PlaceholderText = "Enter your new password";
            inpGrpNewPassword.PasswordChar = '\u2022';
            inpGrpConfirmNewPassword.Label = "Confirm New Password";
            inpGrpConfirmNewPassword.PlaceholderText = "Confirm your new password";
            inpGrpConfirmNewPassword.PasswordChar = '\u2022';
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            _authenticationService.ResetPassword(inpGrpNewPassword.InputText);
        }
    }
}
