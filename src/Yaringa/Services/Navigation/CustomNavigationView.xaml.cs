﻿using Xamarin.Forms;

namespace Yaringa.Services {
    public partial class CustomNavigationView : NavigationPage {
        public CustomNavigationView() : base() {
            InitializeComponent();
        }

        public CustomNavigationView(Page root) : base(root) {
            InitializeComponent();
        }
    }
}